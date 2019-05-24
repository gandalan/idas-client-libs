using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.DataServices
{
    public interface IWertelistenService
    {
        Task<WerteListeDTO[]> GetAllAsync();
        Task<WerteListeDTO> LoadAsync(Guid guid);
        Task SaveAsync(WerteListeDTO liste);
        Task<WerteListeDTO> GetWerteliste(string werteListeName);
    }
}
