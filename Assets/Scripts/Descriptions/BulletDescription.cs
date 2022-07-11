using UnityEngine;

namespace Tanks
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Descriptions/Bullet")]
    public class BulletDescription : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _poolPosition;
        
        public GameObject Prefab => _prefab;
        public Transform PoolPosition => _poolPosition;
    }
}