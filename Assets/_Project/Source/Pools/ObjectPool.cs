using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Source.Pools
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly Queue<T> _pool = new Queue<T>();
        private T _prefab;
        private Transform _parent;

        public void Initialize(T prefab, int initialSize, Transform parent = null)
        {
            Clear();
            
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                var obj = CreateNewObject();
                _pool.Enqueue(obj);
            }
        }
        
        public T GetObject()
        {
            T obj = _pool.Count > 0 ? _pool.Dequeue() : CreateNewObject();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void ReturnObject(T obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }

        private void Clear()
        {
            while (_pool.Count > 0)
            {
                T obj = _pool.Dequeue();
                GameObject.Destroy(obj.gameObject);
            }
        }

        private T CreateNewObject()
        {
            if (_prefab.GetComponent<T>() == null)
            {
                throw new InvalidOperationException($"Префаб {_prefab.name} не содержит компонент {typeof(T)}.");
            }
            
            T obj = GameObject.Instantiate(_prefab, _parent);
            obj.gameObject.SetActive(false);
            return obj;
        }
    }
}