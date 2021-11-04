using System;
using UnityEngine;

namespace TANKS
{
    public sealed class TankView : MonoBehaviour
    {
        // #TODO
        // Я сейчас вообще не помню, как вешается событие на анимацию и вообще работу с анимацией

        private TankController _controller;
        private Animator _animationDamage;
        private Vector3 _myPosition;
        public Vector3 MyPosition => _myPosition;
        
        
        
        public void Start()
        {
            _myPosition = gameObject.transform.position;
            _animationDamage = gameObject.GetComponent<Animator>();
        }

        // #TODO Анимация не сделана
        public void AnimationPlay(TankModel model)
        {
            _animationDamage.Play("NewAnimation");
            _controller.GetDamage(model);
            
        }

        public void SetController()
        {
            
        }
    }
}