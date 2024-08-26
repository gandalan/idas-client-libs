using System.Collections.Generic;

namespace Gandalan.UI.Commands.Contracts;

public interface ICommand
{
    string Command { get; }
    ICommandResult InvokeCommand(Dictionary<string, string> parameter);
}