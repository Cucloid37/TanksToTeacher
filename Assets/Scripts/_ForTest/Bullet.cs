using UnityEngine;

namespace Test
{
    public class Bullet : MonoBehaviour
    {
        private TestComposite composite;

        public void SetComposite(TestComposite com)
        {
            composite = com;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("мы тут");
            if (other.GetComponent<BoxCollider>())
            {
                Debug.LogWarning("Ух ты!");
                composite.IsMoving = false;
            }
        }
    }
}