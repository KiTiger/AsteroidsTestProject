using System;
using System.Collections.Generic;

namespace AsteroidsTestProject.Utils
{
    public class SimpleInjector
    {
        private static SimpleInjector _instance;

        private Dictionary<Type, object> objectsByType = new Dictionary<Type, object>();

        public static T Get<T>() where T : class
        {
            if (_instance == null) _instance = new SimpleInjector();

            object obj;
            if (_instance.objectsByType.TryGetValue(typeof(T), out obj)) return obj as T;
            else return null;
        }

        public static void Add<T>(T obj) where T : class
        {
            if (obj == null) return;
            Add(typeof(T), obj);
        }

        public static void Add(Type type, object obj)
        {
            if (obj == null) return;
            if (_instance == null) _instance = new SimpleInjector();

            _instance.objectsByType[type] = obj;
        }
    }
}