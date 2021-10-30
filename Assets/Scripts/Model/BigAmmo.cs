namespace TANKS
{
    public class BigAmmo : AmmoModel
    {
        public BigAmmo(GunModel someGun) : base(someGun, TypeGun.VeryBig) {}
        
        public override int GetDamage()
        {
            return (int)(base.GetDamage());            
        }
    }
}