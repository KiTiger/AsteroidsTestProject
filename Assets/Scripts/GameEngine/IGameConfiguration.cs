namespace AsteroidsTestProject.GameEngine
{
    public interface IGameConfiguration
    {
        int NumberOfLasers { get; }
        float CreateLaserTime { get; }
        float TimeBetweenAppearanceOfFlyingSaucersMin { get; }
        float TimeBetweenAppearanceOfFlyingSaucersMax { get; }
        int NumberOfSmallAsteroidSpawn { get; }
        float TimeBetweenAppearanceOfAsteroidsMin { get; }
        float TimeBetweenAppearanceOfAsteroidsMax { get; }
        int PointsForBigAsteroid { get; }
        int PointsForSmallAsteroid { get; }
        int PointsForFlyingSaucer { get; }
    }
}
