using Abstractions.Component;
using Abstractions.MoveSystem;

namespace Core.Component
{
    public class AliveComponent : BaseComponent, IMovable
    {
        private bool isAlive;

        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public IEntity Owner { get; set; }
    }
}