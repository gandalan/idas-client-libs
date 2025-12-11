using System;
using System.Net.Http;
using System.Threading.Tasks;
using Gandalan.IDAS.Logging;

namespace Gandalan.IDAS.WebApi.Client.Settings;

public class ConnectHub
{
    private const string HubUrl = "https://connect.idas-cloudservices.net/api/EndPoints";

    [Obsolete("Call GetEndpointsAsync")]
    public async Task<HubResponse> GetEndpoints(string apiVersion = null, string env = null, string clientOs = null)
    {
        return await GetEndpointsAsync(apiVersion, env, clientOs);
    }

    public async Task<HubResponse> GetEndpointsAsync(string apiVersion = null, string env = null, string clientOs = null)
    {
        var requestUrl =
            $"{HubUrl}?{(apiVersion != null ? $"apiVersion={apiVersion}&" : "")}{(env != null ? $"env={env}&" : "")}{(clientOs != null ? $"clientOS={clientOs}" : "")}";
        try
        {
            var response = await new HttpClient().GetStringAsync(requestUrl);
            return System.Text.Json.JsonSerializer.Deserialize<HubResponse>(response);
        }
        catch (Exception e)
        {
            L.Fehler(e, $"Exception for GetEndpoints. Env: '{env}'");
            throw;
        }
    }
}
