using AsteroidsTestProject.Model;
using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class GameController : MonoBehaviour
    {
        private GameManager gameManager;

        private void Awake()
        {
            var gameConfiguration = SimpleInjector.Get<GameConfiguration>();
            var gameViewConfiguration = SimpleInjector.Get<GameViewConfiguration>();
            var gameObjectsPool = SimpleInjector.Get<IGameObjectsPool>();
            var spaceInfo = SimpleInjector.Get<ISpaceInfo>();

            gameManager = new GameManager(gameConfiguration, gameViewConfiguration,
                gameObjectsPool, spaceInfo);

            SimpleInjector.Add((IGameManager)gameManager);
        }

        private void Update()
        {
            gameManager.Update();
        }
    }
}

