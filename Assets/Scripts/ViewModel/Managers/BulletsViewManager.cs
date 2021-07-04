using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.GameEngine.Bullets;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.ViewModel
{
    public class BulletsViewManager
    {
        private BidirectionalDictionary<BaseBulletController, Bullet> currentBullets
            = new BidirectionalDictionary<BaseBulletController, Bullet>();

        private IBulletsManager bulletsManager;
        private IGameObjectsPool gameObjectsPool;
        private GameViewConfiguration gameViewConfiguration;
        private ViewModeManager viewModeManager;
        private SpaceshipViewManager spaceshipViewManager;

        public BulletsViewManager(IGameManager gameManager, ISpaceInfo spaceInfo,
            GameViewConfiguration gameViewConfiguration, ViewModeManager viewModeManager,
            IGameObjectsPool gameObjectsPool, SpaceshipViewManager spaceshipViewManager)
        {
            this.gameViewConfiguration = gameViewConfiguration;
            this.viewModeManager = viewModeManager;
            this.gameObjectsPool = gameObjectsPool;
            this.spaceshipViewManager = spaceshipViewManager;

            bulletsManager = gameManager.BulletsManager;

            bulletsManager.OnCreateBullet += CreateBullet;
            bulletsManager.OnDestroyBullet += DestroyBullet;

            viewModeManager.onChangeViewData += OnChangeViewData;
        }

        public void CreateBullet(Bullet bullet)
        {
            CreateBullet(bullet, spaceshipViewManager.GetSpaceshipBulletsSpawnPosition,
                spaceshipViewManager.GetSpaceshipSpawnDirectrion);
        }

        public void CreateBullet(Bullet bullet, Vector3 position, Vector3 direction)
        {
            var bulletController = gameObjectsPool
                .CreateGameObject(viewModeManager.CurrentGameViewData.BulletPref);
            bulletController.transform.position = position;
            bulletController.transform.localEulerAngles = direction;
            bulletController.SetData(gameViewConfiguration.BulletsSpeed);
            bulletController.onCrossedBordersOfScreen += BulletOnCrossedBordersOfScreen;
            bulletController.onCollided += BulletOnCollided;

            currentBullets.Add(bulletController, bullet);
        }
        private void DestroyBullet(Bullet bullet)
        {
            var bulletController = currentBullets[bullet];
            currentBullets.Remove(bulletController);
            bulletController.onCrossedBordersOfScreen -= BulletOnCrossedBordersOfScreen;
            bulletController.onCollided -= BulletOnCollided;
            gameObjectsPool.RemoveGameObject(bulletController);
        }

        private void BulletOnCrossedBordersOfScreen(BaseBulletController bulletController)
        {
            bulletsManager.BulletOnCrossedBordersOfScreen(currentBullets[bulletController]);
        }

        private void BulletOnCollided(BaseBulletController bulletController)
        {
            bulletsManager.BulletOnCollided(currentBullets[bulletController]);
        }

        private void OnChangeViewData(GameViewData viewData)
        {
            var lastItems = new BidirectionalDictionary<BaseBulletController, Bullet>(currentBullets);

            foreach (var kvItem in lastItems)
            {
                var position = kvItem.Key.transform.position;
                var direction = kvItem.Key.transform.localEulerAngles;
                DestroyBullet(kvItem.Value);
                CreateBullet(kvItem.Value, position, direction);
            }
        }
    }
}