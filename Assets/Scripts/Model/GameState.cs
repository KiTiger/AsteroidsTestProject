using AsteroidsTestProject.Utils;

namespace AsteroidsTestProject.Model
{
    public class GameState
    {
        private GamePart currentGamePart;
        private int score;

        public GamePart CurrentGamePart
        {
            get => currentGamePart;
            set
            {
                currentGamePart = value;
                OnChangeGamePart.SafeInvoke(currentGamePart);
            }
        }
        public int Score
        {
            get => score;
            set
            {
                score = value;
                OnChangeScore.SafeInvoke(score);
            }
        }

        public event Block<GamePart> OnChangeGamePart;
        public event Block<int> OnChangeScore;

        public GameState()
        {
            currentGamePart = GamePart.Start;
        }
    }
}