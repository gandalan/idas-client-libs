using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.Settings
{
    public class ConnectHub
    {
        private static readonly string _hubURL = "https://connect.idas-cloudservices.net/api/EndPoints";

        public async Task<HubResponse> GetEndpoints(string apiVersion = null, string env = null, string clientOS = null)
        {
            var requestURL = 
                _hubURL + "?" +
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
