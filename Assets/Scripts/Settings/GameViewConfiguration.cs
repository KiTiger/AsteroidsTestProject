using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsTestProject.Settings
{
    [CreateAssetMenu(fileName = "GameViewConfiguration", menuName = "AsteroidsTestProject/GameViewConfiguration", order = 1)]
    public class GameViewConfiguration : ScriptableObject
    {
        [Header("Spaceship")]
        [SerializeField] private float spaceshipSpeed;
        [SerializeField] private float spaceshipTurningSpeed;
        [Header("Gun")]
        [SerializeField] private float bulletsSpeed;
        [SerializeField] private float laserDistance;
        [Header("Asteroids")]
        [SerializeField] private float bigAsteroidSpeedMin;
        [SerializeField] private float bigAsteroidSpeedMax;
        [SerializeField] private float smallAsteroidSpeedMin;
        [SerializeField] private float smallAsteroidSpeedMax;
        [Header("Flying Saucer")]
        [SerializeField] private float flyingSaucerSpeed;
        [Header("Other")]
        [SerializeField] private float spaceObjectsSpawnOffset;
        [Header("Visual Modes")]
        [SerializeField] private List<GameViewData> visualМodes;

        public float SpaceshipSpeed => spaceshipSpeed;
        public float SpaceshipTurningSpeed => spaceshipTurningSpeed;
        public float BulletsSpeed => bulletsSpeed;
        public float LaserDistance => laserDistance;
        public float BigAsteroidSpeedMin => bigAsteroidSpeedMin;
        public float BigAsteroidSpeedMax => bigAsteroidSpeedMax;
        public float SmallAsteroidSpeedMin => smallAsteroidSpeedMin;
        public float SmallAsteroidSpeedMax => smallAsteroidSpeedMax;
        public float FlyingSaucerSpeed => flyingSaucerSpeed;
        public float SpaceObjectsSpawnOffset => spaceObjectsSpawnOffset;
        public List<GameViewData> VisualМodes => visualМodes;
    }
}
