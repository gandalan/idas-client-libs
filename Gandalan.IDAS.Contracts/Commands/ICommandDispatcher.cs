namespace Gandalan.UI.Commands.Contracts
{
    public interface ICommandDispatcher
    {
        ICommandResult InvokeCommand(string command, params object[] parameters);
    }
}
