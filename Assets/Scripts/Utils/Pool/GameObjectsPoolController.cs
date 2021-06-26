using System;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsTestProject.Utils
{
    public class GameObjectsPoolController : MonoBehaviour, IGameObjectsPool
    {
        private Dictionary<MonoBehaviour, Stack<MonoBehaviour>> dictionaryObjectInPullByPref
            = new Dictionary<MonoBehaviour, Stack<MonoBehaviour>>();

        private Dictionary<MonoBehaviour, MonoBehaviour> dictionaryCreatedObjectsAndPref
            = new Dictionary<MonoBehaviour, MonoBehaviour>();

        private void Awake()
        {
            SimpleInjector.Add((IGameObjectsPool)this);
        }

        public T CreateGameObject<T>(T component) where T : MonoBehaviour
        {
            Stack<MonoBehaviour> listComponents;
            if (dictionaryObjectInPullByPref.TryGetValue(component, out listComponents))
            {
                if (listComponents.Count > 0)
                {
                    var item = (T)listComponents.Pop();
                    item.gameObject.SetActive(true);
                    return item;
                }
            }

            var createdObject = Instantiate(component);
            dictionaryCreatedObjectsAndPref.Add(createdObject, component);
            return createdObject;
        }

        public void RemoveGameObject<T>(T component) where T : MonoBehaviour
        {
            if (component == null || !dictionaryCreatedObjectsAndPref.ContainsKey(component)) return;

            var prefComponent = dictionaryCreatedObjectsAndPref[component];

            Stack<MonoBehaviour> listComponents;
            if (!dictionaryObjectInPullByPref.TryGetValue(prefComponent, out listComponents))
            {
                listComponents = new Stack<MonoBehaviour>();
                dictionaryObjectInPullByPref.Add(prefComponent, listComponents);
            }

            listComponents.Push(component);
            component.transform.SetParent(transform);
            component.gameObject.SetActive(false);
        }
    }
}