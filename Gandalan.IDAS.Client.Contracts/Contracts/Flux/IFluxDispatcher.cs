using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux
{
    public interface IFluxDispatcher
    {
        Task DispatchAsyncNew(IFluxAction action);
        void DispatchSyncNew(IFluxAction action);
        Task DispatchToConsumersAsync(IFluxStore sender, IFluxAction action);
    }
}
