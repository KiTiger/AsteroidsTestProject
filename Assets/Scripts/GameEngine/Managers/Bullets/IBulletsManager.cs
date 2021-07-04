using AsteroidsTestProject.GameEngine.Utils;

namespace AsteroidsTestProject.GameEngine.Bullets
{
    public interface IBulletsManager
    {
        event Block<Bullet> OnCreateBullet;
        event Block<Bullet> OnDestroyBullet;

        void CreateBullet();
        void BulletOnCrossedBordersOfScreen(Bullet bullet);
        void BulletOnCollided(Bullet bullet);
    }
}