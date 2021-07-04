using System.Collections.Generic;
using AsteroidsTestProject.GameEngine.Asteroids;
using AsteroidsTestProject.GameEngine.Bullets;
using AsteroidsTestProject.GameEngine.FlyingSaucers;
using AsteroidsTestProject.GameEngine.Lasers;
using AsteroidsTestProject.GameEngine.Spaceships;

namespace AsteroidsTestProject.GameEngine
{
    public class GameManager : IGameManager
    {
        private GameState gameState;
        private IGameConfiguration gameConfiguration;
        private List<BaseManager> allManagers = new List<BaseManager>();
        private List<IUpdateManager> updateManagers = new List<IUpdateManager>();

        private SpaceshipManager spaceshipManager;
        private BulletsManager bulletsManager;
        private LaserManager laserManager;
        private AsteroidsManager asteroidsManager;
        private FlyingSaucerManager flyingSaucerManager;

        GameState IGameManager.GameState => gameState;
        IGameConfiguration IGameManager.GameConfiguration => gameConfiguration;
        IBulletsManager IGameManager.BulletsManager => bulletsManager;
        ILaserManager IGameManager.LaserManager => laserManager;
        IAsteroidsManager IGameManager.AsteroidsManager => asteroidsManager;
        IFlyingSaucerManager IGameManager.FlyingSaucerManager => flyingSaucerManager;
        ISpaceshipManager IGameManager.SpaceshipManager => spaceshipManager;

        public GameManager(IGameConfiguration gameConfiguration) 
        {
            this.gameConfiguration = gameConfiguration;

            gameState = new GameState();

            spaceshipManager = new SpaceshipManager();
            allManagers.Add(spaceshipManager);

            bulletsManager = new BulletsManager();
            allManagers.Add(bulletsManager);

            laserManager = new LaserManager();
            allManagers.Add(laserManager);

            asteroidsManager = new AsteroidsManager();
            allManagers.Add(asteroidsManager);

            flyingSaucerManager = new FlyingSaucerManager();
            allManagers.Add(flyingSaucerManager);

            foreach (var manager in allManagers)
            {
                manager.Init(this);

                if (manager is IUpdateManager updateManager)
                {
                    updateManagers.Add(updateManager);
                }
            }
        }

        public void Update(float deltaTime)
        {
            foreach (var manager in updateManagers)
            {
                manager.Update(deltaTime);
            }
        }

        void IGameManager.StartGame()
        {
            gameState.CurrentGamePart = GamePart.Battle;
            spaceshipManager.Create();
        }

        void IGameManager.SetGameOver()
        {
            if(gameState.CurrentGamePart != GamePart.Battle) return;
            
            gameState.CurrentGamePart = GamePart.GameOver;
        }

        void IGameManager.RestartGame()
        {
            gameState.Score = 0;
            bulletsManager.Reset();
            asteroidsManager.Reset();
            flyingSaucerManager.Reset();
            spaceshipManager.Reset();
            laserManager.Reset();
            gameState.CurrentGamePart = GamePart.Battle;
        }
    }
}