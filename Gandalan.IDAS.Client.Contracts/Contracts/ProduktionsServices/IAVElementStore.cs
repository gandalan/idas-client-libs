using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAVElementStore : IStore<BelegPositionAVDTO>
    {
        Task<IList<BelegPositionAVDTO>> GetAllAsync(DateTime changedSince);

        Task<IList<BelegPositionAVDTO>> AddOrUpdateAsync(List<BelegPositionAVDTO> data);

        Task DeleteAsync(List<Guid> guid);
    }
}
