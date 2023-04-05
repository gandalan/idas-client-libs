using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAVSerienService
    {
        Task AddElement(SerieDTO serie, BelegPositionAVDTO element);
        Task RemoveElement(SerieDTO serie, BelegPositionAVDTO element);
    }
}
