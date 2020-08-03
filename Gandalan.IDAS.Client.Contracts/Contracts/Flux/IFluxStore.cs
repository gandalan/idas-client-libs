using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux
{
    public interface IFluxStore
    {
        void AddTransientEventHandler(EventHandler<IFluxAction> eventHandler);
        void AddPermanentEventHandler(EventHandler<IFluxAction> eventHandler);
        void ClearTransientEventHandlers();

        Task Handle(Flux.IFluxAction action);
        Task Initialize();
        Task Clean();
    }
    
    public interface IFluxStore<T> : IFluxStore
    {
        T Data { get; set; }
    }
}
