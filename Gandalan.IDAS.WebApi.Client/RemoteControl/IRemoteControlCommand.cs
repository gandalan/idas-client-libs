using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.RemoteControl;

public interface IRemoteControlCommand
{
    string Uri { get; }
    Task<object> Execute(Dictionary<string, string> parameters);
}
