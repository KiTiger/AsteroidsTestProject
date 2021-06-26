using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsTestProject.Settings
{
    [CreateAssetMenu(fileName = "GameConfiguration", menuName = "AsteroidsTestProject/GameConfiguration", order = 0)]
    public class GameConfiguration : ScriptableObject
    {
        [Header("Spaceship")]
        [SerializeField] private float spaceshipSpeed;
        [SerializeField] private float spaceshipTurningSpeed;
        [Header("Gun")]
        [SerializeField] private float bulletsSpeed;
        [SerializeField] private float laserDistance;
        [SerializeField] private int numberOfLasers;
        [SerializeField] private float createLaserTime;
        [Header("Asteroids")]
        [SerializeField] private int numberOfSmallAsteroidSpawn;
        [SerializeField] private float bigAsteroidSpeedMin;
        [SerializeField] private float bigAsteroidSpeedMax;
        [SerializeField] private float smallAsteroidSpeedMin;
        [SerializeField] private float smallAsteroidSpeedMax;
        [SerializeField] private float timeBetweenAppearanceOfAsteroidsMin;
        [SerializeField] private float timeBetweenAppearanceOfAsteroidsMax;
        [Header("Flying Saucer")]
        [SerializeField] private float flyingSaucerSpeed;
        [SerializeField] private float timeBetweenAppearanceOfFlyingSaucersMin;
        [SerializeField] private float timeBetweenAppearanceOfFlyingSaucersMax;
        [Header("Other")]
        [SerializeField] private float spaceObjectsSpawnOffset;
        [SerializeField] private int pointsForBigAsteroid;
        [SerializeField] private int pointsForSmallAsteroid;
        [SerializeField] private int pointsForFlyingSaucer;

        public float SpaceshipSpeed => spaceshipSpeed;
        public float SpaceshipTurningSpeed => spaceshipTurningSpeed;
        public float BulletsSpeed => bulletsSpeed;
        public float LaserDistance => laserDistance;
        public int NumberOfLasers => numberOfLasers;
        public float CreateLaserTime => createLaserTime;
        public float FlyingSaucerSpeed => flyingSaucerSpeed;
        public float TimeBetweenAppearanceOfFlyingSaucersMin => timeBetweenAppearanceOfFlyingSaucersMin;
        public float TimeBetweenAppearanceOfFlyingSaucersMax => timeBetweenAppearanceOfFlyingSaucersMax;
        public int NumberOfSmallAsteroidSpawn => numberOfSmallAsteroidSpawn;
        public float BigAsteroidSpeedMin => bigAsteroidSpeedMin;
        public float BigAsteroidSpeedMax => bigAsteroidSpeedMax;
        public float SmallAsteroidSpeedMin => smallAsteroidSpeedMin;
        public float SmallAsteroidSpeedMax => smallAsteroidSpeedMax;
        public float TimeBetweenAppearanceOfAsteroidsMin => timeBetweenAppearanceOfAsteroidsMin;
        public float TimeBetweenAppearanceOfAsteroidsMax => timeBetweenAppearanceOfAsteroidsMax;
        public float SpaceObjectsSpawnOffset => spaceObjectsSpawnOffset;
        public int PointsForBigAsteroid => pointsForBigAsteroid;
        public int PointsForSmallAsteroid => pointsForSmallAsteroid;
        public int PointsForFlyingSaucer => pointsForFlyingSaucer;
    }
}
