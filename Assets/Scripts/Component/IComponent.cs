namespace Abstractions.Component
{
    public interface IComponent
    {
        //todo инкапсулировать в дальнейшем
        IEntity Owner { get; set; }
        
        int GetIdHashCode { get; }
    }
}