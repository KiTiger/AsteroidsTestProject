using AsteroidsTestProject.GameEngine.Utils;

namespace AsteroidsTestProject.GameEngine.Spaceships
{
    public interface ISpaceshipManager
    {
        event Block<Spaceship> OnCreateSpaceship;
        event Block<Spaceship> OnResetSpaceship;

        void SpaceshipCollidedEnemy();
        void SpaceshipCrossedBordersOfScreen();
    }
}