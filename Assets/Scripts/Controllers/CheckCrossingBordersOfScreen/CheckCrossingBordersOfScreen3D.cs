using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class CheckCrossingBordersOfScreen3D : CheckCrossingBordersOfScreenBase
    {
        [SerializeField] private BoxCollider boxCollider;

        protected override void Start()
        {
            base.Start();
            boxCollider.size = new Vector3(spaceInfo.Width, spaceInfo.Height, 1);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitGameObject(other.gameObject);
        }
    }
}