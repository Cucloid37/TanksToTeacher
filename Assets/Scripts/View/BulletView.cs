using System;
using TANKS.Start;
using UnityEngine;

namespace TANKS
{
    public sealed class BulletView : MonoBehaviour, ICleanup
    {
        private TankModel _model;

        public void SetTankModel(TankModel model)
        {
            _model = model;
        }

        // #TODO 
        public void Move(Vector3 position)
        {
            gameObject.transform.position = position;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other == GetComponent<TankView>().gameObject.GetComponent<Collider>())
            {
                other.GetComponent<TankView>().AnimationPlay(_model);
            }
        }
        
        // #TODO уничтожить объект 
        // Не помню как правильно уничтожать

        public void Cleanup()
        {
            
        }
    }
}