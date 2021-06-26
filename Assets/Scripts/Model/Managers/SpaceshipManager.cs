using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Model
{
    public class SpaceshipManager : BaseManager
    {
        private const float startRotationZ = 90f;
        
        private BaseSpaceshipController currentController;
        private IGameObjectsPool gameObjectsPool;

        public SpaceshipManager(IGameObjectsPool gameObjectsPool)
        {
            this.gameObjectsPool = gameObjectsPool;
        }

        public override void Init(IGameManager gameManager)
        {
            base.Init(gameManager);

            gameManager.ViewModeManager.onChangeViewData += OnChangeViewData;
        }

        public void Create(Vector3 position = default, float rotation = startRotationZ)
        {
            currentController = gameObjectsPool
                .CreateGameObject(gameManager.ViewModeManager.CurrentGameViewData.SpaceshipPref);
            currentController.transform.position = position;
            currentController.transform.localEulerAngles = new Vector3(0, 0, rotation);

            currentController.SetData(gameManager.GameConfiguration.SpaceshipSpeed,
                gameManager.GameConfiguration.SpaceshipTurningSpeed,
                gameManager);

            currentController.onCollidedEnemy += SpaceshipCollidedEnemy;
            currentController.onCrossedBordersOfScreen += SpaceshipCrossedBordersOfScreen;
        }

        public void Reset()
        {
            currentController.transform.position = default;
            currentController.transform.localEulerAngles = new Vector3(0, 0, startRotationZ);
        }

        private void OnChangeViewData(GameViewData viewData)
        {
            if (currentController == null) return;

            var position = currentController.transform.position;
            var rotation = currentController.transform.localEulerAngles.z;

            currentController.onCollidedEnemy -= SpaceshipCollidedEnemy;
            currentController.onCrossedBordersOfScreen -= SpaceshipCrossedBordersOfScreen;
            currentController.PrepareDestroy();
            gameObjectsPool.RemoveGameObject(currentController);
            Create(position, rotation);
        }

        private void SpaceshipCollidedEnemy()
        {
            gameManager.SetGameOver();
        }

        private void SpaceshipCrossedBordersOfScreen()
        {
            gameManager.SetGameOver();
        }
    }
}