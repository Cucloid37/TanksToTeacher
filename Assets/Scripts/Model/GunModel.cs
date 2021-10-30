namespace TANKS
{
    public class GunModel
    {
        private readonly int _caliber;
        private readonly int _barrelLength;

        public GunModel(int caliber, int length)
        {
            _caliber = caliber;
            _barrelLength = length;
        }

        public int GetCaliber()
        {
            return _caliber;
        }

        public bool IsOnTarget(int dice)
        {
            return (_barrelLength + dice) > 100; 
        }
    }
}