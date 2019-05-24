using System.Collections.Generic;

namespace Gandalan.Plugins.Common.Contracts
{
    public interface IRemoteControlServer
    {
        IList<IRemoteControlCommand> Commands { get; }

        void Start();
        void RegisterCommand(IRemoteControlCommand command);
        void Stop();
    }
}
