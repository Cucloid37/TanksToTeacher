using UnityEngine;

namespace TANKS.Start
{
    public class BulletFactory : Factory, IBulletFactory
    {
        private Data _data;
        private GameObject bullet;

        public void SetData(Data data)
        {
            _data = data;
        }
       
        public GameObject CreateBullet(TankModel myTank)
        {
            bullet = Instantiate(_data.BulletData.Prefab, myTank.BulletPosition, Quaternion.identity);
            bullet.AddComponent<BulletView>().SetTankModel(myTank);

            return bullet;

        }
    }
}