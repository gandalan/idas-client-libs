using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class LoginJwtRoutinen : WebRoutinenBase
    {
        public LoginJwtRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public string Authenticate(LoginDTO dto)
        {
            return Post<string>("LoginJwt/Authenticate", dto);
        }

        public string AuthenticateForFunction(string email)
        {
            return Post<string>("LoginJwt/AuthenticateForFunction/?email=" + Uri.EscapeDataString(email), null);
        }

        public string Refresh(string token)
        {
            return Put<string>("LoginJwt/Refresh", token);
        }
    }
}
