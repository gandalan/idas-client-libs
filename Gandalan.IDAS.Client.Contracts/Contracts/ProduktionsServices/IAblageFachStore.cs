using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAblageFachStore : IStore<SerieDTO>
    {
        Task<IList<SerieDTO>> GetAllAsync(DateTime changedSince);
    }
}
