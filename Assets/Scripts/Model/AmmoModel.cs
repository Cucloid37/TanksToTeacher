namespace TANKS
{

    public enum TypeGun
    {
        VeryBig
    }
    public abstract class AmmoModel
    {
        private GunModel _gun { get; }
        private TypeGun _type { get; }

        // #TODO 
        // Вынести все константные переменные в static class
        private const int DamageFactory = 3;
        
        public AmmoModel(GunModel someGun, TypeGun type)
        {
            _gun = someGun;
            _type = type;
        }
        
        public virtual int GetDamage()
        {
            // #TODO
            // OVERRIDE: add logic of variable damage depending on Ammo type
            return _gun.GetCaliber()*DamageFactory;
        }
        
        public int GetPenetration()
        {
            return _gun.GetCaliber();
        }
        
        public override string ToString()
        {
            return $"Снаряд {_type} к пушке калибра {_gun.GetCaliber()}";
        }
    }
}