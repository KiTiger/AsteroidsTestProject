using UnityEngine;
using System.Collections;
using AsteroidsTestProject.Utils;
using System.Collections.Generic;

namespace AsteroidsTestProject.Controllers
{
    public abstract class BaseLaserController : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;

        public event Block<BaseLaserController> onDestroy;

        public void SetData(float laserDistance)
        {
            lineRenderer.SetPosition(1, Vector3.right * laserDistance);

            var angle = transform.localEulerAngles.z * Mathf.Deg2Rad;
            var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            var hitObjects = CreateRay(laserDistance, direction);
            TouchObjects(hitObjects);

            StartCoroutine(HideLaserCoroutine());
        }

        protected abstract List<GameObject> CreateRay(float laserDistance, Vector2 direction);

        private void TouchObjects(List<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                var takesHitObject = gameObject.GetComponent<ITakesHitObject>();
                if (takesHitObject == null) continue;
                takesHitObject.LaserHit();
            }
        }

        private IEnumerator HideLaserCoroutine()
        {
            yield return new WaitForSeconds(0.1f);
            onDestroy.SafeInvoke(this);
        }
    }
}