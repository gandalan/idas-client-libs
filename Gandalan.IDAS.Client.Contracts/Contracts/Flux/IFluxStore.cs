using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux
{
    public interface IFluxStore
    {
        Task Handle(IFluxAction action);
        void HandleSync(IFluxAction action);
        Task Initialize();
        Task Clean();
        Task Consume(IFluxStore sender, IFluxAction action);
    }
    
    public interface IFluxStore<T> : IFluxStore
    {
        T Data { get; set; }
    }
}
