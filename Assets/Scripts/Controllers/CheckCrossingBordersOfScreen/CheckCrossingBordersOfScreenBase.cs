using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public abstract class CheckCrossingBordersOfScreenBase : MonoBehaviour
    {
        [SerializeField] protected Camera mainCamera;

        protected ISpaceInfo spaceInfo;

        protected virtual void Start()
        {
            spaceInfo = SimpleInjector.Get<ISpaceInfo>();
        }

        protected void OnTriggerExitGameObject(GameObject otherGameObject)
        {
            var spaceObject = otherGameObject.GetComponent<ISpaceObject>();

            if (spaceObject != null)
            {
                spaceObject.CrossedBordersOfScreen();
            }
        }
    }
}