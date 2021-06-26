using UnityEngine;

namespace AsteroidsTestProject.Utils
{
    public interface IGameObjectsPool
    {
        T CreateGameObject<T>(T component) where T : MonoBehaviour;
        void RemoveGameObject<T>(T component) where T : MonoBehaviour;
    }
}