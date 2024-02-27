using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAVSerienStore : IStore<SerieDTO>
    {
        Task<IList<SerieDTO>> GetAllAsync(DateTime changedSince);
    }
}
