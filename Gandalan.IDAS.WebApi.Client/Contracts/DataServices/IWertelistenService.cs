using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices;

public interface IWertelistenService
{
    Task<WerteListeDTO[]> GetAllAsync();
    Task<WerteListeDTO> LoadAsync(Guid guid);
    Task<WerteListeDTO> GetWerteliste(string werteListeName);
}