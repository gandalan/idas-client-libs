using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux
{
    public interface IFluxStore
    {
        void AddTransientEventHandler(EventHandler<IFluxAction> eventHandler);
        void AddPersistentEventHandler(EventHandler<IFluxAction> eventHandler);
        void ClearTransientEventHandlers();

        /// <summary>
        /// Obsoleted - use AddPersistentEventHandler
        /// </summary>
        [Obsolete("use AddPersistentEventHandler")]
        event EventHandler<IFluxAction> DataChanged;

        Task Handle(Flux.IFluxAction action);
        Task Initialize();
        Task Clean();
    }
    
    public interface IFluxStore<T> : IFluxStore
    {
        T Data { get; set; }
    }
}
