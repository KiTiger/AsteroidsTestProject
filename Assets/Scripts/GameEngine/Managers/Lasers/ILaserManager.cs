using AsteroidsTestProject.GameEngine.Utils;

namespace AsteroidsTestProject.GameEngine.Lasers
{
    public interface ILaserManager
    {
        int NumberOfLasers { get; }
        float LaserCreateTimer { get; }
        float LaserCreateProgress { get; }

        event Block<int> OnChangeNumberOfLasers;
        event Block OnCreateLaser;

        void CreateLaser();
    }
}