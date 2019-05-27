using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Common.Contracts.DataServices
{
    public interface IVorgangService
    {
        Task<VorgangListItemDTO[]> GetAllAsync(Guid kunde);
        Task<VorgangListItemDTO[]> GetAllAsync(string statusFilter, int jahr);

        Task<VorgangDTO> SaveAsync(VorgangDTO vorgang);
        Task<VorgangDTO> LoadVorgangAsync(Guid guid);
        Task ArchiveVorgang(Guid vorgangGuid);

        Task<VorgangListItemDTO[]> LoadVorgaengeForKundeAsync(Guid kundeGuid);
    }
}