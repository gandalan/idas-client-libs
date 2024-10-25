using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class PositionStornoWebRoutinen : WebRoutinenBase
{
    public PositionStornoWebRoutinen(IWebApiConfig settings) : base(settings) { }

    public async Task PositionStornierenAsync(Guid positionGuid)
        => await PostAsync($"PositionStorno?posGuid={positionGuid}", null);

    public async Task BelegStornierenAsync(Guid belegGuid)
        => await PostAsync($"BelegStorno?belegGuid={belegGuid}", null);
}
