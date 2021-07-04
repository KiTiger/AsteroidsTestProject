using AsteroidsTestProject.GameEngine;
using UnityEngine;

namespace AsteroidsTestProject.Settings
{
    [CreateAssetMenu(fileName = "GameConfiguration", menuName = "AsteroidsTestProject/GameConfiguration", order = 0)]
    public class GameConfiguration : ScriptableObject, IGameConfiguration 
    {
        
        [Header("Gun")]
        [SerializeField] private int numberOfLasers;
        [SerializeField] private float createLaserTime;
        [Header("Asteroids")]
        [SerializeField] private int numberOfSmallAsteroidSpawn;
        [SerializeField] private float timeBetweenAppearanceOfAsteroidsMin;
        [SerializeField] private float timeBetweenAppearanceOfAsteroidsMax;
        [Header("Flying Saucer")]
        [SerializeField] private float timeBetweenAppearanceOfFlyingSaucersMin;
        [SerializeField] private float timeBetweenAppearanceOfFlyingSaucersMax;
        [Header("Other")]
        [SerializeField] private int pointsForBigAsteroid;
        [SerializeField] private int pointsForSmallAsteroid;
        [SerializeField] private int pointsForFlyingSaucer;

        int IGameConfiguration.NumberOfLasers => numberOfLasers;
        float IGameConfiguration.CreateLaserTime => createLaserTime;
        float IGameConfiguration.TimeBetweenAppearanceOfFlyingSaucersMin => timeBetweenAppearanceOfFlyingSaucersMin;
        float IGameConfiguration.TimeBetweenAppearanceOfFlyingSaucersMax => timeBetweenAppearanceOfFlyingSaucersMax;
        int IGameConfiguration.NumberOfSmallAsteroidSpawn => numberOfSmallAsteroidSpawn;
        float IGameConfiguration.TimeBetweenAppearanceOfAsteroidsMin => timeBetweenAppearanceOfAsteroidsMin;
        float IGameConfiguration.TimeBetweenAppearanceOfAsteroidsMax => timeBetweenAppearanceOfAsteroidsMax;
        int IGameConfiguration.PointsForBigAsteroid => pointsForBigAsteroid;
        int IGameConfiguration.PointsForSmallAsteroid => pointsForSmallAsteroid;
        int IGameConfiguration.PointsForFlyingSaucer => pointsForFlyingSaucer;
    }
}
