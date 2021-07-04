using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;

namespace AsteroidsTestProject.ViewModel
{
    public class GameViewManager
    {
        private ViewModeManager viewModeManager;
        private AsteroidsViewManager asteroidsViewManager;
        private FlyingSaucerViewManager flyingSaucerViewManager;
        private SpaceshipViewManager spaceshipViewManager;
        private BulletsViewManager bulletsViewManager;
        private LasersViewManager lasersViewManager;
        private InputManager inputManager;

        public GameViewManager(IGameManager gameManager, GameViewConfiguration gameViewConfiguration,
            ISpaceInfo spaceInfo, IGameObjectsPool gameObjectsPool)
        {
            inputManager = new InputManager();
            viewModeManager = new ViewModeManager(inputManager, gameViewConfiguration);
            asteroidsViewManager = new AsteroidsViewManager(gameManager, spaceInfo, gameViewConfiguration,
                viewModeManager, gameObjectsPool);
            flyingSaucerViewManager = new FlyingSaucerViewManager(gameManager, spaceInfo, gameViewConfiguration,
                viewModeManager, gameObjectsPool);
            spaceshipViewManager = new SpaceshipViewManager(gameManager, gameViewConfiguration,
                viewModeManager, gameObjectsPool, inputManager);
            bulletsViewManager = new BulletsViewManager(gameManager, spaceInfo, gameViewConfiguration,
                viewModeManager, gameObjectsPool, spaceshipViewManager);
            lasersViewManager = new LasersViewManager(gameManager, viewModeManager, gameViewConfiguration, 
                gameObjectsPool, spaceshipViewManager);
        }
    }
}