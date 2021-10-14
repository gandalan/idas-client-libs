using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAblageFachStore : IStore<AblageFachDTO>
    {
        Task<IList<AblageFachDTO>> GetAllAsync(DateTime changedSince);
    }
}
