using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Flux;

namespace Gandalan.IDAS.Client.Contracts.Flux
{
    public interface IFluxConsumer
    {
        void RegisterWithStores();
        void UnregisterFromStores();
        Task Handle(IFluxStore sender, IFluxAction action);
    }
}
