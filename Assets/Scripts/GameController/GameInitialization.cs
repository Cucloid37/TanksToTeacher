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
        private GameObject empty;
        private GameObject coroutines;
        
        public GameInitialization(Descriptions descriptions, UpdateControllers update)
        {
            empty = new GameObject("Container Of Class");
            coroutines = new GameObject("Coroutines");
            var input = new InputController(descriptions.InputKeys);
            // var prefabManager = new PrefabManager(descriptions);
            var factory = empty.AddComponent<MonoFactory>();
            var bulletFactory = new BulletFactory<IBullet>();
            bulletFactory.Init(descriptions, factory);
            var poolBullet = new SimplePool<IBullet>(bulletFactory.Method);
            var tankFactory = new TankFactory<ITankController>();
            tankFactory.Init(descriptions, factory);
            var poolTanks = new SimplePool<ITankController>(tankFactory.Method);
            var list = new List<TankModel>();

            var coroutineSystem = coroutines.AddComponent<CoroutineSystem>();
            var testMoveSystem = new TestMoveSystem();
            var testMoveComposite = new TestMoveComposite(list, poolBullet);
            
            var stateController = new StateController(input);
            
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