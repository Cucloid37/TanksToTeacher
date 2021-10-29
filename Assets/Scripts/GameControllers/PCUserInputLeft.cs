using System;
using UnityEngine;

namespace TANKS.Start
{
    public class PCUserInputLeft : IUserInputProxy
    {
        public event Action<float> AxisOnChang = delegate(float f) {  };
        public void GetAxis()
        {
            AxisOnChang.Invoke(Input.GetAxis(AxisManager.MOUSELEFT));
        }
    }
}