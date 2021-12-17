using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAVElementStore
    {
        Task<bool> ExistsAsync(Guid guid);

        Task<IList<BelegPositionAVDTO>> GetAsync(Guid guid);

        Task<IList<BelegPositionAVDTO>> GetAllAsync(bool includeOriginalBeleg = true, bool includeProdDaten = true);
        Task<IList<BelegPositionAVDTO>> GetAllAsync(DateTime changedSince, bool includeOriginalBeleg = true, bool includeProdDaten = true);

        Task AddOrUpdateAsync(BelegPositionAVDTO data);
        Task<IList<BelegPositionAVDTO>> AddOrUpdateAsync(List<BelegPositionAVDTO> data);

        Task DeleteAsync(Guid guid);
        Task DeleteAsync(List<Guid> guid);
    }
}
