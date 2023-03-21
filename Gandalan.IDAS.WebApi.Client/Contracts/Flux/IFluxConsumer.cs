using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Flux
{
    public interface IFluxConsumer
    {
        void RegisterWithStores();
        void UnregisterFromStores();
        Task Handle(IFluxStore sender, IFluxAction action);
    }
}
