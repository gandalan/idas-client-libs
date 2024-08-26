using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Settings;

public class JwtWebApiSettings : WebApiSettings, IJwtWebApiConfig
{
    public string JwtToken { get; set; }

    [Obsolete("JWT:string parameter missing. Call InitializeAsync(Guid appToken, string env, string jwt)")]
    public override Task Initialize(Guid appToken, string env)
    {
        throw new NotSupportedException("JWT:string parameter missing");
    }

    public override Task InitializeAsync(Guid appToken, string env)
    {
        throw new NotSupportedException("JWT:string parameter missing");
    }

    [Obsolete("Call InitializeAsync")]
    public async Task Initialize(Guid appToken, string env, string jwt)
    {
        await InitializeAsync(appToken, env, jwt);
    }

    public async Task InitializeAsync(Guid appToken, string env, string jwt)
    {
        await base.InitializeAsync(appToken, env);
        var tokenHandler = new JwtSecurityTokenHandler();

        if (!tokenHandler.CanReadToken(jwt))
        {
            // JWT token has not a valid form
            return;
        }

        JwtToken = jwt;
        var jwtToken = tokenHandler.ReadJwtToken(jwt);
        var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
        var appTokenClaim = jwtToken.Claims.First(x => x.Type == "appToken");
        var authTokenClaim = jwtToken.Claims.First(x => x.Type == "idasAuthToken");

        // set settings values from JWT token
        UserName = userId;
        Mandant = "";
        AuthToken = new UserAuthTokenDTO
        {
            Token = Guid.Parse(authTokenClaim.Value),
            AppToken = Guid.Parse(appTokenClaim.Value),
        };
        AppToken = Guid.Parse(appTokenClaim.Value);
    }

    public override void CopyToThis(IWebApiConfig settings)
    {
        base.CopyToThis(settings);
        if (settings is JwtWebApiSettings jwtSettings)
        {
            JwtToken = jwtSettings.JwtToken;
        }
    }
}
