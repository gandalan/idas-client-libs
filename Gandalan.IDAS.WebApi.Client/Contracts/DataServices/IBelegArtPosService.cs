using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IBelegArtPosService
    {
        Task<VorgangDTO> BelegArtWechselAsync(BelegartWechselDTO dto);
    }
}
