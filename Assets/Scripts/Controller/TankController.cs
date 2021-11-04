using System;
using TANKS.Start;
using UnityEngine;

namespace TANKS
{
    public class TankController : IShoot
    {
        public bool ICanMove { get; set; }
        
        private TankModel _model;
        private IBulletFactory _factory;
        private GameObject _bullet;

        public TankController(TankModel model, IBulletFactory factory)
        {
            _model = model;
            _factory = factory;
        }
        
        // #TODO void GetDamage()
        // 
        public void GetDamage(TankModel attackerModel)
        {
            
        }
        
        
        // #TODO void Shoot()
        // 
        public void Shoot(Vector3 target)
        {
            _bullet = _factory.CreateBullet(_model);
            _bullet.GetComponent<BulletView>().Move(target);
        }

    }
}