using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{

    public interface IProduktionService
    {
        Task<ProduktionsDatenDTO> GetDaten(BelegPositionDTO belegPosition, IArtikelAssetsService artikelAssetsService);
        bool CanHandle(string variantenName);
    }
}
