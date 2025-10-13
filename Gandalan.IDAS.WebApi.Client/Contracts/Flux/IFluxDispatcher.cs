using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux;

public interface IFluxDispatcher
{
    void RegisterStore(IFluxStore store);
    void RegisterStore(IFluxStore store, params string[] verbs);
    void UnregisterStore(IFluxStore store);
    Task DispatchStoreEventAsync(IFluxAction action);
    void DispatchStoreEvent(IFluxAction action);
}
