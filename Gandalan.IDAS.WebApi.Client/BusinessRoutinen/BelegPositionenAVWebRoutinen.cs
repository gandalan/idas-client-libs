using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.WebJob;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BelegPositionenAVWebRoutinen : WebRoutinenBase
{
    public BelegPositionenAVWebRoutinen(IWebApiConfig settings) : base(settings) { }

    public async Task RunAVBerechnungAsync(Guid id, long mandantId)
        => await PostAsync($"BelegPositionenAV/RunAVBerechnung/{id}?mandantId={mandantId}", null, skipAuth: true);

    public async Task CalculateItems()
        => await PostAsync("BelegPositionenAV/CalculateItems", null, skipAuth: true);

    public async Task<List<MandantAndBelegPosGuidDTO>> GetCalculateItemList()
        => await GetAsync<List<MandantAndBelegPosGuidDTO>>("BelegPositionenAV/GetCalculateItemList", skipAuth: true);
}
