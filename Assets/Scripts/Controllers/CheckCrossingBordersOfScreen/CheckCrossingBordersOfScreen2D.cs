using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class CheckCrossingBordersOfScreen2D : CheckCrossingBordersOfScreenBase
    {
        [SerializeField] private BoxCollider2D boxCollider2D;

        protected override void Start()
        {
            base.Start();
            boxCollider2D.size = new Vector2(spaceInfo.Width, spaceInfo.Height);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExitGameObject(other.gameObject);
        }
    }
}