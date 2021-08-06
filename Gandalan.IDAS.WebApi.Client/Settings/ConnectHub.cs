using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.Settings
{
    internal class ConnectHub
    {
        private static readonly string _hubURL = "https://connect.idas-cloudservices.net/api/EndPoints";

        public string ApiVersion { get; set; }
        public string EnvironmentName { get; set; }
        public string ClientOS { get; set; }

        public ConnectHub(string apiVersion = null, string env = null, string clientOS = null)
        {
            ApiVersion = apiVersion;
            EnvironmentName = env;
            ClientOS = clientOS ?? "win";
        }

        public HubResponse GetEndpoints(string apiVersion = null, string env = null, string clientOS = null)
        {
            var requestURL = getRequestURL(apiVersion, env, clientOS);
            try
            {
                var response = new WebClient().DownloadString(requestURL);
                return JsonConvert.DeserializeObject<HubResponse>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public async Task<HubResponse> GetEndpointsAsync(string apiVersion = null, string env = null, string clientOS = null)
        {
            var requestURL = getRequestURL(apiVersion, env, clientOS);
            try
            {
                HttpClient httpClient = new HttpClient();                
                string result = await httpClient.GetStringAsync(requestURL);
                // SM: überarbeiten
                // HttpResponseMessage responseMessage = await httpClient.GetAsync(requestURL);
                // return JsonConvert.DeserializeObject<HubResponse>(await responseMessage.Content.ReadAsStringAsync());
                return JsonConvert.DeserializeObject<HubResponse>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        #region private methods
        private string getRequestURL(string apiVersion = null, string env = null, string clientOS = null)
        {
            return _hubURL + "?" +
                (apiVersion != null ? "apiVersion=" + apiVersion + "&" : "") + 
                (env != null ? "env=" + env + "&" : "") + 
                (clientOS != null ? "clientOS=" + clientOS : "");
        }
        #endregion private methods
    }
}
