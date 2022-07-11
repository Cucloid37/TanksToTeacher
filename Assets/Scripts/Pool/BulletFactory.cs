using Abstractions.Pool;
using Tanks;
using Tanks.Models;
using UnityEngine;

namespace Pool
{
    public class BulletFactory<T> : Factory<T> where T : IPoolable
    {
        private BulletDescription description;
        private readonly Transform container = new GameObject("ContainerBullet").transform;

        // Сомнительное решение, возможно
        public override void Init(Descriptions descriptions, MonoFactory factory)
        {
            base.Init(descriptions, factory);
            description = descriptions.Bullet;
        }

        protected override T FactoryPoolMethod(IPool<T> pool)
        {
            var view = _instantiate.Instant
                    (description.Prefab, description.PoolPosition.position, Quaternion.identity, container).
                AddComponent<BulletView>();
            IBullet bullet = new Bullet(view);

            return (T)bullet;
        }

        
    }
}