using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux;

public interface IFluxConsumer
{
    void RegisterConsumerWithStores();
    void UnregisterConsumerFromStores();
    Task HandleStoreEvent(IFluxStore sender, IFluxAction action);
}
