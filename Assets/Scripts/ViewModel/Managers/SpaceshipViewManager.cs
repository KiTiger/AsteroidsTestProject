using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.GameEngine.Spaceships;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.ViewModel
{
    public class SpaceshipViewManager
    {
        private const float startRotationZ = 90f;

        private BaseSpaceshipController currentController;

        private ISpaceshipManager spaceshipManager;
        private IGameObjectsPool gameObjectsPool;
        private GameViewConfiguration gameViewConfiguration;
        private ViewModeManager viewModeManager;
        private IGameManager gameManager;
        private InputManager inputManager;

        public Vector3 GetSpaceshipBulletsSpawnPosition => currentController.GetBulletsSpawnPosition;
        public Vector3 GetSpaceshipSpawnDirectrion => currentController.GetBulletsSpawnDirectrion;

        public SpaceshipViewManager(IGameManager gameManager,
            GameViewConfiguration gameViewConfiguration, ViewModeManager viewModeManager,
            IGameObjectsPool gameObjectsPool, InputManager inputManager)
        {
            this.gameManager = gameManager;
            this.gameViewConfiguration = gameViewConfiguration;
            this.viewModeManager = viewModeManager;
            this.gameObjectsPool = gameObjectsPool;
            this.inputManager = inputManager;

            spaceshipManager = gameManager.SpaceshipManager;

            spaceshipManager.OnCreateSpaceship += Create;
            spaceshipManager.OnResetSpaceship += Reset;

            viewModeManager.onChangeViewData += OnChangeViewData;
        }

        private void Create(Spaceship spaceship)
        {
            Create(default, startRotationZ);
        }

        private void Create(Vector3 position, float rotation)
        {
            currentController = gameObjectsPool
                .CreateGameObject(viewModeManager.CurrentGameViewData.SpaceshipPref);
            currentController.transform.position = position;
            currentController.transform.localEulerAngles = new Vector3(0, 0, rotation);

            currentController.SetData(gameViewConfiguration.SpaceshipSpeed,
                gameViewConfiguration.SpaceshipTurningSpeed,
                gameManager, inputManager);

            currentController.onCollidedEnemy += SpaceshipCollidedEnemy;
            currentController.onCrossedBordersOfScreen += SpaceshipCrossedBordersOfScreen;
        }

        private void Reset(Spaceship spaceship)
        {
            currentController.transform.position = default;
            currentController.transform.localEulerAngles = new Vector3(0, 0, startRotationZ);
        }

        private void SpaceshipCollidedEnemy()
        {
            spaceshipManager.SpaceshipCollidedEnemy();
        }

        private void SpaceshipCrossedBordersOfScreen()
        {
            spaceshipManager.SpaceshipCrossedBordersOfScreen();
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
    }
}