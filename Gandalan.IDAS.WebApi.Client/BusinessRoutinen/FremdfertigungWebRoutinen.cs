using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class FremdfertigungWebRoutinen : WebRoutinenBase
{
    public FremdfertigungWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task Bestellen(Guid bguid)
        => await PutAsync($"Fremdfertigung/?bguid={bguid}", null);
}
