using System.Collections;
using System.Collections.Generic;
using Abstractions.Component;
using Abstractions.MoveSystem;
using Abstractions.Pool;
using Tanks.Models;
using UnityEngine;

namespace MoveSystem
{
    public class TestMoveComposite : MoveComposite
    {
        private int Count;
        private IPool<IBullet> poolBullets;
        private bool IsMoving;
        
        private Vector3 heading = new Vector3();
        private float distance;
        private Vector3 direction = new Vector3();
        
        public TestMoveComposite(List<TankModel> models, IPool<IBullet> poolBullets)
        {
            foreach (var model in models)
            {
                model.isAlive.SubscribeOnChange(ChangedLife);
                model.isAlive.Value.IsAlive = true;
            }

            Count = allMovable.Count;
            
            
        }

        public IEnumerator testing(Vector3 bullet, Vector3 target)
        {

            while (IsMoving)
            {
                heading = target - bullet;
                Debug.Log($"{heading} heading");
                // 
                distance = heading.magnitude;
                Debug.Log($"{distance} distance");
                
                direction = (heading / distance) / 10;

                bullet += direction;

                if (distance < 1)
                    IsMoving = false;
                
                yield return null;
            }
           
            Debug.LogWarning($"Сделали дела и готовы идти дальше");
           
            // и здесь вызываем следующий метод
        }
       
        

        private void ChangedLife(IComponent isAlive)
        {
            if (isAlive is not IMovable movable)
            {
                Debug.LogWarning($"В методе ChangedLife nullReference. Кэш объекта {isAlive.GetIdHashCode}");
                return;
            }
            if (movable.IsAlive != true)
                Remove(movable.Owner);
            Add(movable.Owner);
        }
        
    }
}