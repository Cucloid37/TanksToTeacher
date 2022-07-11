using System.Collections.Generic;
using Abstractions.Component;
using Abstractions.MoveSystem;

namespace MoveSystem
{
    public abstract class MoveComposite : IMoveComponent
    {
        protected List<IEntity> allMovable = new List<IEntity>();

        public MoveComposite()
        {
            
        }


        // public abstract void Move(int id);

        public void Add(IEntity moveObj)
        {
            allMovable.Add(moveObj);
        }

        public void Remove(IEntity moveObj)
        {
            allMovable.Remove(moveObj);
        }
    }
}