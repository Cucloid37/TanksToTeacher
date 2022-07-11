using Abstractions.Pool;
using UnityEngine;

namespace Tanks
{
    [CreateAssetMenu(fileName = "Descriptions", menuName = "Descriptions/Descriptions")]
    public class Descriptions : ScriptableObject
    {
        [SerializeField] private InputKeysData inputKeys;

        [SerializeField] private TanksDescriptions tanks;

        [SerializeField] private BulletDescription bullet;
        
        public InputKeysData InputKeys => inputKeys;

        public TanksDescriptions Tanks => tanks;

        public BulletDescription Bullet => bullet;


    }

    [CreateAssetMenu(fileName = "Bullet", menuName = "Descriptions/Bullet")]
    public class BulletDescription : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _poolPosition;
        
        public GameObject Prefab => _prefab;
        public Transform PoolPosition => _poolPosition;
    }
}