using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux;

public interface IFluxStore
{
    void AddTransientEventHandler(IFluxConsumer eventHandler);
    void AddPersistentEventHandler(IFluxConsumer eventHandler);
    void RemoveTransientEventHandler(IFluxConsumer eventHandler);
    void RemovePersistentEventHandler(IFluxConsumer eventHandler);
    void ClearTransientEventHandlers();

    Task Handle(IFluxAction action);
    void HandleSync(IFluxAction action);
    Task Initialize();
    Task Clean();
}

public interface IFluxStore<T> : IFluxStore
{
    T Data { get; }
}
