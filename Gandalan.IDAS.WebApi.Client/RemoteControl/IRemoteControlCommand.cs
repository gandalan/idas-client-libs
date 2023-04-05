using System.Collections.Generic;

namespace Gandalan.Client.Contracts.RemoteControl
{
    public interface IRemoteControlCommand
    {
        string Uri { get; }
        object Execute(Dictionary<string, string> parameters);
    }
}