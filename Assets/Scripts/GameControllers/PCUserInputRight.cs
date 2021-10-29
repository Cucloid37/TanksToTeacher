using System;
using UnityEngine;

namespace TANKS.Start
{
    public class PCUserInputRight : IUserInputProxy
    {
        public event Action<float> AxisOnChang = delegate(float f) { };
        public void GetAxis()
        {
            AxisOnChang.Invoke(Input.GetAxis(AxisManager.MOUSERIGHT));
        }
    }
}