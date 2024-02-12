using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.Client.Contracts.ProduktionsServices;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class MaterialbedarfWebRoutinen : WebRoutinenBase
    {
        public MaterialbedarfWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<Dictionary<string, MaterialbedarfCutOptimization>> GetCutOptimization(MaterialbedarfDTO[] materialbedarfDtos)
            => await PostAsync<Dictionary<string, MaterialbedarfCutOptimization>>("Materialbedarf/CutOptimization", materialbedarfDtos);
    }
}
