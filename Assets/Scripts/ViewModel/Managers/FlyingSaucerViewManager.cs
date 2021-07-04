using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.GameEngine.FlyingSaucers;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.ViewModel
{
    public class FlyingSaucerViewManager
    {
        private BidirectionalDictionary<BaseFlyingSaucerController, FlyingSaucer> currentFlyingSaucers
            = new BidirectionalDictionary<BaseFlyingSaucerController, FlyingSaucer>();

        private IFlyingSaucerManager flyingSaucerManager;
        private ISpaceInfo spaceInfo;
        private IGameObjectsPool gameObjectsPool;
        private GameViewConfiguration gameViewConfiguration;
        private ViewModeManager viewModeManager;
        private IGameManager gameManager;

        public FlyingSaucerViewManager(IGameManager gameManager, ISpaceInfo spaceInfo,
            GameViewConfiguration gameViewConfiguration, ViewModeManager viewModeManager,
            IGameObjectsPool gameObjectsPool)
        {
            this.gameManager = gameManager;
            this.spaceInfo = spaceInfo;
            this.gameViewConfiguration = gameViewConfiguration;
            this.viewModeManager = viewModeManager;
            this.gameObjectsPool = gameObjectsPool;

            flyingSaucerManager = gameManager.FlyingSaucerManager;

            flyingSaucerManager.OnCreateFlyingSaucer += CreateRandomSaucer;
            flyingSaucerManager.OnDestroyFlyingSaucer += DestroyFlyingSaucer;

            viewModeManager.onChangeViewData += OnChangeViewData;
        }

        private void CreateRandomSaucer(FlyingSaucer flyingSaucer)
        {
            var side = (Side)Random.Range(0, 4);

            var spawnPosition = spaceInfo.GetSpawnPositionOnSide(side,
                gameViewConfiguration.SpaceObjectsSpawnOffset);

            CreateFlyingSaucer(flyingSaucer, spawnPosition);
        }

        private void CreateFlyingSaucer(FlyingSaucer flyingSaucer, Vector3 spawnPosition)
        {
            var pref = viewModeManager.CurrentGameViewData.FlyingSaucerPref;

            var flyingSaucerController = gameObjectsPool.CreateGameObject(pref);
            currentFlyingSaucers.Add(flyingSaucerController, flyingSaucer);
            flyingSaucerController.transform.position = spawnPosition;
            flyingSaucerController.SetData(gameViewConfiguration.FlyingSaucerSpeed,
                gameManager);

            flyingSaucerController.onCrossedBordersOfScreen += FlyingSaucerOnCrossedBordersOfScreen;
            flyingSaucerController.onBulletHit += FlyingSaucerOnBulletHit;
            flyingSaucerController.onLaserHit += FlyingSaucerOnLaserHit;
        }

        private void DestroyFlyingSaucer(FlyingSaucer flyingSaucer)
        {
            var controller = currentFlyingSaucers[flyingSaucer];

            currentFlyingSaucers.Remove(controller);
            controller.onCrossedBordersOfScreen -= FlyingSaucerOnCrossedBordersOfScreen;
            controller.onBulletHit -= FlyingSaucerOnBulletHit;
            controller.onLaserHit -= FlyingSaucerOnLaserHit;
            gameObjectsPool.RemoveGameObject(controller);
        }

        private void FlyingSaucerOnCrossedBordersOfScreen(BaseFlyingSaucerController controller)
        {
            flyingSaucerManager.FlyingSaucerOnCrossedBordersOfScreen(currentFlyingSaucers[controller]);
        }

        private void FlyingSaucerOnBulletHit(BaseFlyingSaucerController controller)
        {
            flyingSaucerManager.FlyingSaucerOnBulletHit(currentFlyingSaucers[controller]);
        }

        private void FlyingSaucerOnLaserHit(BaseFlyingSaucerController controller)
        {
            flyingSaucerManager.FlyingSaucerOnLaserHit(currentFlyingSaucers[controller]);
        }

        private void OnChangeViewData(GameViewData viewData)
        {
            var lastItems = new BidirectionalDictionary<BaseFlyingSaucerController, FlyingSaucer>(currentFlyingSaucers);

            foreach (var kvItem in lastItems)
            {
                var position = kvItem.Key.transform.position;
                DestroyFlyingSaucer(kvItem.Value);
                CreateFlyingSaucer(kvItem.Value, position);
            }
        }
    }
}