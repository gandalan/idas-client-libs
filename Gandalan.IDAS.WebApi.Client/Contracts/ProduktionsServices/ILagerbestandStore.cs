using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface ILagerbestandStore : IStore<LagerbestandDTO>
    {
        Task<IList<LagerbestandDTO>> GetAllAsync(DateTime changedSince);
    }
}
