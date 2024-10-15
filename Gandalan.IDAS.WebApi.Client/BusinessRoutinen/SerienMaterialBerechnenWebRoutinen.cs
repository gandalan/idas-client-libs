using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class SerienMaterialBerechnenWebRoutinen : WebRoutinenBase
{
    public SerienMaterialBerechnenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task MaterialBerechnenAsync(Guid serieGuid, bool sfZusammenfassen = false, bool serieZusammenfassen = false)
    {
        if (sfZusammenfassen)
        {
            if (serieZusammenfassen)
            {
                await PostAsync("SerieMaterialbedarfBerechnen/SFZusammenfassen", serieGuid);
            }
            else
            {
                await PostAsync("SerieMaterialbedarfBerechnen/SFZusammenfassenVorgang", serieGuid);
            }
        }
        else
        {
            await PostAsync("SerieMaterialbedarfBerechnen", serieGuid);
        }
    }

    public async Task<List<MaterialbedarfDTO>> GetMaterialAsync(Guid serieGuid)
        => await GetAsync<List<MaterialbedarfDTO>>($"SerieMaterialbedarfBerechnen?serieGuid={serieGuid}");

    public async Task<List<MaterialbedarfDTO>> GetOffenerMaterialBedarfv2Async(Guid serieGuid, bool filterCsvExportedMaterial = true)
        => await GetAsync<List<MaterialbedarfDTO>>($"SerieOffenerMaterialbedarf?serieGuid={serieGuid}&filterCsvExportedMaterial={filterCsvExportedMaterial}", version: "2");

    public async Task<List<MaterialbedarfDTO>> GetOffenerMaterialBedarfAsync(Guid serieGuid)
        => await GetAsync<List<MaterialbedarfDTO>>($"SerieOffenerMaterialbedarf?serieGuid={serieGuid}");

    public async Task ResetMaterialAsync(Guid serieGuid)
        => await DeleteAsync($"SerieMaterialbedarfBerechnen?serieGuid={serieGuid}");
}
