using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class SpaceshipController2D : BaseSpaceshipController
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Collided(other.gameObject);
        }
    }
}