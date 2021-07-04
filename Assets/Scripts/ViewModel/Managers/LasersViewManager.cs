using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.GameEngine.Lasers;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.ViewModel
{
    public class LasersViewManager
    {
        private ILaserManager laserManager;
        private IGameConfiguration gameConfiguration;
        private IGameObjectsPool gameObjectsPool;
        private GameViewConfiguration gameViewConfiguration;
        private ViewModeManager viewModeManager;
        private SpaceshipViewManager spaceshipViewManager;

        public LasersViewManager(IGameManager gameManager, ViewModeManager viewModeManager,
            GameViewConfiguration gameViewConfiguration, IGameObjectsPool gameObjectsPool,
            SpaceshipViewManager spaceshipViewManager)
        {
            this.gameViewConfiguration = gameViewConfiguration;
            this.viewModeManager = viewModeManager;
            this.spaceshipViewManager = spaceshipViewManager;
            this.gameObjectsPool = gameObjectsPool;

            laserManager = gameManager.LaserManager;

            laserManager.OnCreateLaser += CreateLaser;
        }

        public void CreateLaser()
        {
            Vector3 position = spaceshipViewManager.GetSpaceshipBulletsSpawnPosition;
            Vector3 direction = spaceshipViewManager.GetSpaceshipSpawnDirectrion;

            var laserController = gameObjectsPool
                .CreateGameObject(viewModeManager.CurrentGameViewData.LaserPref);
            laserController.transform.position = position;
            laserController.transform.localEulerAngles = direction;
            laserController.onDestroy += LaserOnDestroy;
            laserController.SetData(gameViewConfiguration.LaserDistance);
        }

        private void LaserOnDestroy(BaseLaserController laserController)
        {
            laserController.onDestroy -= LaserOnDestroy;
            gameObjectsPool.RemoveGameObject(laserController);
        }
    }
}