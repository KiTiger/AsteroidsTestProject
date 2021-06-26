using AsteroidsTestProject.Model;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public abstract class BaseSpaceshipController : MonoBehaviour, ISpaceship, ISpaceObject
    {
        [SerializeField] private Transform bulletsSpawnPosition;

        private float speed;
        private float turningSpeed;
        private IGameManager gameManager;
        private Vector3 moveVector;
        private Vector3 rotationVector;

        public Vector3 position => transform.position;

        SpaceObjectType ISpaceObject.SpaceObjectType => SpaceObjectType.Spaceship;

        public event Block onCollidedEnemy;
        public event Block onCrossedBordersOfScreen;

        public void SetData(float speed, float turningSpeed, IGameManager gameManager)
        {
            this.speed = speed;
            this.turningSpeed = turningSpeed;
            this.gameManager = gameManager;

            gameManager.InputManager.ShotButtonClick += ShotButtonClick;
            gameManager.InputManager.LaserButtonClick += LaserButtonClick;

            SimpleInjector.Add((ISpaceship)this);
        }

        public void PrepareDestroy()
        {
            gameManager.InputManager.ShotButtonClick -= ShotButtonClick;
            gameManager.InputManager.LaserButtonClick -= LaserButtonClick;
        }

        void ISpaceObject.CrossedBordersOfScreen()
        {
            onCrossedBordersOfScreen.SafeInvoke();
        }

        protected void Collided(GameObject colidedGameObject)
        {
            var spaceObject = colidedGameObject.GetComponent<ISpaceObject>();
            if (spaceObject == null) return;

            if (spaceObject.SpaceObjectType == SpaceObjectType.Asteroid
                || spaceObject.SpaceObjectType == SpaceObjectType.FlyingSaucer)
            {
                onCollidedEnemy.SafeInvoke();
            }
        }

        protected virtual void Update()
        {
            if (gameManager.GameState.CurrentGamePart != GamePart.Battle) return;

            rotationVector.z = -gameManager.InputManager.XAxis * turningSpeed * Time.deltaTime;
            transform.eulerAngles += rotationVector;

            moveVector.x = gameManager.InputManager.UpButtonPressed ? speed * Time.deltaTime : 0;
            transform.Translate(moveVector, Space.Self);
        }

        private void ShotButtonClick()
        {
            gameManager.BulletsManager.CreateBullet(bulletsSpawnPosition.position, transform.eulerAngles);
        }

        private void LaserButtonClick()
        {
            gameManager.LaserManager.CreateLaser(bulletsSpawnPosition.position, transform.eulerAngles);
        }

        private void OnDestroy()
        {
            PrepareDestroy();
        }
    }
}