using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IProduktionsStatusStore
    {
        Task<IList<ProduktionsStatusDTO>> GetAll();
        Task<ProduktionsStatusDTO> Get(Guid positionsGuid);
        Task Save(ProduktionsStatusDTO status);
        Task Remove(Guid positionsGuid);
    }
}
