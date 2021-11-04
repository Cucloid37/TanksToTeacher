using System.Data;
using System.IO;
using UnityEngine;

namespace TANKS.Start
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data/Data")]
    public class Data : ScriptableObject
    {
        [SerializeField] private string _pathToTank;
        [SerializeField] private string _pathToLevel;
        [SerializeField] private string _pathToBullet;
        private TanksData _tanksData;
        private LevelData _levelData;
        private BulletData _bulletData;
        
        
        public TanksData TanksData
        {
            get
            {
                if (_tanksData == null)
                {
                    _tanksData = Load<TanksData>("Data/" + _pathToTank);
                    if(_tanksData == null)
                    {
                        throw new DataException($"Не загрузили {_tanksData}");
                    }
                }
                
                return _tanksData;
            }
            
        }

        public LevelData LevelData
        {
            get
            {
                if (_levelData == null)
                {
                    _levelData = Load<LevelData>("Data/" + _pathToLevel);
                    if(_levelData == null)
                    {
                        throw new DataException($"Не загрузили {_levelData}");
                    }
                }
                
                return _levelData;
            }
        }
        
        public BulletData BulletData
        {
            get
            {
                if (_bulletData == null)
                {
                    _bulletData = Load<BulletData>("Data/" + _pathToBullet);
                    if(_bulletData == null)
                    {
                        throw new DataException($"Не загрузили {_bulletData}");
                    }
                }
                
                return _bulletData;
            }
            
        }
        
        private static T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

    }
}