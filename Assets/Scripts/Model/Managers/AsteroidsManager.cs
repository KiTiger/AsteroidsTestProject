using System.Collections.Generic;
using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Model
{
    public class AsteroidsManager : BaseManager, IUpdateManager
    {
        private List<BaseAsteroidController> currentAsteroids = new List<BaseAsteroidController>();
        private float spawnTimer;
        private IGameObjectsPool gameObjectsPool;
        private ISpaceInfo spaceInfo;

        public AsteroidsManager(IGameObjectsPool gameObjectsPool,
            ISpaceInfo spaceInfo)
        {
            this.gameObjectsPool = gameObjectsPool;
            this.spaceInfo = spaceInfo;
        }

        public override void Init(IGameManager gameManager)
        {
            base.Init(gameManager);

            gameManager.GameState.OnChangeGamePart += OnChangeGamePart;
            gameManager.ViewModeManager.onChangeViewData += OnChangeViewData;
        }

        public void Reset()
        {
            var lastControllers = new List<BaseAsteroidController>();
            lastControllers.AddRange(currentAsteroids);

            foreach (var controller in lastControllers)
            {
                DestroyAsteroid(controller);
            }
        }

        void IUpdateManager.Update()
        {
            if (gameManager.GameState.CurrentGamePart != GamePart.Battle) return;

            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                CreateBigAsteroid();
                ResetTimer();
            }
        }

        private void CreateBigAsteroid()
        {
            var side = (Side)Random.Range(0, 4);

            var spawnPosition = spaceInfo.GetSpawnPositionOnSide(side,
                gameManager.GameConfiguration.SpaceObjectsSpawnOffset);
            Vector2 firstBorder = default;
            Vector2 secondBorder = default;

            switch (side)
            {
                case Side.Bottom:
                    firstBorder = new Vector2(spaceInfo.XMin, spaceInfo.YMax);
                    secondBorder = new Vector2(spaceInfo.XMax, spaceInfo.YMax);
                    break;
                case Side.Top:
                    firstBorder = new Vector2(spaceInfo.XMin, spaceInfo.YMin);
                    secondBorder = new Vector2(spaceInfo.XMax, spaceInfo.YMin);
                    break;
                case Side.Left:
                    firstBorder = new Vector2(spaceInfo.XMax, spaceInfo.YMax);
                    secondBorder = new Vector2(spaceInfo.XMax, spaceInfo.YMin);
                    break;
                case Side.Right:
                    firstBorder = new Vector2(spaceInfo.XMin, spaceInfo.YMax);
                    secondBorder = new Vector2(spaceInfo.XMin, spaceInfo.YMin);
                    break;
            }

            var firstAngle = Vector2.SignedAngle(Vector2.right, firstBorder - spawnPosition);
            var secondAngle = Vector2.SignedAngle(Vector2.right, secondBorder - spawnPosition);

            if (firstAngle - secondAngle > 180)
            {
                if (firstAngle < 0) firstAngle += 360;
                if (secondAngle < 0) secondAngle += 360;
            }

            var directionAngle = Random.Range(firstAngle, secondAngle);
            var direction = new Vector3(Mathf.Cos(directionAngle * Mathf.Deg2Rad),
                Mathf.Sin(directionAngle * Mathf.Deg2Rad), 0);

            var speed = Random.Range(gameManager.GameConfiguration.BigAsteroidSpeedMin,
                gameManager.GameConfiguration.BigAsteroidSpeedMax);

            var pref = gameManager.ViewModeManager.CurrentGameViewData.BigAsteroidPref;

            CreateAsteroid(AsteroidTypeEnum.Big, spawnPosition, direction, speed);
        }

        private void CreateSmallAsteroids(Vector3 spawnPosition)
        {
            for (int i = 0; i < gameManager.GameConfiguration.NumberOfSmallAsteroidSpawn; i++)
            {
                var angle = Random.Range(0, 360) * Mathf.Deg2Rad;
                var direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

                var speed = Random.Range(gameManager.GameConfiguration.SmallAsteroidSpeedMin,
                    gameManager.GameConfiguration.SmallAsteroidSpeedMax);

                CreateAsteroid(AsteroidTypeEnum.Small, spawnPosition, direction, speed);
            }
        }

        private void CreateAsteroid(AsteroidTypeEnum asteroidType, Vector3 spawnPosition,
            Vector3 direction, float speed)
        {
            var pref = asteroidType == AsteroidTypeEnum.Big
                ? gameManager.ViewModeManager.CurrentGameViewData.BigAsteroidPref
                : gameManager.ViewModeManager.CurrentGameViewData.SmallAsteroidPref;

            var asteroidController = gameObjectsPool.CreateGameObject(pref);
            currentAsteroids.Add(asteroidController);
            asteroidController.transform.position = spawnPosition;
            asteroidController.SetData(direction, speed, gameManager);
            asteroidController.onCrossedBordersOfScreen += AsteroidCrossedBordersOfScreen;
            asteroidController.onBulletHit += AsteroidOnBulletHit;
            asteroidController.onLaserHit += AsteroidOnLaserHit;
        }

        private void AsteroidCrossedBordersOfScreen(BaseAsteroidController asteroidController)
        {
            DestroyAsteroid(asteroidController);
        }

        private void AsteroidOnBulletHit(BaseAsteroidController asteroidController)
        {
            CalculatePoints(asteroidController);

            if (asteroidController.AsteroidType == AsteroidTypeEnum.Big)
            {
                CreateSmallAsteroids(asteroidController.transform.position);
            }

            DestroyAsteroid(asteroidController);
        }

        private void AsteroidOnLaserHit(BaseAsteroidController asteroidController)
        {
            CalculatePoints(asteroidController);

            DestroyAsteroid(asteroidController);
        }

        private void CalculatePoints(BaseAsteroidController asteroidController)
        {
            var addPoints = asteroidController.AsteroidType == AsteroidTypeEnum.Big
                ? gameManager.GameConfiguration.PointsForBigAsteroid
                : gameManager.GameConfiguration.PointsForSmallAsteroid;
            gameManager.GameState.Score += addPoints;
        }

        private void DestroyAsteroid(BaseAsteroidController asteroidController)
        {
            currentAsteroids.Remove(asteroidController);
            asteroidController.onCrossedBordersOfScreen -= AsteroidCrossedBordersOfScreen;
            asteroidController.onBulletHit -= AsteroidOnBulletHit;
            asteroidController.onLaserHit -= AsteroidOnLaserHit;
            gameObjectsPool.RemoveGameObject(asteroidController);
        }

        private void OnChangeGamePart(GamePart gamePart)
        {
            if (gamePart != GamePart.Battle) return;

            ResetTimer();
        }

        private void ResetTimer()
        {
            spawnTimer = Random.Range(
                gameManager.GameConfiguration.TimeBetweenAppearanceOfAsteroidsMin,
                gameManager.GameConfiguration.TimeBetweenAppearanceOfAsteroidsMax);
        }

        private void OnChangeViewData(GameViewData viewData)
        {
            var lastControllers = new List<BaseAsteroidController>();
            lastControllers.AddRange(currentAsteroids);

            foreach (var controller in lastControllers)
            {
                var asteroidType = controller.AsteroidType;
                var position = controller.transform.position;
                var direction = controller.Direction;
                var speed = controller.Speed;
                DestroyAsteroid(controller);
                CreateAsteroid(asteroidType, position, direction, speed);
            }
        }
    }
}