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

        public async Task<HubResponse> GetEndpoints(string apiVersion = null, string env = null, string clientOS = null)
        {
            var requestURL =
                HubUrl + "?" +
                (apiVersion != null ? "apiVersion=" + apiVersion + "&" : "") +
                (env != null ? "env=" + env + "&" : "") +
                (clientOS != null ? "clientOS=" + clientOS : "");
            try
            {
                var response = await new HttpClient().GetStringAsync(requestURL);
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
