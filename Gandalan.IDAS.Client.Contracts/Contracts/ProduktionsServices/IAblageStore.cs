using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAblageStore : IStore<AblageFachDTO>
    {
        Task<IList<AblageFachDTO>> GetAllAsync(DateTime changedSince);
    }
}
