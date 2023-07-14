using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IKundenService
    {
        Task<KontaktListItemDTO[]> GetAllAsync();
        Task<KontaktListItemDTO[]> GetAllAsync(DateTime changedSince);
        Task<KontaktDTO> SaveAsync(KontaktDTO kunde);
        Task<KontaktDTO> LoadAsync(Guid guid);
        Task ArchiveAsync(List<Guid> kundenGuidList);
        Task UnarchiveAsync(List<Guid> kundenGuidList);
    }
}