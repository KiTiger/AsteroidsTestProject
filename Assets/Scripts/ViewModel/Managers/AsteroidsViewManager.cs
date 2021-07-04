using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.GameEngine.Asteroids;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.ViewModel
{
    public class AsteroidsViewManager
    {
        private BidirectionalDictionary<BaseAsteroidController, Asteroid> currentAsteroids
            = new BidirectionalDictionary<BaseAsteroidController, Asteroid>();

        private IAsteroidsManager asteroidsManager;
        private ISpaceInfo spaceInfo;
        private IGameObjectsPool gameObjectsPool;
        private GameViewConfiguration gameViewConfiguration;
        private ViewModeManager viewModeManager;
        private IGameManager gameManager;

        public AsteroidsViewManager(IGameManager gameManager, ISpaceInfo spaceInfo,
            GameViewConfiguration gameViewConfiguration, ViewModeManager viewModeManager,
            IGameObjectsPool gameObjectsPool)
        {
            this.gameManager = gameManager;
            this.spaceInfo = spaceInfo;
            this.gameViewConfiguration = gameViewConfiguration;
            this.viewModeManager = viewModeManager;
            this.gameObjectsPool = gameObjectsPool;

            asteroidsManager = gameManager.AsteroidsManager;

            asteroidsManager.OnCreateBigAsteroid += CreateBigAsteroid;
            asteroidsManager.OnCreateSmallAsteroid += CreateSmallAsteroids;
            asteroidsManager.OnDestroyAsteroid += DestroyAsteroid;

            viewModeManager.onChangeViewData += OnChangeViewData;
        }

        private void CreateBigAsteroid(Asteroid asteroid)
        {
            var side = (Side)Random.Range(0, 4);

            var spawnPosition = spaceInfo.GetSpawnPositionOnSide(side,
                gameViewConfiguration.SpaceObjectsSpawnOffset);
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

            var speed = Random.Range(gameViewConfiguration.BigAsteroidSpeedMin,
                gameViewConfiguration.BigAsteroidSpeedMax);

            var pref = viewModeManager.CurrentGameViewData.BigAsteroidPref;

            CreateAsteroid(asteroid, spawnPosition, direction, speed);
        }

        private void CreateSmallAsteroids(Asteroid asteroid, Asteroid parentAsteroid)
        {

            var angle = Random.Range(0, 360) * Mathf.Deg2Rad;
            var direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

            var speed = Random.Range(gameViewConfiguration.SmallAsteroidSpeedMin,
                gameViewConfiguration.SmallAsteroidSpeedMax);

            var spawnPosition = currentAsteroids[parentAsteroid].transform.position;

            CreateAsteroid(asteroid, spawnPosition, direction, speed);

        }

        private void CreateAsteroid(Asteroid asteroid, Vector3 spawnPosition,
            Vector3 direction, float speed)
        {
            var pref = asteroid.AsteroidType == AsteroidTypeEnum.Big
                ? viewModeManager.CurrentGameViewData.BigAsteroidPref
                : viewModeManager.CurrentGameViewData.SmallAsteroidPref;

            var asteroidController = gameObjectsPool.CreateGameObject(pref);
            currentAsteroids.Add(asteroidController, asteroid);
            asteroidController.transform.position = spawnPosition;
            asteroidController.SetData(direction, speed, gameManager);
            asteroidController.onCrossedBordersOfScreen += AsteroidCrossedBordersOfScreen;
            asteroidController.onBulletHit += AsteroidOnBulletHit;
            asteroidController.onLaserHit += AsteroidOnLaserHit;
        }

        private void DestroyAsteroid(Asteroid asteroid)
        {
            var asteroidController = currentAsteroids[asteroid];
            currentAsteroids.Remove(asteroidController);
            asteroidController.onCrossedBordersOfScreen -= AsteroidCrossedBordersOfScreen;
            asteroidController.onBulletHit -= AsteroidOnBulletHit;
            asteroidController.onLaserHit -= AsteroidOnLaserHit;
            gameObjectsPool.RemoveGameObject(asteroidController);
        }

        private void AsteroidCrossedBordersOfScreen(BaseAsteroidController asteroidController)
        {
            asteroidsManager.AsteroidCrossedBordersOfScreen(currentAsteroids[asteroidController]);
        }

        private void AsteroidOnBulletHit(BaseAsteroidController asteroidController)
        {
            asteroidsManager.AsteroidOnBulletHit(currentAsteroids[asteroidController]);
        }

        private void AsteroidOnLaserHit(BaseAsteroidController asteroidController)
        {
            asteroidsManager.AsteroidOnLaserHit(currentAsteroids[asteroidController]);
        }

        private void OnChangeViewData(GameViewData viewData)
        {
            var lastItems = new BidirectionalDictionary<BaseAsteroidController, Asteroid>(currentAsteroids);

            foreach (var kvItem in lastItems)
            {
                var position = kvItem.Key.transform.position;
                var direction = kvItem.Key.Direction;
                var speed = kvItem.Key.Speed;
                DestroyAsteroid(kvItem.Value);
                CreateAsteroid(kvItem.Value, position, direction, speed);
            }
        }
    }
}