using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Gandalan.IDAS.WebApi.Client.Settings
{
    public class JwtWebApiSettings : WebApiSettings, IJwtWebApiConfig
    {
        public string JwtToken { get; set; }

        public JwtWebApiSettings(Guid appToken, string env, string jwt)
            : base(appToken, env)
        {
            Initialize(jwt);
            JwtToken = jwt;
        }

        public JwtWebApiSettings(string jwt)
            : base()
        {
            Initialize(jwt);
            JwtToken = jwt;
        }

        private void Initialize(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!tokenHandler.CanReadToken(jwt))
            {
                // JWT token has not a valid form
                return;
            }

            var jwtToken = tokenHandler.ReadJwtToken(jwt);
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
            var appTokenClaim = jwtToken.Claims.First(x => x.Type == "appToken");
            var authTokenClaim = jwtToken.Claims.First(x => x.Type == "idasAuthToken");
            var roles = jwtToken.Claims
                .Where(x => x.Type == "role")
                .Select(x => x.Value)
                .ToList();

            // set settings values from JWT token
            UserName = userId;
            Mandant = "";
            AuthToken = new UserAuthTokenDTO()
            {
                Token = Guid.Parse(authTokenClaim.Value),
                AppToken = Guid.Parse(appTokenClaim.Value),
            };
            AppToken = Guid.Parse(appTokenClaim.Value);
        }
    }
}
