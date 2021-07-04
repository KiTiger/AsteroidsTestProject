using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.Utils;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class SpaceInfoController : MonoBehaviour, ISpaceInfo
    {
        [SerializeField] private Camera mainCamera;

        public float XMin { get; private set; }
        public float YMin { get; private set; }
        public float XMax { get; private set; }
        public float YMax { get; private set; }
        public float Width => XMax - XMin;
        public float Height => YMax - YMin;

        private void Awake()
        {
            SimpleInjector.Add((ISpaceInfo) this);

            var min = mainCamera.ViewportToWorldPoint(Vector3.zero);
            XMin = min.x;
            YMin = min.y;
            var max = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
            XMax = max.x;
            YMax = max.y;
        }

        public Vector2 GetSpawnPositionOnSide(Side side, float offset)
        {
            var x = side switch
            {
                Side.Left => XMin - offset,
                Side.Right => XMax + offset,
                _ => Random.Range(XMin, XMax)
            };

            var y = side switch
            {
                Side.Top => YMax + offset,
                Side.Bottom => YMin - offset,
                _ => Random.Range(YMin, YMax)
            };

            return new Vector2(x, y);
        }
    }
}