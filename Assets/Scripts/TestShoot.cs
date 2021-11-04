using System;
using TANKS;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestShoot : MonoBehaviour
    {
        
        
        
    }

    public class Bullet : MonoBehaviour
    {
        private IShoot myTank;

        private void Start()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == GetComponent<TankView>().gameObject.GetComponent<Collider>())
            {
                //other.GetComponent<TankView>().AnimationPlay();
            }
        }
    }
}