using AsteroidsTestProject.Model;
using AsteroidsTestProject.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsTestProject.Controllers.UI
{
    public class StartUIController : MonoBehaviour
    {
        [SerializeField] private Button startButton;

        private IGameManager gameManager;

        private void Start()
        {
            startButton.onClick.AddListener(StartButtonClick);

            gameManager = SimpleInjector.Get<IGameManager>();

            gameManager.GameState.OnChangeGamePart += OnChangeGamePart;
            OnChangeGamePart(gameManager.GameState.CurrentGamePart);
        }

        private void StartButtonClick()
        {
            if(gameManager.GameState.CurrentGamePart != GamePart.Start) return;

            gameManager.StartGame();
        }

        private void OnChangeGamePart(GamePart gamePart)
        {
            gameObject.SetActive(gamePart == GamePart.Start);
        }
    }
}
