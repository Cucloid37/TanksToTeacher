using System.Collections.Generic;

namespace TANKS
{
    public class MoveController
    {
        private List<IDoIt> _speaker;
        private List<IShoot> _shooter;


        public MoveController()
        {
            
        }

        internal MoveController Add(IDoIt speaker)
        {
            if (speaker is IShoot shoot)
            {
                _shooter.Add(shoot);
            }

            return this;
        }
    }
}