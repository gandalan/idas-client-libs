using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux
{
    public interface IFluxStore
    {
        event EventHandler<IFluxAction> DataChanged;
        Task Handle(Flux.IFluxAction action);
        Task Initialize();
    }
    
    public interface IFluxStore<T> : IFluxStore
    {
        T Data { get; set; }
    }
}
