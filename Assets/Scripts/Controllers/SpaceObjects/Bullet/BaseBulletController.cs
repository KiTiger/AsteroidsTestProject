using AsteroidsTestProject.GameEngine.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public abstract class BaseBulletController : MonoBehaviour, ISpaceObject
    {
        private float speed;

        SpaceObjectType ISpaceObject.SpaceObjectType => SpaceObjectType.Bullet;

        public event Block<BaseBulletController> onCrossedBordersOfScreen;
        public event Block<BaseBulletController> onCollided;

        public void SetData(float speed)
        {
            this.speed = speed;
        }

        void ISpaceObject.CrossedBordersOfScreen()
        {
            onCrossedBordersOfScreen.SafeInvoke(this);
        }

        protected void Collided(GameObject colidedGameObject)
        {
            var takesHitObject = colidedGameObject.GetComponent<ITakesHitObject>();
            if (takesHitObject == null) return;
            onCollided.SafeInvoke(this);
            takesHitObject.BulletHit();
        }

        private void Update()
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
        }
    }
}