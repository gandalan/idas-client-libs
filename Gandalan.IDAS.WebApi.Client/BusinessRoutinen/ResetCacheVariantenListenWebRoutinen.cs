using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class ResetCacheVariantenListenWebRoutinen : WebRoutinenBase
{
    public ResetCacheVariantenListenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task ResetAsync(bool onlyCache = false)
        => await PutAsync($"ResetCacheVariantenListen?onlyCache={onlyCache}", null);
}
