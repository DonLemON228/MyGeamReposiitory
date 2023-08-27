using System;
using System.Collections.Generic;
using UnityEngine;

    public class ServiceLocator: MonoBehaviour
    {
        public static ServiceLocator instance;
        
        private static readonly Dictionary<Type, object>
            Services = new Dictionary<Type, object>();

        protected virtual void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        
        public static void Register<T>(object serviceInstance)
        {
            Services[typeof(T)] = serviceInstance;
        }

        public static T Resolve<T>()
        {
            return (T)Services[typeof(T)];
        }

        public static void Reset()
        {
            Services.Clear();
        }
    }