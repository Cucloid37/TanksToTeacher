using UnityEngine;

namespace TANKS.Start
{
    public class InputInitialization : IInitialization
    {
        private IUserInputProxy _userInputHorizontal;
        private IUserInputProxy _userInputVertical;
        private IUserInputProxy _userInputSpace;

        public InputInitialization()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                // #TODO
                // реализовать под мобильное, но это далеко не срочно
                
                _userInputHorizontal = new MobileInput();
                _userInputVertical = new MobileInput();
                _userInputSpace = new MobileInput();
                return;
            }
            
            _userInputHorizontal = new PCUserInputHorizontal();
            _userInputVertical = new PCUserInputVertical();
            _userInputSpace = new PCUSerInputSpace();
            
        }
        
        public void Initialization()
        {
            

        }
        
        
        public (IUserInputProxy InputHorizonta, IUserInputProxy InputVertical, IUserInputProxy InputSpace) GetInput()
        {
            (IUserInputProxy InputHorizonta, IUserInputProxy InputVertical, IUserInputProxy InputSpace) 
                result = (_userInputHorizontal, _userInputVertical, _userInputSpace);
            return result;
        }
    }
}