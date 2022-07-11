using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private Descriptions descriptions;
        private GameInitialization initialization;
        private UpdateControllers updateControllers;
        
        private void Start()
        {
            updateControllers = new UpdateControllers();
            initialization = new GameInitialization(descriptions, updateControllers);
        }

        private void Update()
        {
            // updateControllers.Execute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            // updateControllers.LateExecute(Time.deltaTime);
        }

        private void OnDisable()
        {
            // updateControllers.Cleanup();
        }
    }
}

