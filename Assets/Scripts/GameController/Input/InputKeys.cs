using System;
using UnityEngine;

namespace Tanks
{
    public class InputKeys
    {
        public void GetMouseLeft(Action action)
        {
            if(Input.GetMouseButton(0)) action?.Invoke();
        }
    }
}