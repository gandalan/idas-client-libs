using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

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

    public async Task<UserAuthTokenDTO> GetFremdAppAuthTokenAsync(Guid fremdApp)
    {
        return await GetAsync<UserAuthTokenDTO>($"AuthToken/GetFremdAppAuthToken?fremdApp={fremdApp}");
    }
}
