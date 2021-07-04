using System.Collections.Generic;
using AsteroidsTestProject.GameEngine.Utils;

namespace AsteroidsTestProject.GameEngine.FlyingSaucers
{
    public class FlyingSaucerManager : BaseManager, IUpdateManager, IFlyingSaucerManager
    {
        private List<FlyingSaucer> currentFlyingSaucers = new List<FlyingSaucer>();
        private float spawnTimer;

        public event Block<FlyingSaucer> OnCreateFlyingSaucer;
        public event Block<FlyingSaucer> OnDestroyFlyingSaucer;

        public void Reset()
        {
            ResetTimer();

            var lastControllers = new List<FlyingSaucer>();
            lastControllers.AddRange(currentFlyingSaucers);

            foreach (var controller in lastControllers)
            {
                DestroyFlyingSaucer(controller);
            }
        }

        void IUpdateManager.Update(float deltaTime)
        {
            if (gameManager.GameState.CurrentGamePart != GamePart.Battle) return;

            spawnTimer -= deltaTime;

            if (spawnTimer <= 0)
            {
                CreateFlyingSaucer();
                ResetTimer();
            }
        }

        void IFlyingSaucerManager.FlyingSaucerOnCrossedBordersOfScreen(FlyingSaucer flyingSaucer)
        {
            DestroyFlyingSaucer(flyingSaucer);
        }

        void IFlyingSaucerManager.FlyingSaucerOnBulletHit(FlyingSaucer flyingSaucer)
        {
            AddPoints();

            DestroyFlyingSaucer(flyingSaucer);
        }

        void IFlyingSaucerManager.FlyingSaucerOnLaserHit(FlyingSaucer flyingSaucer)
        {
            AddPoints();

            DestroyFlyingSaucer(flyingSaucer);
        }

        private void CreateFlyingSaucer()
        {
            var flyingSaucer = new FlyingSaucer();
            currentFlyingSaucers.Add(flyingSaucer);
            OnCreateFlyingSaucer.SafeInvoke(flyingSaucer);
        }

        private void AddPoints()
        {
            gameManager.GameState.Score += gameManager.GameConfiguration.PointsForFlyingSaucer; ;
        }

        private void DestroyFlyingSaucer(FlyingSaucer flyingSaucer)
        {
            OnDestroyFlyingSaucer.SafeInvoke(flyingSaucer);
            currentFlyingSaucers.Remove(flyingSaucer);
        }

        private void ResetTimer()
        {
            spawnTimer = RandomUtils.Range(
                gameManager.GameConfiguration.TimeBetweenAppearanceOfFlyingSaucersMin,
                gameManager.GameConfiguration.TimeBetweenAppearanceOfFlyingSaucersMax);
        }
    }
}