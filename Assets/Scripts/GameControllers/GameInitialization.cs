using UnityEngine;

namespace TANKS.Start
{
    public sealed class GameInitialization
    {
        // #TODO временный костыль

        private const int Caliber = 5;
        private const int Lenght = 5;
        private const int Thickness = 3;
        
        public GameInitialization(Data data, Controllers controllers)
        {

            var inputInitialization = new InputInitialization();
            controllers.Add(inputInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));

            var factoryBullet = new GameObject("Factory").AddComponent<BulletFactory>();
            factoryBullet.SetData(data);
            var factory = new GameObject("eee").AddComponent<Factory>();
            var gun = new GunModel(Caliber, Lenght);
            var ammo = new BigAmmo(gun);
            var armour = new BigArmour(Thickness);
            var level = new LevelController(data, factory, gun, ammo, armour);
            level.Initialization();
            /*controllers.Add(level);*/
            var moveController = new MoveController(inputInitialization.GetInput(), level.PlayerControllers, level.EnemyControllers);
            controllers.Add(moveController);


        }
    }
}