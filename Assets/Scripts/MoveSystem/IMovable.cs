using Abstractions.Component;

namespace Abstractions.MoveSystem
{
    public interface IMovable : IComponent
    {
        bool IsAlive { get; set; }
        
    }
}