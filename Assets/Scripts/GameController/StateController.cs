using System;

namespace Tanks
{
    public class StateController : BaseController
    {
        private readonly InputController _input;
        private readonly PrefabManager _manager;
        private readonly ProfilePlayer _profilePlayer;
        private MainMenuController _mainMenuController;
        private BattleController _battleController;
        
        public StateController(InputController input, PrefabManager manager)
        {
            _input = input;
            _manager = manager;
            _profilePlayer = new ProfilePlayer();
            
            _profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
        }

        public void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.mainMenu:
                    _mainMenuController = new MainMenuController();
                    break;
                case GameState.BattleState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }

    public class BattleController : BaseController
    {
    }

    public class MainMenuController : BaseController
    {
    }

    public class BaseController
    {
    }

    public enum GameState
    {
        mainMenu,
        BattleState
    }
}