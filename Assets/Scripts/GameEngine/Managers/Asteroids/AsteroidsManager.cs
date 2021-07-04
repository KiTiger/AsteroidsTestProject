using System.Collections.Generic;
using AsteroidsTestProject.GameEngine.Utils;

namespace AsteroidsTestProject.GameEngine.Asteroids
{
    public class AsteroidsManager : BaseManager, IUpdateManager, IAsteroidsManager
    {
        private List<Asteroid> currentAsteroids = new List<Asteroid>();
        private float spawnTimer;

        public event Block<Asteroid> OnCreateBigAsteroid;
        public event Block<Asteroid, Asteroid> OnCreateSmallAsteroid;
        public event Block<Asteroid> OnDestroyAsteroid;

        public override void Init(IGameManager gameManager)
        {
            base.Init(gameManager);
        }

        public void Reset()
        {
            ResetTimer();
            
            var lastControllers = new List<Asteroid>();
            lastControllers.AddRange(currentAsteroids);

            foreach (var controller in lastControllers)
            {
                DestroyAsteroid(controller);
            }
        }

        void IAsteroidsManager.AsteroidCrossedBordersOfScreen(Asteroid asteroid)
        {
            DestroyAsteroid(asteroid);
        }

        void IAsteroidsManager.AsteroidOnBulletHit(Asteroid asteroid)
        {
            CalculatePoints(asteroid);

            if (asteroid.AsteroidType == AsteroidTypeEnum.Big)
            {
                CreateSmallAsteroids(asteroid);
            }

            DestroyAsteroid(asteroid);
        }

        void IAsteroidsManager.AsteroidOnLaserHit(Asteroid asteroid)
        {
            CalculatePoints(asteroid);
            DestroyAsteroid(asteroid);
        }

        void IUpdateManager.Update(float deltaTime)
        {
            if (gameManager.GameState.CurrentGamePart != GamePart.Battle) return;

            spawnTimer -= deltaTime;

            if (spawnTimer <= 0)
            {
                CreateBigAsteroid();
                ResetTimer();
            }
        }

        private void CreateBigAsteroid()
        {
            CreateAsteroid(AsteroidTypeEnum.Big);
        }

        private void CreateSmallAsteroids(Asteroid parrentAsteroid)
        {
            for (int i = 0; i < gameManager.GameConfiguration.NumberOfSmallAsteroidSpawn; i++)
            {
                CreateAsteroid(AsteroidTypeEnum.Small, parrentAsteroid);
            }
        }

        private void CreateAsteroid(AsteroidTypeEnum asteroidType, Asteroid parrentAsteroid = null)
        {
            var asteroid = new Asteroid(asteroidType);
            currentAsteroids.Add(asteroid);
            if (asteroidType == AsteroidTypeEnum.Big) OnCreateBigAsteroid.SafeInvoke(asteroid);
            else OnCreateSmallAsteroid(asteroid, parrentAsteroid);
        }

        private void CalculatePoints(Asteroid asteroid)
        {
            var addPoints = asteroid.AsteroidType == AsteroidTypeEnum.Big
                ? gameManager.GameConfiguration.PointsForBigAsteroid
                : gameManager.GameConfiguration.PointsForSmallAsteroid;
            gameManager.GameState.Score += addPoints;
        }

        private void DestroyAsteroid(Asteroid asteroid)
        {
            OnDestroyAsteroid.SafeInvoke(asteroid);
            currentAsteroids.Remove(asteroid);
        }

        private void ResetTimer()
        {
            spawnTimer = RandomUtils.Range(
                gameManager.GameConfiguration.TimeBetweenAppearanceOfAsteroidsMin,
                gameManager.GameConfiguration.TimeBetweenAppearanceOfAsteroidsMax);
        }
    }
}