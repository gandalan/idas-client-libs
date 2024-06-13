using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class IBOS1Routinen : WebRoutinenBase
{
    public IBOS1Routinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<string> ProduktionBerechnenAsync(Guid belegPositionsGuid)
        => await GetAsync<string>("IBOS1/Print?bguid=" + belegPositionsGuid);

    public async Task<string> PositionTestenAsync(Guid belegPositionsGuid)
        => await GetAsync<string>("Test?bguid=" + belegPositionsGuid);

    public async Task<string> GetProduktionAsync(Guid guid)
        => await GetAsync<string>("Produktion/?posguid=" + guid);
}