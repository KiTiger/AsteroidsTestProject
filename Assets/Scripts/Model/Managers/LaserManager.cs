using System.Collections.Generic;
using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Model
{
    public class LaserManager : BaseManager, IUpdateManager
    {
        private float laserCreateTimer;
        private int numberOfLasers;
        private IGameObjectsPool gameObjectsPool;

        public int NumberOfLasers
        {
            get => numberOfLasers;
            private set
            {
                numberOfLasers = value;
                OnChangeNumberOfLasers.SafeInvoke(numberOfLasers);
            }
        }
        public float LaserCreateTimer => laserCreateTimer;
        public float LaserCreateProgress => 
            laserCreateTimer / gameManager.GameConfiguration.CreateLaserTime;

        public event Block<int> OnChangeNumberOfLasers;

        public LaserManager(IGameObjectsPool gameObjectsPool)
        {
            this.gameObjectsPool = gameObjectsPool;
        }

        public override void Init(IGameManager gameManager)
        {
            base.Init(gameManager);

            Reset();
        }

        public void CreateLaser(Vector3 position, Vector3 direction)
        {
            if (NumberOfLasers == 0) return;
            NumberOfLasers--;

            var laserController = gameObjectsPool
                .CreateGameObject(gameManager.ViewModeManager.CurrentGameViewData.LaserPref);
            laserController.transform.position = position;
            laserController.transform.localEulerAngles = direction;
            laserController.onDestroy += LaserOnDestroy;
            laserController.SetData(gameManager.GameConfiguration.LaserDistance);
            if (laserCreateTimer <= 0) StartLaserTimer();
        }

        public void Reset()
        {
            laserCreateTimer = 0;
            NumberOfLasers = gameManager.GameConfiguration.NumberOfLasers;
        }

        void IUpdateManager.Update()
        {
            if (gameManager.GameState.CurrentGamePart != GamePart.Battle) return;

            if (NumberOfLasers < gameManager.GameConfiguration.NumberOfLasers)
            {
                laserCreateTimer -= Time.deltaTime;

                if (laserCreateTimer < 0)
                {
                    NumberOfLasers++;
                    StartLaserTimer();
                }
            }
        }

        private void LaserOnDestroy(BaseLaserController laserController)
        {
            laserController.onDestroy -= LaserOnDestroy;
            gameObjectsPool.RemoveGameObject(laserController);
        }

        private void StartLaserTimer()
        {
            laserCreateTimer = gameManager.GameConfiguration.CreateLaserTime;
        }
    }
}