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
        await PostAsync("SerieMaterialbedarfBerechnen", serieGuid);
    }

    public async Task<List<MaterialbedarfDTO>> GetMaterialAsync(Guid serieGuid)
        => await GetAsync<List<MaterialbedarfDTO>>($"SerieMaterialbedarfBerechnen?serieGuid={serieGuid}");

    public async Task<List<MaterialbedarfDTO>> GetOffenerMaterialBedarfv2Async(Guid serieGuid, bool filterCsvExportedMaterial = true)
        => await GetAsync<List<MaterialbedarfDTO>>($"SerieOffenerMaterialbedarf?serieGuid={serieGuid}&filterCsvExportedMaterial={filterCsvExportedMaterial}", version: "2");

    public async Task<List<MaterialbedarfDTO>> GetOffenerMaterialBedarfAsync(Guid serieGuid)
        => await GetAsync<List<MaterialbedarfDTO>>($"SerieOffenerMaterialbedarf?serieGuid={serieGuid}");

    public async Task ResetMaterialAsync(Guid serieGuid)
        => await DeleteAsync($"SerieMaterialbedarfBerechnen?serieGuid={serieGuid}");

    public async Task<List<Guid>> MaterialBedarfBerechnenForFunctionAsync(Guid serieGuid, long mandantId)
        => await PutAsync<List<Guid>>($"SerieMaterialbedarfBerechnen/ForFunction?mandantId={mandantId}&serieGuid={serieGuid}", null, skipAuth: true);
    public async Task<List<Guid>> MaterialBedarfResetFromAvPosForFunctionAsync(Guid avPosGuid, long mandantId)
        => await PutAsync<List<Guid>>($"SerieMaterialbedarfBerechnen/ResetFromAvPosForFunction?mandantId={mandantId}&avPosGuid={avPosGuid}", null, skipAuth: true);
}
