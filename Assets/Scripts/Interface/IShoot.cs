using System;
using UnityEngine;

namespace TANKS
{
    public interface IShoot : IDoIt
    {
        // #TODO входные параметры
        void Shoot(Vector3 target);
    }
    
    public interface IDoIt
    {
        bool ICanMove { get; set; }
    }
    
}