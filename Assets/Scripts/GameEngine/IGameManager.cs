using AsteroidsTestProject.GameEngine.Asteroids;
using AsteroidsTestProject.GameEngine.Bullets;
using AsteroidsTestProject.GameEngine.FlyingSaucers;
using AsteroidsTestProject.GameEngine.Lasers;
using AsteroidsTestProject.GameEngine.Spaceships;

namespace AsteroidsTestProject.GameEngine
{
    public interface IGameManager
    {
        GameState GameState { get; }
        IGameConfiguration GameConfiguration { get; }
        IBulletsManager BulletsManager { get; }
        ILaserManager LaserManager { get; }
        IAsteroidsManager AsteroidsManager { get; }
        IFlyingSaucerManager FlyingSaucerManager { get; }
        ISpaceshipManager SpaceshipManager { get; }

        void StartGame();
        void SetGameOver();
        void RestartGame();
    }
}