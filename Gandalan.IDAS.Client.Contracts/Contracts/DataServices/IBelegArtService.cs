using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IBelegArtService
    {
        Task<VorgangDTO> BelegKopierenAsync(Guid bguid, string neueBelegArt, bool saldenKopieren = false);   
        VorgangDTO BelegKopieren(Guid bguid, string neueBelegArt, bool saldenKopieren = false);   
    }
}

