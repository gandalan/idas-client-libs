using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.DTO.Gesamtbedarf;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class GesamtMaterialbedarfWebRoutinen : WebRoutinenBase
{
    public GesamtMaterialbedarfWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<GesamtMaterialbedarfGetReturn> GetAsync(ZusammenfassungsOptionen optionen, bool stangenoptimierung, DateTime? stichTag = null, DateTime? bedarfAb = null, bool filterCsvExportedMaterial = true)
        => await GetAsync<GesamtMaterialbedarfGetReturn>($"GesamtMaterialbedarf?optionen={optionen}&stangenoptimierung={stangenoptimierung}&stichTag={stichTag?.ToString("o")}&bedarfAb={bedarfAb?.ToString("O")}&filterCsvExportedMaterial={filterCsvExportedMaterial}");

    public async Task WebJobAsync()
        => await PostAsync("GesamtMaterialbedarf/WebJob", null);

    public async Task GesamtBedarfUpdateLiefertag(long mandantId, Guid posGuid)
        => await PostAsync($"GesamtMaterialbedarf/GesamtBedarfUpdateLiefertag?mandantId={mandantId}&posGuid={posGuid}", null);
}
