namespace TANKS.Start
{
    public class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputProxy _space;


        public InputController((IUserInputProxy Horizontal, IUserInputProxy Vertical, IUserInputProxy Space) input)
        {
           
            _horizontal = input.Horizontal;
            _vertical = input.Vertical;
            _space = input.Space;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _space.GetAxis();
        }
    }
}