using AsteroidsTestProject.Model;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public abstract class BaseAsteroidController : MonoBehaviour, ISpaceObject, ITakesHitObject
    {
        [SerializeField] private AsteroidTypeEnum asteroidType;

        private IGameManager gameManager;

        public AsteroidTypeEnum AsteroidType => asteroidType;
        public float Speed { get; private set; }
        public Vector3 Direction { get; private set; }

        SpaceObjectType ISpaceObject.SpaceObjectType => SpaceObjectType.Asteroid;

        public event Block<BaseAsteroidController> onCrossedBordersOfScreen;
        public event Block<BaseAsteroidController> onBulletHit;
        public event Block<BaseAsteroidController> onLaserHit;

        public void SetData(Vector3 direction, float speed, IGameManager gameManager)
        {
            Direction = direction;
            Speed = speed;
            this.gameManager = gameManager;

            Prepare();
        }

        void ITakesHitObject.BulletHit()
        {
            onBulletHit.SafeInvoke(this);
        }

        void ITakesHitObject.LaserHit()
        {
            onLaserHit.SafeInvoke(this);
        }

        void ISpaceObject.CrossedBordersOfScreen()
        {
            onCrossedBordersOfScreen.SafeInvoke(this);
        }

        protected abstract void Prepare();

        protected virtual void Update()
        {
            if (gameManager.GameState.CurrentGamePart != GamePart.Battle) return;
            
            transform.Translate(Direction * Speed * Time.deltaTime, Space.World);
        }
    }
}