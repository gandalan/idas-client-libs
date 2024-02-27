using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class LoginJwtRoutinen : WebRoutinenBase
    {
        public LoginJwtRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<string> AuthenticateAsync(LoginDTO dto)
            => await PostAsync<string>("LoginJwt/Authenticate", dto);

        public async Task<string> AuthenticateForFunctionAsync(string email)
            => await PostAsync<string>("LoginJwt/AuthenticateForFunction/?email=" + Uri.EscapeDataString(email), null);

        public async Task<string> RefreshAsync(string token)
            => await PutAsync<string>("LoginJwt/Refresh", token);

        public async Task<string> CreateServiceTokenAsync(CreateServiceTokenRequestDTO dto = null)
            => await PostAsync<string>("LoginJwt/CreateServiceToken", dto);
    }
}
