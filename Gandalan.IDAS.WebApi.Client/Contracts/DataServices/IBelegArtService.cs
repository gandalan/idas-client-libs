using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IBelegArtService
    {
        Task<VorgangDTO> BelegKopierenAsync(Guid bguid, string neueBelegArt, bool saldenKopieren = false);
    }
}
