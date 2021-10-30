namespace TANKS
{
    public class BigArmour : ArmourModel
    {
        public BigArmour(int thickness) : base(thickness, TypeArmour.VeryBig) { }

        //#TODO
        //реализовать метод подсчет урона
        public override bool IsPenetrated(AmmoModel projectile)
        {
            return true;
        }
    }
}