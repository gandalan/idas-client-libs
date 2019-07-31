using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAVBerechnungService
    {
        Task Execute(BelegPositionAVDTO model);
    }
}
