using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IWertelistenService
    {
        Task<WerteListeDTO[]> GetAllAsync();
        Task<WerteListeDTO> LoadAsync(Guid guid);
        Task SaveAsync(WerteListeDTO liste);
        Task<WerteListeDTO> GetWerteliste(string werteListeName);
    }
}
