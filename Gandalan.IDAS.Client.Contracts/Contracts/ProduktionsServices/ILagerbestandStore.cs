using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface LagerbestandDBItemStore : IStore<LagerbestandDTO>
    {
        Task<IList<LagerbestandDTO>> GetAllAsync(DateTime changedSince);
    }
}
