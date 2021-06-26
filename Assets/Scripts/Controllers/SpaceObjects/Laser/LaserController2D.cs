using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class LaserController2D : BaseLaserController
    {
        protected override List<GameObject> CreateRay(float laserDistance, Vector2 direction)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, laserDistance);

            var hitObjects = new List<GameObject>();
            foreach (var hit in hits)
            {
                hitObjects.Add(hit.collider.gameObject);
            }

            return hitObjects;
        }
    }
}