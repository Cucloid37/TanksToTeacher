using System;
using System.Collections.Generic;
using TANKS.Start;
using UnityEngine;

namespace TANKS
{
    public class MoveController : ICleanup
    {

        private IUserInputProxy _inputSpace;
        
        private readonly List<TankController> _playerTank;

        private readonly List<TankController> _enemyTank;


        public MoveController((IUserInputProxy InputHorizonta, IUserInputProxy InputVertical, IUserInputProxy InputSpace) input,
            List<TankController> playerTank, List<TankController> enemyTank)
        {
            _inputSpace = input.InputSpace;
            _playerTank = playerTank;
            _enemyTank = enemyTank;
            _inputSpace.AxisOnChang += MoveAll;
        }
        
        
        public void MoveAll(float f)
        {
            var target = new Vector3();
            
            foreach (var unit in _playerTank)
            {
                unit.Shoot(target);
            }
            
            // #TODO сделать паузу

            foreach (var unit in _enemyTank)
            {
                unit.Shoot(target);
            }
        }

        public void Cleanup()
        {
            // inputSpace.AxisOnChang -= MoveAll;
        }
    }
}