using Gandalan.IDAS.WebApi.Client.DTOs.Produktion;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IProduktionsfreigabeListeService
    {
        Task<ProduktionsfreigabeItemDTO[]> GetProduktionsfreigabeListeAsync();
    }
}
