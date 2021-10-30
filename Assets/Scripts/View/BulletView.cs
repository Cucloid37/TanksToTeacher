using System;
using TANKS.Start;
using UnityEngine;

namespace TANKS
{
    public sealed class BulletView : MonoBehaviour
    {
        public event Action<int> OnTriggerEnterChange; 
        private GameObject _bullet;

       
        // #TODO 
        public void Move(Vector3 position)
        {
            gameObject.transform.position = position;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject.GetInstanceID());
        }
        
        // #TODO уничтожить объект 
        // Не помню как правильно уничтожать

    }
}