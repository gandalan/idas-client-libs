using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices;

public interface IAblageStore : IStore<AblageDTO>
{
    Task<IList<AblageDTO>> GetAllAsync(DateTime changedSince);
}