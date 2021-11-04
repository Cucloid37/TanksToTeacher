using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

namespace TANKS.Start
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/Data/Level")]
    public sealed class LevelData : ScriptableObject
    {
        [SerializeField] private string _pathToPrefab;
        [SerializeField] private List<Vector3> _spawnPoints;
        [SerializeField] private List<Vector3> _spawnPlayerPoints; 
        private GameObject _prefab;

        public List<Vector3> SpawnPoints => _spawnPoints;
        public List<Vector3> SpawnPlayer => _spawnPlayerPoints;
        
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