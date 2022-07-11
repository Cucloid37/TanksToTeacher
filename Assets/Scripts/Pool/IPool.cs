namespace Abstractions.Pool
{
    public interface IPool<T> where T : IPoolable
    {
        public T Get();
        
        void Remove(T target);
    }
}