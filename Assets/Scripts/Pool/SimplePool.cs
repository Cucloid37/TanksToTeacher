using System;
using System.Collections.Generic;
using Abstractions.Pool;
using UnityEngine;

namespace Pool
{
    public class SimplePool<T> : IPool<T> where T : IPoolable
    {
        private readonly Func<IPool<T>, T> _factory;
        private readonly Stack<T> allPoolObjects;

        private const int StartPoolSize = 5;

        public SimplePool(Func<IPool<T>, T> factory)
        {
            _factory = factory;
            allPoolObjects = new Stack<T>();
            
            for (int i = 0; i < StartPoolSize; i++)
            {
                var target = CreateObjects();
                allPoolObjects.Push(target);
            }
        }

        public T Get()
        {
            T target;
            if (allPoolObjects.Count == 0)
            {
                Debug.LogWarning($"Наш дорогой Pool пустой {typeof(T)}");
                target = CreateObjects();
            }
            
            target = allPoolObjects.Pop();
            target.PoolInit();
            return target;

        }

        public void Remove(T target)
        {
             target.PoolClear();
             allPoolObjects.Push(target);
             
             Debug.Log($"Объем пула: {allPoolObjects.Count}, {typeof(T).ToString()}");
        }

        private T CreateObjects()
        {
            T target = _factory(this);
            target.PoolClear();
            return target;
        }
    }
}