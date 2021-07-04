using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsTestProject.Controllers.UI
{
    public class GameOverUIController : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Button restartButton;

        private IGameManager gameManager;

        private void Start()
        {
            restartButton.onClick.AddListener(RestartButtonClick);
            gameManager = SimpleInjector.Get<IGameManager>();

            gameManager.GameState.OnChangeGamePart += OnChangeGamePart;
            OnChangeGamePart(gameManager.GameState.CurrentGamePart);

        }

        private void OnChangeGamePart(GamePart gamePart)
        {
            gameObject.SetActive(gamePart == GamePart.GameOver);

            if (gamePart == GamePart.GameOver)
            {
                scoreText.text = $"score: {gameManager.GameState.Score}";
            }
        }

        private void RestartButtonClick()
        {
            if (gameManager.GameState.CurrentGamePart != GamePart.GameOver) return;

            gameManager.RestartGame();
        }

    }
}
