using UnityEngine;

namespace TANKS.Start
{
    public class Factory : MonoBehaviour, IFactory
    {
        
        public virtual GameObject CreatePrefab(GameObject prefab, Vector3 position)
        {
            return Instantiate(prefab, position, Quaternion.identity);
        }
    }
}