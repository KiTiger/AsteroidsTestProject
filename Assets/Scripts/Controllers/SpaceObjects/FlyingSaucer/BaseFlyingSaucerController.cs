using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.GameEngine.Utils;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public abstract class BaseFlyingSaucerController : MonoBehaviour, ISpaceObject, ITakesHitObject
    {
        private float speed;
        private ISpaceship spaceship;
        private IGameManager gameManager;

        SpaceObjectType ISpaceObject.SpaceObjectType => SpaceObjectType.FlyingSaucer;

        public event Block<BaseFlyingSaucerController> onCrossedBordersOfScreen;
        public event Block<BaseFlyingSaucerController> onBulletHit;
        public event Block<BaseFlyingSaucerController> onLaserHit;

        public void SetData(float speed, IGameManager gameManager)
        {
            this.speed = speed;
            this.gameManager = gameManager;
            spaceship = SimpleInjector.Get<ISpaceship>();
        }

        void ISpaceObject.CrossedBordersOfScreen() 
        { 
            onCrossedBordersOfScreen.SafeInvoke(this);
        }

        void ITakesHitObject.BulletHit()
        {
            onBulletHit.SafeInvoke(this);
        }

        void ITakesHitObject.LaserHit()
        {
            onLaserHit.SafeInvoke(this);
        }

        private void Update()
        {
            if (gameManager.GameState.CurrentGamePart != GamePart.Battle) return;

            var direction = (spaceship.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}