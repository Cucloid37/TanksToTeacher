using Abstractions.Component;
using Core.Component;
using UnityEngine;

namespace Tanks.Models
{
    public class TankModel : ITankModel
    {
        // todo вынести в модель
        private Transform position;
        public Health maxHealth { get; private set; } = new Health();
        public DamageForce damageForce { get; private set; } = new DamageForce();
        // для подписки систем контроля, на удаление из списков в случае смерти
        public SubscriptionProperty<AliveComponent> isAlive;

        public TankModel()
        {
            isAlive = new SubscriptionProperty<AliveComponent>() { Value = new AliveComponent
                {
                    Owner = this
                }
            };
            
            
        }

    }
}