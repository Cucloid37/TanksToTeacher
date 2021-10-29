namespace TANKS.Start
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}