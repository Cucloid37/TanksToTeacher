using System.Data;
using System.IO;
using UnityEngine;

namespace TANKS.Start
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public class Data : ScriptableObject
    {
        [SerializeField] private string _pathToData;
        private TanksData _tanksData;
        
        
        public TanksData TanksData
        {
            get
            {
                if (_tanksData == null)
                {
                    _tanksData = Load<TanksData>("Prefabs/" + _pathToData);
                    if(_tanksData == null)
                    {
                        throw new DataException($"Не загрузили {_tanksData}");
                    }
                }
                
                return _tanksData;
            }
            
        }
        
        private static T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

    }
}