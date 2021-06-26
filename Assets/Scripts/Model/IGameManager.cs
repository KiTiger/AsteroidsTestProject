using AsteroidsTestProject.Settings;

namespace AsteroidsTestProject.Model
{
    public interface IGameManager
    {
        GameState GameState { get; }
        InputManager InputManager { get; }
        ViewModeManager ViewModeManager { get; }
        GameConfiguration GameConfiguration { get; }
        BulletsManager BulletsManager { get; }
        LaserManager LaserManager { get; }

        void StartGame();
        void SetGameOver();
        void RestartGame();
    }
}