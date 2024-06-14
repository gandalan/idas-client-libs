using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.DTOs.Produktion;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices;

public interface IProduktionsfreigabeListeService
{
    Task<ProduktionsfreigabeItemDTO[]> GetProduktionsfreigabeListeAsync();
}