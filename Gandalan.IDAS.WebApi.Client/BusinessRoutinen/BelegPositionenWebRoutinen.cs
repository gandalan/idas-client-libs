using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BelegPositionenWebRoutinen : WebRoutinenBase
{
    public BelegPositionenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task RunBelegPositionAVLogicAsync(long mandantId, Guid belegPositionGuid)
        => await PostAsync($"BelegPositionen/RunBelegPositionAVLogic?mandantId={mandantId}&belegPositionGuid={belegPositionGuid}", null);

    public async Task UpdateBelegPositionAVDataAsync(long mandantId, Guid belegPositionGuid)
        => await PostAsync($"BelegPositionen/UpdateBelegPositionAVData?mandantId={mandantId}&belegPositionGuid={belegPositionGuid}", null);

    public async Task<List<Guid>> SetBelegPositionGesperrtStatusAsync(bool gesperrtStatus, List<Guid> positionen)
        => await PutAsync<List<Guid>>($"BelegPositionGesperrtStatus/SetStatus/{gesperrtStatus}", positionen);

    public async Task CalculateItemsAsync()
        => await PostAsync("BelegPositionen/CalculateItems", null);

    public async Task<VorgangDTO> GetVorgangForFunctionAsync(Guid belegPositionGuid, long mandantId)
        => await GetAsync<VorgangDTO>($"BelegPositionen/GetVorgangForFunction?belegPositionGuid={belegPositionGuid}&mandantId={mandantId}");
}