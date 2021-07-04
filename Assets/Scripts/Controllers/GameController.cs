using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using AsteroidsTestProject.ViewModel;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class GameController : MonoBehaviour
    {
        private GameManager gameManager;
        private GameViewManager gameViewManager;

        private void Awake()
        {
            var gameConfiguration = SimpleInjector.Get<GameConfiguration>();
            var gameViewConfiguration = SimpleInjector.Get<GameViewConfiguration>();
            var spaceInfo = SimpleInjector.Get<ISpaceInfo>();
            var gameObjectsPool = SimpleInjector.Get<IGameObjectsPool>();

            gameManager = new GameManager(gameConfiguration);
            gameViewManager = new GameViewManager(gameManager, gameViewConfiguration, spaceInfo, gameObjectsPool);

            SimpleInjector.Add((IGameManager)gameManager);
        }

        private void Update()
        {
            gameManager.Update(Time.deltaTime);
        }
    }
}

