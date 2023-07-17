using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.DTO.Gesamtbedarf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class GesamtMaterialbedarfWebRoutinen : WebRoutinenBase
    {
        public GesamtMaterialbedarfWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<GesamtMaterialbedarfGetReturn> GetAsync(DateTime? stichTag = null) 
            => await GetAsync<GesamtMaterialbedarfGetReturn>($"GesamtMaterialbedarf?stichTag={stichTag?.ToString("o")}");

        public async Task DeleteAsync(Guid guid) 
            => await DeleteAsync($"GesamtMaterialbedarf/{guid}");

        public async Task ZusammenfassenAsync(List<GesamtMaterialbedarfDTO> dtos, ZusammenfassungsOptionen optionen, bool stangenoptimierung) 
            => await PostAsync($"GesamtMaterialbedarf/Zusammenfassen?optionen={optionen}&stangenoptimierung={stangenoptimierung}", dtos);

        public async Task WebJobAsync()
            => await PostAsync("GesamtMaterialbedarf/WebJob", null);
    }
}
