using System;
using UnityEngine;

namespace TANKS
{
    public sealed class TankView : MonoBehaviour
    {
        // #TODO
        // Я сейчас вообще не помню, как вешается событие на анимацию и вообще работу с анимацией
        public event Action<bool> IHaveDamage; 
        private Animation _animationDamage;
        
        public void AnimationPlay()
        {
            
        }
    }
}