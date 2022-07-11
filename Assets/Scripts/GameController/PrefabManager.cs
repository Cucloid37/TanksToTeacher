using UnityEngine;

namespace Tanks
{
    /// <summary>
    /// Нужен в дальнейшем, для загрузки через Addressebles
    /// </summary>
    public class PrefabManager
    {
        private Descriptions _descriptions;

        public PrefabManager(Descriptions descriptions)
        {
            _descriptions = descriptions;
        }

        public GameObject GetPrefab()
        {
            return null;
        }
    }
}