using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux;

public interface IFluxStore
{
    void AddTransientConsumer(IFluxConsumer newConsumer);
    void AddPersistentConsumer(IFluxConsumer newConsumer);
    void RemoveTransientConsumer(IFluxConsumer removeableConsumer);
    void RemovePersistentConsumer(IFluxConsumer removeableConsumer);
    void ClearTransientConsumers();
    Task HandleDispatcherEventAsync(IFluxAction action);
    void HandleDispatcherEvent(IFluxAction action);
    Task Initialize();
    Task Clean();
    IDictionary<string, Func<IFluxAction, Task>> HandlerMap { get; }
}

public interface IFluxStore<out TData> : IFluxStore
{
    TData Data { get; }
}
