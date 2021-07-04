using System.Collections.Generic;
using AsteroidsTestProject.GameEngine.Utils;

namespace AsteroidsTestProject.GameEngine.Bullets
{
    public class BulletsManager : BaseManager, IBulletsManager
    {
        private List<Bullet> currentBullets = new List<Bullet>();

        public event Block<Bullet> OnCreateBullet;
        public event Block<Bullet> OnDestroyBullet;

        public void CreateBullet()
        {
            var bullet = new Bullet();
            currentBullets.Add(bullet);
            OnCreateBullet.SafeInvoke(bullet);
        }

        public void Reset()
        {
            var lastControllers = new List<Bullet>();
            lastControllers.AddRange(currentBullets);

            foreach (var controller in lastControllers)
            {
                DestroyBullet(controller);
            }
        }

        void IBulletsManager.BulletOnCrossedBordersOfScreen(Bullet bullet)
        {
            DestroyBullet(bullet);
        }

        void IBulletsManager.BulletOnCollided(Bullet bullet)
        {
            DestroyBullet(bullet);
        }

        private void DestroyBullet(Bullet bullet)
        {
            OnDestroyBullet.SafeInvoke(bullet);
            currentBullets.Remove(bullet);
        }
    }
}