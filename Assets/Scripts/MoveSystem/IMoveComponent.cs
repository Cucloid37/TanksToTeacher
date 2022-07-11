using Abstractions.Component;

namespace Abstractions.MoveSystem
{
    public interface IMoveComponent
    {
        // void Move(int id);

        void Add(IEntity moveObj);

        void Remove(IEntity moveObj);
    }
}