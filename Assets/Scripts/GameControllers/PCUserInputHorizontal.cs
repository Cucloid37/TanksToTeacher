using System;
using UnityEngine;

namespace TANKS.Start
{
    public class PCUserInputHorizontal : IUserInputProxy
    {
        public event Action<float> AxisOnChang = delegate(float f) {  };
        
        public void GetAxis()
        {
            AxisOnChang.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
        }
    }
}