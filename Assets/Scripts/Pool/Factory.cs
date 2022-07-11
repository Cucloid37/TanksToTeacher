using System;
using System.Reflection;
using Abstractions.Pool;
using Tanks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Pool
{
    public abstract class Factory<T> where T : IPoolable
    {
        private Descriptions _descriptions;
        protected MonoFactory _instantiate;
        public Func<IPool<T>, T> Method;

        public virtual void Init(Descriptions descriptions, MonoFactory factory)
        {
            _descriptions = descriptions;
            _instantiate = factory;
            Method += FactoryPoolMethod;
        }

        protected abstract T FactoryPoolMethod(IPool<T> pool);

    }
}