using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class SpaceshipController3D : BaseSpaceshipController
    {
        private void OnTriggerEnter(Collider other)
        {
            Collided(other.gameObject);
        }
    }
}