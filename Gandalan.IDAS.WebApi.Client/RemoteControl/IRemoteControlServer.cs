using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.RemoteControl;

public interface IRemoteControlServer
{
    Task Start();
    Task Stop();
}
