namespace Gandalan.UI.Commands.Contracts
{
    public interface ICommandReceiver
    {
        void Start(ICommandDispatcher dispatch);
        void Stop();
    }
}
