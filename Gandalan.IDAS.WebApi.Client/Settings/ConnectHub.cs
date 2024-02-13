using System;
using System.Net.Http;
using System.Threading.Tasks;
using Gandalan.IDAS.Logging;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.Settings
{
    public class ConnectHub
    {
        private const string HubUrl = "https://connect.idas-cloudservices.net/api/EndPoints";

        public async Task<HubResponse> GetEndpoints(string apiVersion = null, string env = null, string clientOs = null)
        {
            var requestUrl =
                HubUrl + "?" +
                (apiVersion != null ? "apiVersion=" + apiVersion + "&" : "") +
                (env != null ? "env=" + env + "&" : "") +
                (clientOs != null ? "clientOS=" + clientOs : "");
            try
            {
                var response = await new HttpClient().GetStringAsync(requestUrl);
                return JsonConvert.DeserializeObject<HubResponse>(response);
            }
            catch (Exception e)
            {
                Logger.LogConsoleDebug($"{e}");
                throw;
            }
        }
    }
}
