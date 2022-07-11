namespace Tanks
{
    public interface IExecute : IController
    {
        void Execute(float deltaTime);
    }
}