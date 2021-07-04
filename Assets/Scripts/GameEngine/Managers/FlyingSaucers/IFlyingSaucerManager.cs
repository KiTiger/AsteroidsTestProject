using AsteroidsTestProject.GameEngine.Utils;

namespace AsteroidsTestProject.GameEngine.FlyingSaucers
{
    public interface IFlyingSaucerManager
    {
        event Block<FlyingSaucer> OnCreateFlyingSaucer;
        event Block<FlyingSaucer> OnDestroyFlyingSaucer;

        void FlyingSaucerOnCrossedBordersOfScreen(FlyingSaucer flyingSaucer);
        void FlyingSaucerOnBulletHit(FlyingSaucer flyingSaucer);
        void FlyingSaucerOnLaserHit(FlyingSaucer flyingSaucer);
    }
}