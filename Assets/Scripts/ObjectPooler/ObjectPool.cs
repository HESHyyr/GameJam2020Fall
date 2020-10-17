using SpookuleleGames.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace SpookuleleGames.ObjectPooling
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] GameObject prefab;

        public Queue<GameObject> Pool { get; private set; }

        int instanceCount = 0;

        public void Init()
        {
            Pool = new Queue<GameObject>();
        }

        public int GetInstanceCount()
        {
            return instanceCount;
        }

        public void CreateInstances(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreateInstance();
            }
        }

        public void CreateInstance()
        {
            instanceCount++;
            GameObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            ReturnToQueue(instance);
        }

        public void ReturnToQueue(GameObject instance)
        {
            Pool.Enqueue(instance);
        }

        public GameObject Get()
        {
            if (Pool.Count == 0)
            {
                CreateInstance();
            }

            GameObject instance = Pool.Dequeue();

            instance.gameObject.SetActive(true);
            MethodDelayer.DelayMethodByPredicateAsync(() => ReturnToQueue(instance), () => instance.activeSelf == false);
            return instance;
        }
    }
}