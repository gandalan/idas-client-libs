using Gandalan.Client.Contracts.ProduktionsServices;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.ProduktionsServices
{
    public interface ISchnittOptimierungService
    {
        Task<Dictionary<string, MaterialbedarfCutOptimization>> GetCutOptimization(MaterialbedarfDTO[] materialbedarfDtos);
    }
}
