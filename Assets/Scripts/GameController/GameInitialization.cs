using System;
using System.Collections;
using System.Collections.Generic;
using Abstractions.Pool;
using MoveSystem;
using Pool;
using Tanks.Models;
using UnityEngine;

namespace Tanks
{
    public class GameInitialization
    {
        private GameObject empty = new GameObject("Container Of Class");
        private GameObject coroutines = new GameObject("Coroutines");
        
        public GameInitialization(Descriptions descriptions, UpdateControllers update)
        {
            var input = new InputController(descriptions.InputKeys);
            var prefabManager = new PrefabManager(descriptions);
            var bulletFactory = empty.AddComponent<BulletFactory<IBullet>>();
            var poolBullet = new SimplePool<IBullet>(bulletFactory.Method);
            var tankFactory = empty.AddComponent<TankFactory<ITankController>>();
            var poolTanks = new SimplePool<ITankController>(tankFactory.Method);
            var list = new List<TankModel>();

            var coroutineSystem = coroutines.AddComponent<CoroutineSystem>();
            var testMoveSystem = new TestMoveSystem();
            var testMoveComposite = new TestMoveComposite(list, poolBullet);
            
            var stateController = new StateController(input, prefabManager);
            
            update.Add(input);
        }
    }

    public class CoroutineSystem : MonoBehaviour
    {
        public void Starting(IEnumerator method)
        {
            StartCoroutine(method);
        }
    }

    public interface IPrefab
    {
    }
}