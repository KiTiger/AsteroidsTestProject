using AsteroidsTestProject.Model;
using AsteroidsTestProject.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsTestProject.Controllers.UI
{
    public class GameUIController : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text numberOfLasersText;
        [SerializeField] private Slider laserTimer;

        private IGameManager gameManager;

        private void Start()
        {
            gameManager = SimpleInjector.Get<IGameManager>();

            gameManager.GameState.OnChangeGamePart += OnChangeGamePart;
            OnChangeGamePart(gameManager.GameState.CurrentGamePart);

            gameManager.GameState.OnChangeScore += OnChangeScore;
            OnChangeScore(gameManager.GameState.Score);

            gameManager.LaserManager.OnChangeNumberOfLasers += OnChangeNumberOfLasers;
            OnChangeNumberOfLasers(gameManager.LaserManager.NumberOfLasers);
        }

        private void OnChangeGamePart(GamePart gamePart)
        {
            gameObject.SetActive(gamePart == GamePart.Battle);
        }

        private void OnChangeScore(int score)
        {
            scoreText.text = $"score: {score}";
        }

        private void OnChangeNumberOfLasers(int numberOfLasers)
        {
            numberOfLasersText.text = $"{numberOfLasers}";
        }

        private void Update()
        {
            laserTimer.value = 1 - gameManager.LaserManager.LaserCreateProgress;
        }
    }
}
