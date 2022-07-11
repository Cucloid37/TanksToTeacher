using Abstractions.Component;

namespace Core.Component
{
    public abstract class BaseComponent : IComponent
    {
        private int idHashCode = -1;
        public IEntity Owner { get; set; }

        public BaseComponent()
        {
            ConstructorCall();
        }

        protected virtual void ConstructorCall()
        {
            
        }

        public int GetIdHashCode
        {
            get
            {
                if (idHashCode != -1)
                    return idHashCode;

                idHashCode = this.GetType().GetHashCode();
                return idHashCode;
            }
        }
    }
}