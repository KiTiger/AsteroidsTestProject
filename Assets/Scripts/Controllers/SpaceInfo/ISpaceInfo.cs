using AsteroidsTestProject.Model;
using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public interface ISpaceInfo
    {
        float XMin { get; }
        float YMin { get; }
        float XMax { get; }
        float YMax { get; }
        float Width { get; }
        float Height { get; }

        Vector2 GetSpawnPositionOnSide(Side side, float offset);
    }
}