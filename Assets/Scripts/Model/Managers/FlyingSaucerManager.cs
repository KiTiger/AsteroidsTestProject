using System.Collections.Generic;
using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Model
{
    public class FlyingSaucerManager : BaseManager, IUpdateManager
    {
        private List<BaseFlyingSaucerController> currentFlyingSaucers = new List<BaseFlyingSaucerController>();
        private float spawnTimer;
        private IGameObjectsPool gameObjectsPool;
        private ISpaceInfo spaceInfo;

        public FlyingSaucerManager(IGameObjectsPool gameObjectsPool,
            ISpaceInfo spaceInfo)
        {
            this.gameObjectsPool = gameObjectsPool;
            this.spaceInfo = spaceInfo;
        }

        public override void Init(IGameManager gameManager)
        {
            base.Init(gameManager);

            gameManager.ViewModeManager.onChangeViewData += OnChangeViewData;
        }

        public void Reset()
        {
            ResetTimer();
            
            var lastControllers = new List<BaseFlyingSaucerController>();
            lastControllers.AddRange(currentFlyingSaucers);

            foreach (var controller in lastControllers)
            {
                DestroyFlyingSaucer(controller);
            }
        }

        void IUpdateManager.Update()
        {
            if (gameManager.GameState.CurrentGamePart != GamePart.Battle) return;

            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                CreateRandomSaucer();
                ResetTimer();
            }
        }

        private void CreateRandomSaucer()
        {
            var side = (Side)Random.Range(0, 4);

            var spawnPosition = spaceInfo.GetSpawnPositionOnSide(side,
                gameManager.GameConfiguration.SpaceObjectsSpawnOffset);

            CreateFlyingSaucer(spawnPosition);
        }

        private void CreateFlyingSaucer(Vector3 spawnPosition)
        {
            var pref = gameManager.ViewModeManager.CurrentGameViewData.FlyingSaucerPref;

            var flyingSaucerController = gameObjectsPool.CreateGameObject(pref);
            currentFlyingSaucers.Add(flyingSaucerController);
            flyingSaucerController.transform.position =
                new Vector3(spawnPosition.x, spawnPosition.y, 0);
            flyingSaucerController.SetData(gameManager.GameConfiguration.FlyingSaucerSpeed,
                gameManager);

            flyingSaucerController.onCrossedBordersOfScreen += FlyingSaucerOnCrossedBordersOfScreen;
            flyingSaucerController.onBulletHit += FlyingSaucerOnBulletHit;
            flyingSaucerController.onLaserHit += FlyingSaucerOnLaserHit;
        }

        private void FlyingSaucerOnCrossedBordersOfScreen(BaseFlyingSaucerController controller)
        {
            DestroyFlyingSaucer(controller);
        }

        private void FlyingSaucerOnBulletHit(BaseFlyingSaucerController controller)
        {
            AddPoints();

            DestroyFlyingSaucer(controller);
        }

        private void FlyingSaucerOnLaserHit(BaseFlyingSaucerController controller)
        {
            AddPoints();

            DestroyFlyingSaucer(controller);
        }

        private void AddPoints()
        {
            gameManager.GameState.Score += gameManager.GameConfiguration.PointsForFlyingSaucer; ;
        }

        private void DestroyFlyingSaucer(BaseFlyingSaucerController controller)
        {
            currentFlyingSaucers.Remove(controller);
            controller.onCrossedBordersOfScreen -= FlyingSaucerOnCrossedBordersOfScreen;
            controller.onBulletHit -= FlyingSaucerOnBulletHit;
            controller.onLaserHit -= FlyingSaucerOnLaserHit;
            gameObjectsPool.RemoveGameObject(controller);
        }

        private void ResetTimer()
        {
            spawnTimer = Random.Range(
                gameManager.GameConfiguration.TimeBetweenAppearanceOfFlyingSaucersMin,
                gameManager.GameConfiguration.TimeBetweenAppearanceOfFlyingSaucersMax);
        }

        private void OnChangeViewData(GameViewData viewData)
        {
            var lastControllers = new List<BaseFlyingSaucerController>();
            lastControllers.AddRange(currentFlyingSaucers);

            foreach (var controller in lastControllers)
            {
                var position = controller.transform.position;
                DestroyFlyingSaucer(controller);
                CreateFlyingSaucer(position);
            }
        }
    }
}