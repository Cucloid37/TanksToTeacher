namespace Tanks
{
    public class ProfilePlayer
    {
        public SubscriptionProperty<GameState> CurrentState { get; }

        public ProfilePlayer()
        {
            CurrentState = new SubscriptionProperty<GameState>()
            {
                Value = GameState.mainMenu
            };
        }
    }
}