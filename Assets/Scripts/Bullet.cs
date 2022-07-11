using System;
using Abstractions.Pool;
using Pool;

namespace Tanks.Models
{
    public class Bullet : IBullet
    {
        public BulletView View { get; private set; }
       
        public Bullet(BulletView view)
        {
            View = view;
        }

        public void PoolInit()
        {
            throw new NotImplementedException();
        }

        public void PoolClear()
        {
            throw new NotImplementedException();
        }
    }

    public interface IBullet : IPoolable
    {
        
    }
}