using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.DTO.Gesamtbedarf;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class GesamtMaterialbedarfWebRoutinen : WebRoutinenBase
    {
        public GesamtMaterialbedarfWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<GesamtMaterialbedarfGetReturn> GetAsync(DateTime? stichTag = null, DateTime? bedarfAb = null)
            => await GetAsync<GesamtMaterialbedarfGetReturn>($"GesamtMaterialbedarf?stichTag={stichTag?.ToString("o")}&bedarfAb={bedarfAb?.ToString("O")}");

        public async Task DeleteAsync(Guid guid)
            => await DeleteAsync($"GesamtMaterialbedarf/{guid}");

        public async Task ZusammenfassenAsync(List<GesamtMaterialbedarfDTO> dtos, ZusammenfassungsOptionen optionen, bool stangenoptimierung)
            => await PostAsync($"GesamtMaterialbedarf/Zusammenfassen?optionen={optionen}&stangenoptimierung={stangenoptimierung}", dtos);

        public async Task WebJobAsync()
            => await PostAsync("GesamtMaterialbedarf/WebJob", null);

        public async Task GesamtBedarfUpdateLiefertag(long mandantId, Guid posGuid)
            => await PostAsync($"GesamtMaterialbedarf/GesamtBedarfUpdateLiefertag?mandantId={mandantId}&posGuid={posGuid}", null);
    }
}
