using System.Threading.Tasks;
using Core.Component;
using Tanks.Models;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Tanks
{
    [CreateAssetMenu(fileName = "Tanks", menuName = "Descriptions/Tanks")]
    public class TanksDescriptions : ScriptableObject
    {
        // todo заменить на addressable
        [SerializeField] private AssetReference reference;
        [SerializeField] private int maxHealth;
        [SerializeField] private int damageStrength;
        [SerializeField] private Transform _spawnPoint;
        
        // Какие данные нам нужны о танке? 
        // На данный момент лишь перечисленное, а также точка начального спавна
        
        // public AssetReference Reference => reference;

        public Transform SpawnPoint => _spawnPoint;
        
        // todo не лучше ли перенести в конструктор?
        public ITankModel GetModel => new TankModel 
        { maxHealth = { MaxHealth = maxHealth}, damageForce = { damageForce = damageStrength} };
        
        public async Task<GameObject> GetPrefab()
        {
            return await Addressables.LoadAssetAsync<GameObject>(reference).Task; 
        }
        
    }
}