using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.Client.Contracts.ProduktionsServices;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.ProduktionsServices;

public interface ISchnittOptimierungService
{
    Task<Dictionary<string, MaterialbedarfCutOptimization>> GetCutOptimization(MaterialbedarfDTO[] materialbedarfDtos);
}