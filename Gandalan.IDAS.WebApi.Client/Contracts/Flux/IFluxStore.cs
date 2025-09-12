using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Contracts.Flux;

namespace Gandalan.IDAS.Client.Contracts.Flux;

public interface IFluxStore
{
    IDictionary<string, Func<IFluxAction, Task>> HandlerMap { get; }
    void AddTransientConsumer(IFluxConsumer newConsumer);
    void AddPersistentConsumer(IFluxConsumer newConsumer);
    void RemoveTransientConsumer(IFluxConsumer removeableConsumer);
    void RemovePersistentConsumer(IFluxConsumer removeableConsumer);
    void ClearTransientConsumers();
    Task HandleDispatcherEventAsync(IFluxAction action);
    void HandleDispatcherEvent(IFluxAction action);
    Task InitializeStore();
    Task CleanupStore();
}

public interface IFluxStore<out TData> : IFluxStore
{
    TData Data { get; }
}
