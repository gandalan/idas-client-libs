using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices;

public interface IVorgangService
{
    Task<VorgangListItemDTO[]> GetAllAsync(Guid kunde);
    Task<VorgangListItemDTO[]> GetAllAsync(string statusFilter, int jahr);
    Task<VorgangListItemDTO[]> GetAllAsync(string statusFilter, int jahr, DateTime changedSince);
    Task<VorgangListItemDTO[]> GetAllAsync(int jahr, string status, DateTime changedSince, string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "", bool includeASP = false);

    Task<VorgangDTO> SaveAsync(VorgangDTO vorgang);
    Task<VorgangDTO> LoadVorgangAsync(Guid guid);
    Task ArchiveVorgang(Guid vorgangGuid);
    Task ArchiveVorgangList(List<Guid> vorgangGuidList);
    Task SetTextStatus(List<Guid> vorgangGuidList, string textStatus);

    Task<VorgangListItemDTO[]> LoadVorgaengeForKundeAsync(Guid kundeGuid);

    Task<VorgangDTO> DeleteBeleg(Guid bGuid);
}