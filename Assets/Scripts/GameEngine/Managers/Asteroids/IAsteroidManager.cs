using AsteroidsTestProject.GameEngine.Utils;

namespace AsteroidsTestProject.GameEngine.Asteroids
{
    public interface IAsteroidsManager
    {
        event Block<Asteroid> OnCreateBigAsteroid;
        event Block<Asteroid, Asteroid> OnCreateSmallAsteroid;
        event Block<Asteroid> OnDestroyAsteroid;

        void AsteroidCrossedBordersOfScreen(Asteroid asteroid);
        void AsteroidOnBulletHit(Asteroid asteroid);
        void AsteroidOnLaserHit(Asteroid asteroid);
    }
}