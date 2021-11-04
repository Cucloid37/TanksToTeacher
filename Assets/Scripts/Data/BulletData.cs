using System.Data;
using System.IO;
using UnityEngine;

namespace TANKS.Start
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "Data/Data/BulletData")]
    public class BulletData : ScriptableObject
    {
        [SerializeField] private string _pathToPrefab;
        private GameObject _prefab;
        
        
        public GameObject Prefab
        {
            get
            {
                if (_prefab == null)
                {
                    _prefab = Load<GameObject>("Prefabs/" + _pathToPrefab);
                    if(_prefab == null)
                    {
                        throw new DataException($"Не загрузили {_prefab}");
                    }
                }
                
                return _prefab;
            }
            
        }
        
        private static T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}