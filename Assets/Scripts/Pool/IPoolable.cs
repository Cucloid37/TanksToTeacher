using Abstractions.Component;

namespace Abstractions.Pool
{
    public interface IPoolable : IEntity
    {
        void PoolInit();

        void PoolClear();
    }
}