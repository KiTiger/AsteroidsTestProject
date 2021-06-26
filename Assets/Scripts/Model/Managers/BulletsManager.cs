using System.Collections.Generic;
using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Model
{
    public class BulletsManager : BaseManager
    {
        private List<BaseBulletController> currentBullets = new List<BaseBulletController>();
        private IGameObjectsPool gameObjectsPool;

        public BulletsManager(IGameObjectsPool gameObjectsPool)
        {
            this.gameObjectsPool = gameObjectsPool;
        }

        public override void Init(IGameManager gameManager)
        {
            base.Init(gameManager);

            gameManager.ViewModeManager.onChangeViewData += OnChangeViewData;
        }

        public void CreateBullet(Vector3 position, Vector3 direction)
        {
            var bulletController = gameObjectsPool
                .CreateGameObject(gameManager.ViewModeManager.CurrentGameViewData.BulletPref);
            bulletController.transform.position = position;
            bulletController.transform.localEulerAngles = direction;
            bulletController.SetData(gameManager.GameConfiguration.BulletsSpeed);
            bulletController.onCrossedBordersOfScreen += BulletOnCrossedBordersOfScreen;
            bulletController.onCollided += BulletOnCollided;

            currentBullets.Add(bulletController);
        }

        public void Reset()
        {
            var lastControllers = new List<BaseBulletController>();
            lastControllers.AddRange(currentBullets);

            foreach (var controller in lastControllers)
            {
                DestroyBullet(controller);
            }
        }

        private void BulletOnCrossedBordersOfScreen(BaseBulletController bulletController)
        {
            DestroyBullet(bulletController);
        }

        private void BulletOnCollided(BaseBulletController bulletController)
        {
            DestroyBullet(bulletController);
        }

        private void DestroyBullet(BaseBulletController bulletController)
        {
            currentBullets.Remove(bulletController);
            bulletController.onCrossedBordersOfScreen -= BulletOnCrossedBordersOfScreen;
            bulletController.onCollided -= BulletOnCollided;
            gameObjectsPool.RemoveGameObject(bulletController);
        }

        private void OnChangeViewData(GameViewData viewData)
        {
            var lastControllers = new List<BaseBulletController>();
            lastControllers.AddRange(currentBullets);

            foreach (var controller in lastControllers)
            {
                var position = controller.transform.position;
                var direction = controller.transform.localEulerAngles;
                DestroyBullet(controller);
                CreateBullet(position, direction);
            }
        }
    }
}