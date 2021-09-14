using Gandalan.Client.Contracts.ProduktionsServices;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class MaterialbedarfWebRoutinen : WebRoutinenBase
    {
        public MaterialbedarfWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public Dictionary<string, MaterialbedarfCutOptimization> GetCutOptimization(MaterialbedarfDTO[] materialbedarfDtos)
        {
            if (Login())
            {
                return Post<Dictionary<string, MaterialbedarfCutOptimization>>("Materialbedarf/CutOptimization", materialbedarfDtos);
            }

            return null;
        }
    }
}
