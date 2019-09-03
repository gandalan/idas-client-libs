using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAVElementService
    {
        Task CreateAVData(BelegPositionDTO position, string kunde, string kommission, Guid vorgangGuid, Guid belegGuid);

        Task<IList<BelegPositionAVDTO>> Get(Func<BelegPositionAVDTO, bool> include);
    }
}
