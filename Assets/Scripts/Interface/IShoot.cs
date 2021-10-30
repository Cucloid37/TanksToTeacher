using System;

namespace TANKS
{
    public interface IShoot
    {
        // #TODO входные параметры
        void Shoot();
    }
    
    public interface IDoIt
    {
        event Action<int> OnTriggerEnterChange;
        
        int Initiative { get; }
        bool ICanMove { get; set; }
        
        void SetInitiative(int value);
    }
    
}