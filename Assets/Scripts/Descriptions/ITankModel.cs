using Abstractions.Component;
using Abstractions.Pool;
using Core.Component;

namespace Tanks
{
    public interface ITankModel : IEntity
    {
        Health maxHealth { get; }
        DamageForce damageForce { get; }
    }

    public interface ITankController : IPoolable
    {
        
    }
}