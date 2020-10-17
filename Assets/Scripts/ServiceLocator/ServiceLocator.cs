using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpookuleleGames.ServiceLocator
{
    public class ServiceLocator : SerializedMonoBehaviour
    {
        [SerializeField] GameObject[] gameObjectServices;
        [SerializeField] ScriptableObject[] scriptableObjectServices;

        List<IService> servicesList;
        Dictionary<Type, IService> servicesDictionary;

        private static ServiceLocator INSTANCE;

        private void Awake()
        {
            INSTANCE = this;
            LoadGameObjectAndSOServices();
            InitializeServices();
            InitializeDictionary();
        }

        void LoadGameObjectAndSOServices()
        {
            servicesList = new List<IService>();
            for (int i = 0; i < gameObjectServices.Length; i++)
            {
                GameObject gameObjectService = gameObjectServices[i];
                IService service = gameObjectService.GetComponent<IService>();
                if (service != null)
                    servicesList.Add(service);
            }
            for (int i = 0; i < scriptableObjectServices.Length; i++)
            {
                ScriptableObject scriptableObjectService = scriptableObjectServices[i];
                if(scriptableObjectService is IService)
                    servicesList.Add(scriptableObjectService as IService);
            }
        }
        void InitializeServices()
        {
            servicesList.Sort((s1, s2) => s1.Priority.CompareTo(s2.Priority));
            
            for (int i = 0; i < servicesList.Count; i++)
            {
                IService service = servicesList[i];
                service.Init();
            }
        }
        void InitializeDictionary()
        {
            servicesDictionary = new Dictionary<Type, IService>();
            if(servicesList == null || servicesList.Count < 1) { return; }

            for(int i = 0; i <servicesList.Count; i++)
            {
                IService service = servicesList[i];
                servicesDictionary.Add(service.GetType(), service);
            }
        }

        public static T GetService<T>() where T : IService
        {
            if(INSTANCE.servicesDictionary.TryGetValue(typeof(T), out IService service))
                return (T) service;

            return default;
        }
    }
}