using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktionWebRoutinen : WebRoutinenBase
    {
        public ProduktionWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<string> ProduktionBerechnenAsync(Guid belegPositionsGuid) 
            => await GetAsync<string>($"Script/PosBerechnen?pguid={belegPositionsGuid}");

        public async Task<List<BearbeitungDTO>> GetProduktionAsync(Guid belegPositionsGuid) 
            => await GetAsync<List<BearbeitungDTO>>($"Produktion/?posguid={belegPositionsGuid}");

        public async Task<List<MaterialbedarfDTO>> GetMaterialBedarfAsync(Guid belegPositionsGuid)
            => await GetAsync<List<MaterialbedarfDTO>>($"MaterialBedarf/?posguid={belegPositionsGuid}");

    }
}
