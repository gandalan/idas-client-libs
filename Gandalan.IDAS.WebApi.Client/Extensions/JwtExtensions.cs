using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client;
using Gandalan.IDAS.WebApi.Client.Settings;

namespace System;

public static class JwtExtensions
{
    public static async Task<string> GetJwt(this IWebApiConfig config)
    {
        return await new WebRoutinenBase(config).GetJwt();
    }

    public static async Task<string> GetJwt(this WebRoutinenBase wrb)
    {
        var payload = new { Token = wrb.Settings.AuthToken.Token };
        var response = await wrb.PutAsync<string>("LoginJwt/Refresh", payload);
        return response;
    }

    public static async Task<IJwtWebApiConfig> ToJwtWebApiSettings(this IWebApiConfig config)
    {
        if (config is IJwtWebApiConfig jwtConfig)
        {
            return jwtConfig;
        }

        var newSettings = new JwtWebApiSettings();
        newSettings.CopyToThis(config);
        newSettings.JwtToken = await config.GetJwt();
        return newSettings;
    }
}
