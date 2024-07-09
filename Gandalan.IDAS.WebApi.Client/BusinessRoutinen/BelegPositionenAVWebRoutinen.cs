using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BelegPositionenAVWebRoutinen : WebRoutinenBase
{
    public BelegPositionenAVWebRoutinen(IWebApiConfig settings) : base(settings) { }

    public async Task RunAVBerechnungAsync(Guid id, long mandantId)
        => await PostAsync($"BelegPositionenAV/RunAVBerechnung/{id}?mandantId={mandantId}", null);

    public async Task CalculateItems()
        => await PostAsync("BelegPositionenAV/CalculateItems", null);
}