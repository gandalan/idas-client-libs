using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IProduktionsfreigabeService
    {
        Task<VorgangDTO> ProduktionsfreigabeAsync(BelegartWechselDTO dto);
    }
}
