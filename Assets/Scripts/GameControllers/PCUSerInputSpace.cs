using System;
using UnityEngine;

namespace TANKS.Start
{
    public class PCUSerInputSpace : IUserInputProxy
    {
        public event Action<float> AxisOnChang = delegate(float f) {  };
        public void GetAxis()
        {
            AxisOnChang.Invoke(Input.GetAxis(AxisManager.SPACE));
        }
    }
}