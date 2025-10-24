namespace Gandalan.Client.Contracts.UIServices;

public interface IConnectionNotify
{
    ConnectionNotifyState State { get; }

    public void UpdateState(ConnectionNotifyState state);
}
