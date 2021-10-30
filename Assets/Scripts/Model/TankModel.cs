namespace TANKS
{
    public sealed class TankModel
    {
        private GunModel _gun;
        private AmmoModel _ammo;
        private ArmourModel _armour;
        private string _name;
        private int _health;

        // #TODO
        // В будущем переделать под множество брони или снарядов
        public TankModel(GunModel gunModel, AmmoModel ammoModel, ArmourModel armourModel, string name, int health)
        {
            _gun = gunModel;
            _ammo = ammoModel;
            _armour = armourModel;
            _name = name;
            _health = health;
        }
        
        // #TODO
        // Добавить методы Предположительно GetArmourModel(); SetHealth(); 


    }
}