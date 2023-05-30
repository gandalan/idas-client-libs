using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IBelegArtPosService
    {
        Task<VorgangDTO> BelegArtWechselAsync(BelegartWechselDTO dto);   
    }
}

