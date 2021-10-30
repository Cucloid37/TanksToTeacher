namespace TANKS
{

    public enum TypeArmour
    {
        VeryBig
    }
    public abstract class ArmourModel
    {
        private int _thickness { get; }
        private TypeArmour _type { get; }

        public ArmourModel(int thickness, TypeArmour type)
        {
            _thickness = thickness;
            _type = type;
        }
        
        
        //#TODO
        //Переписать этот метод на иной расчёт брони
        public virtual bool IsPenetrated(AmmoModel projectile)
        {
            return projectile.GetDamage() > _thickness;
        }
    }
}

