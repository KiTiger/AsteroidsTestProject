using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class BulletController2D : BaseBulletController
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Collided(other.gameObject);
        }
    }
}