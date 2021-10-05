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

        Task<IList<BelegPositionAVDTO>> GetAllAsync();
        Task<IList<BelegPositionAVDTO>> GetAllAsync(DateTime changedSince);

        Task AddOrUpdateAsync(BelegPositionAVDTO data);
        Task<IList<BelegPositionAVDTO>> AddOrUpdateAsync(List<BelegPositionAVDTO> data);

        Task DeleteAsync(Guid guid);
        Task DeleteAsync(List<Guid> guid);
    }
}
