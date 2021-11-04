using UnityEngine;

namespace TANKS.Start
{
    public interface IFactory
    {
        GameObject CreatePrefab(GameObject prefab, Vector3 position);
    }

    public interface IBulletFactory : IFactory
    {
        GameObject CreateBullet(TankModel myTank);
    }
}