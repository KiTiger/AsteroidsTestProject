using AsteroidsTestProject.GameEngine.Utils;

namespace AsteroidsTestProject.GameEngine.Lasers
{
    public class LaserManager : BaseManager, IUpdateManager, ILaserManager
    {
        private float laserCreateTimer;
        private int numberOfLasers;

        public int NumberOfLasers
        {
            get => numberOfLasers;
            private set
            {
                numberOfLasers = value;
                OnChangeNumberOfLasers.SafeInvoke(numberOfLasers);
            }
        }
        float ILaserManager.LaserCreateTimer => laserCreateTimer;
        float ILaserManager.LaserCreateProgress =>
            laserCreateTimer / gameManager.GameConfiguration.CreateLaserTime;

        public event Block<int> OnChangeNumberOfLasers;
        public event Block OnCreateLaser;

        public override void Init(IGameManager gameManager)
        {
            base.Init(gameManager);

            Reset();
        }

        void ILaserManager.CreateLaser()
        {
            if (NumberOfLasers == 0) return;
            
            OnCreateLaser.SafeInvoke();

            NumberOfLasers--;
            if (laserCreateTimer <= 0) StartLaserTimer();
        }

        public void Reset()
        {
            laserCreateTimer = 0;
            NumberOfLasers = gameManager.GameConfiguration.NumberOfLasers;
        }

        void IUpdateManager.Update(float deltaTime)
        {
            if (gameManager.GameState.CurrentGamePart != GamePart.Battle) return;

            if (NumberOfLasers < gameManager.GameConfiguration.NumberOfLasers)
            {
                laserCreateTimer -= deltaTime;

                if (laserCreateTimer < 0)
                {
                    NumberOfLasers++;
                    StartLaserTimer();
                }
            }
        }

        private void StartLaserTimer()
        {
            laserCreateTimer = gameManager.GameConfiguration.CreateLaserTime;
        }
    }
}