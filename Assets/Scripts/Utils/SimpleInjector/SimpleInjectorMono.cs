using UnityEngine;

namespace AsteroidsTestProject.Utils
{
    public class SimpleInjectorMono : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] behaviours;
        [SerializeField] private ScriptableObject[] scriptables;

        private void Awake()
        {
            foreach (var behaviour in behaviours)
            {
                SimpleInjector.Add(behaviour.GetType(), behaviour);
            }

            foreach (var scriptable in scriptables)
            {
                SimpleInjector.Add(scriptable.GetType(), scriptable);
            }
        }
    }
}