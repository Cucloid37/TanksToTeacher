using UnityEngine;

namespace TANKS.Start
{
    public interface IFactory
    {
        GameObject CreatePrefab(GameObject prefab, Vector3 position);
    }
}