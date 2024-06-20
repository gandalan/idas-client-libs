using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class AuthTokenWebRoutinen : WebRoutinenBase
{
    public AuthTokenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task RemoveExpiredTokens()
    {
        await PostAsync("AuthToken/RemoveExpiredTokens", null);
    }
}