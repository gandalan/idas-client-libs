namespace Gandalan.Client.Contracts
{
    public interface IModelMapper<T, U> 
    {
        void Convert(T source, U target);
        void Convert(U source, T target);
    }
}
