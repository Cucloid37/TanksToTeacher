using System.Collections;
using UnityEngine;

namespace Test
{
    public class TestStarter : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform target;
        private TestComposite composite;
    
        private void Start()
        {
            composite = new TestComposite();
            // StartCoroutine(composite.testing());
           
            Starting(composite.testing(bullet.transform, target));
        }

        private void FixedUpdate()
        {
            
        }

        public void Starting(IEnumerator method)
        {
            StartCoroutine(method);
        }
    }

    public class TestComposite
    {
        private int Count;
        public bool IsMoving = true;
        
        private Vector3 heading = new Vector3();
        private float distance;
        private Vector3 direction = new Vector3();

        public IEnumerator testing(Transform bullet, Transform target)
        {

           while (IsMoving)
            {
                heading = target.position - bullet.position;
                Debug.Log($"{heading} heading");
                // 
                distance = heading.magnitude;
                Debug.Log($"{distance} distance");

                direction = (heading / distance) / 10;
                Debug.Log($"{direction} direction");

                bullet.position += direction;
                Debug.Log($"{bullet.position} position");
                
                if (distance < 1)
                    IsMoving = false;
                
                yield return null;
            }
           
           Debug.LogWarning($"Сделали дела и готовы идти дальше");
           
           // и здесь вызываем следующий метод
        }
        
    }
}

