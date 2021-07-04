using System;
using AsteroidsTestProject.Controllers;
using AsteroidsTestProject.ViewModel;
using UnityEngine;

namespace AsteroidsTestProject.Settings
{
    [Serializable]
    public class GameViewData
    {
        [SerializeField] private GameViewMode viewMode;
        [SerializeField] private BaseSpaceshipController spaceshipPref; 
        [SerializeField] private BaseFlyingSaucerController flyingSaucerPref; 
        [SerializeField] private BaseAsteroidController bigAsteroidPref; 
        [SerializeField] private BaseAsteroidController smallAsteroidPref; 
        [SerializeField] private BaseBulletController bulletPref;
        [SerializeField] private BaseLaserController laserPref;

        public GameViewMode ViewMode => viewMode;
        public BaseSpaceshipController SpaceshipPref => spaceshipPref;
        public BaseFlyingSaucerController FlyingSaucerPref => flyingSaucerPref;
        public BaseAsteroidController BigAsteroidPref => bigAsteroidPref;
        public BaseAsteroidController SmallAsteroidPref => smallAsteroidPref;
        public BaseBulletController BulletPref => bulletPref;
        public BaseLaserController LaserPref => laserPref;
    }
}