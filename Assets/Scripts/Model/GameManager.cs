using System.Collections.Generic;
using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Model
{
    public class GameManager : IGameManager
    {
        private GameState gameState;
        private GameConfiguration gameConfiguration;
        private List<BaseManager> allManagers = new List<BaseManager>();
        private List<IUpdateManager> updateManagers = new List<IUpdateManager>();

        private ViewModeManager viewModeManager;
        private InputManager inputManager;
        private SpaceshipManager spaceshipManager;
        private BulletsManager bulletsManager;
        private LaserManager laserManager;
        private AsteroidsManager asteroidsManager;
        private FlyingSaucerManager flyingSaucerManager;

        GameState IGameManager.GameState => gameState;
        InputManager IGameManager.InputManager => inputManager;
        ViewModeManager IGameManager.ViewModeManager => viewModeManager;
        GameConfiguration IGameManager.GameConfiguration => gameConfiguration;
        BulletsManager IGameManager.BulletsManager => bulletsManager;
        LaserManager IGameManager.LaserManager => laserManager;

        public GameManager(GameConfiguration gameConfiguration,
            GameViewConfiguration gameViewConfiguration,
            IGameObjectsPool gameObjectsPool,
            ISpaceInfo spaceInfo) 
        {
            this.gameConfiguration = gameConfiguration;

            gameState = new GameState();

            viewModeManager = new ViewModeManager(gameViewConfiguration);
            allManagers.Add(viewModeManager);

            inputManager = new InputManager();
            allManagers.Add(inputManager);

            spaceshipManager = new SpaceshipManager(gameObjectsPool);
            allManagers.Add(spaceshipManager);

            bulletsManager = new BulletsManager(gameObjectsPool);
            allManagers.Add(bulletsManager);

            laserManager = new LaserManager(gameObjectsPool);
            allManagers.Add(laserManager);

            asteroidsManager = new AsteroidsManager(gameObjectsPool, spaceInfo);
            allManagers.Add(asteroidsManager);

            flyingSaucerManager = new FlyingSaucerManager(gameObjectsPool, spaceInfo);
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

        public void Update()
        {
            foreach (var manager in updateManagers)
            {
                manager.Update();
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