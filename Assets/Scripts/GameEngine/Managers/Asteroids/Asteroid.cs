namespace AsteroidsTestProject.GameEngine.Asteroids
{
    public class Asteroid
    {
        private AsteroidTypeEnum asteroidType;

        public AsteroidTypeEnum AsteroidType => asteroidType;

        public Asteroid(AsteroidTypeEnum asteroidType)
        {
            this.asteroidType = asteroidType;
        }
    }
}