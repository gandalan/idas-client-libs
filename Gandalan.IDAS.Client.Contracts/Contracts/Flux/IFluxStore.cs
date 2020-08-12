using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux
{
    public interface IFluxStore
    {
        void AddTransientEventHandler(IFluxConsumer eventHandler);
        void AddPersistentEventHandler(IFluxConsumer eventHandler);
        void RemoveTransientEventHandler(IFluxConsumer eventHandler);
        void RemovePersistentEventHandler(IFluxConsumer eventHandler);

        /// <summary>
        /// Obsoleted - use AddPersistentEventHandler
        /// </summary>
        [Obsolete("use AddPersistentEventHandler")]
        event EventHandler<IFluxAction> DataChanged;

        Task Handle(IFluxAction action);
        Task Initialize();
        Task Clean();
    }
    
    public interface IFluxStore<T> : IFluxStore
    {
        T Data { get; set; }
    }
}
