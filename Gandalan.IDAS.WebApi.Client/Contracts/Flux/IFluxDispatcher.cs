using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux;

public interface IFluxDispatcher
{
    void Register(IFluxStore store);
    void Register(IFluxStore store, params string[] verbs);
    void Unregister(IFluxStore store);
    Task DispatchStoreEventAsync(IFluxAction action);
    void DispatchStoreEvent(IFluxAction action);
}
