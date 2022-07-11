using System;
using System.Reflection;
using Abstractions.Pool;
using Tanks;
using Tanks.Models;
using UnityEngine;

namespace Pool
{
    public abstract class Factory<T> : MonoBehaviour where T : IPoolable
    {
        protected readonly Descriptions _descriptions;
        public Func<IPool<T>, T> Method;

        public Factory(Descriptions descriptions)
        {
            _descriptions = descriptions;
            Method += FactoryPoolMethod;
        }
        
        protected abstract T FactoryPoolMethod(IPool<T> pool);

    }

    public class BulletFactory<T> : Factory<T> where T : IBullet
    {
        private readonly BulletDescription description;
        private readonly Transform container = new GameObject("ContainerBullet").transform;
        
        public BulletFactory(Descriptions descriptions) : base(descriptions)
        {
            description = descriptions.Bullet;
        }

        protected override T FactoryPoolMethod(IPool<T> pool)
        {
            var view = Instantiate
                    (description.Prefab, description.PoolPosition.position, Quaternion.identity, container).
                AddComponent<BulletView>();
            IBullet bullet = new Bullet(view);

            return (T)bullet;
        }
    }


    public class BulletView : MonoBehaviour
    {
        
    }
}