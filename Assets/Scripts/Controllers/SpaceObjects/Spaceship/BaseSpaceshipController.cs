using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.GameEngine.Utils;
using AsteroidsTestProject.Utils;
using AsteroidsTestProject.ViewModel;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public abstract class BaseSpaceshipController : MonoBehaviour, ISpaceship, ISpaceObject
    {
        [SerializeField] private Transform bulletsSpawnPosition;

        private float speed;
        private float turningSpeed;
        private IGameManager gameManager;
        private InputManager inputManager;
        private Vector3 moveVector;
        private Vector3 rotationVector;

        public Vector3 position => transform.position;

        public Vector3 GetBulletsSpawnPosition => bulletsSpawnPosition.position;
        public Vector3 GetBulletsSpawnDirectrion => transform.eulerAngles;


        SpaceObjectType ISpaceObject.SpaceObjectType => SpaceObjectType.Spaceship;

        public event Block onCollidedEnemy;
        public event Block onCrossedBordersOfScreen;

        public void SetData(float speed, float turningSpeed, IGameManager gameManager,
            InputManager inputManager)
        {
            this.speed = speed;
            this.turningSpeed = turningSpeed;
            this.gameManager = gameManager;
            this.inputManager = inputManager;

            inputManager.ShotButtonClick += ShotButtonClick;
            inputManager.LaserButtonClick += LaserButtonClick;

            SimpleInjector.Add((ISpaceship)this);
        }

        public void PrepareDestroy()
        {
            inputManager.ShotButtonClick -= ShotButtonClick;
            inputManager.LaserButtonClick -= LaserButtonClick;
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

            rotationVector.z = -inputManager.XAxis * turningSpeed * Time.deltaTime;
            transform.eulerAngles += rotationVector;

            moveVector.x = inputManager.UpButtonPressed ? speed * Time.deltaTime : 0;
            transform.Translate(moveVector, Space.Self);
        }

        private void ShotButtonClick()
        {
            gameManager.BulletsManager.CreateBullet();
        }

        private void LaserButtonClick()
        {
            gameManager.LaserManager.CreateLaser();
        }

        private void OnDestroy()
        {
            PrepareDestroy();
        }
    }
}