using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class BulletController3D : BaseBulletController
    {
        private void OnTriggerEnter(Collider other)
        {
            Collided(other.gameObject);
        }
    }
}