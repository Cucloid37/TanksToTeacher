using System;
using UnityEngine;

namespace Pool
{
    public class MonoFactory : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Мы зашли в старт и почему-то вылетели");
        }

        public GameObject Instant(GameObject descriptionPrefab, Vector3 poolPositionPosition, Quaternion identity, Transform transform)
        {
            return Instantiate(descriptionPrefab, poolPositionPosition, identity, transform);
        }
    }
}