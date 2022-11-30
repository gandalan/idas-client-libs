namespace Gandalan.UI.Commands.Contracts
{
    public interface ICommandProvider
	{
		string Name { get; }

		bool CanExecuteCommand(string command, params object[] parameters);
		ICommandResult InvokeCommand(string command, params object[] parameters);
	}
}
