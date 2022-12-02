using System.Collections.Generic;

namespace Gandalan.UI.Commands.Contracts
{
    public interface ICommandResult
	{
        CommandResultStatusCode StatusCode { get; }
        Dictionary<string, object> Data { get; }
        string Text { get; }
	}
}
