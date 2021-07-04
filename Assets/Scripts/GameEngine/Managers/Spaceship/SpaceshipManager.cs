using AsteroidsTestProject.GameEngine.Utils;

namespace AsteroidsTestProject.GameEngine.Spaceships
{
    public class SpaceshipManager : BaseManager, ISpaceshipManager
    {
        private Spaceship currentSpaceship;

        public event Block<Spaceship> OnCreateSpaceship;
        public event Block<Spaceship> OnResetSpaceship;

        public void Create()
        {
            OnCreateSpaceship.SafeInvoke(currentSpaceship);
        }

        public void Reset()
        {
            OnResetSpaceship.SafeInvoke(currentSpaceship);
        }

        void ISpaceshipManager.SpaceshipCollidedEnemy()
        {
            gameManager.SetGameOver();
        }

        void ISpaceshipManager.SpaceshipCrossedBordersOfScreen()
        {
            gameManager.SetGameOver();
        }
    }
}