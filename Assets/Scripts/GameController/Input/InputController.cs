using System;

namespace Tanks
{
    public class InputController : IExecute
    {
        public event Action OnClickMouseLeft;

        private readonly InputKeys _keys;
        private readonly InputKeysData _inputKeysData;
        
        public InputController(InputKeysData inputDescription)
        {
            _keys = new InputKeys();
            _inputKeysData = inputDescription;
        }

        public void Execute(float deltaTime)
        {
            _keys.GetMouseLeft(OnClickMouseLeft);
        }
    }
}