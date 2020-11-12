using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Discovery;
using Gandalan.IDAS.WebApi.DTO;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.Settings
{
    [ComVisible(true)]
    public class WebApiSettings : IWebApiConfig
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Passwort { get; set; }
        [JsonIgnore]
        public string Mandant { get; set; }
        public UserAuthTokenDTO AuthToken { get; set; }
        [JsonIgnore]
        public Guid AppToken { get; set; }
        public string FriendlyName { get; set; }
        public string DisplayText => $"{UserName}@{new Uri(Url).Host}";

        [JsonIgnore]
        public Guid InstallationId { get; set; }
        [JsonIgnore]
        public string UserAgent { get; set; }
        /// <summary>
        /// CMSUrl für Dokumente
        /// </summary>
        public string DocUrl { get; set; }
        /// <summary>
        /// CMS für Variantenspez
        /// </summary>
        public string CMSUrl { get; set; }
        /// <summary>
        /// Latex-Reports 
        /// </summary>
        public string LatexReportUrl { get; set; }
        /// <summary>
        /// IBOS2-Varianten Produktionsberechnung 
        /// </summary>
        public string I2Url { get; set; }
        /// <summary>
        /// IBOS1-Varianten Produktionsberechnung 
        /// </summary>
        public string I1Url { get; set; }

        public WebApiSettings(Guid appToken, string env)
        {
            WebApiFileConfig.Initialize(appToken);
            IWebApiConfig settings = WebApiFileConfig.ByName(env);
            CopyToThis(settings);
        }

        public WebApiSettings() { }

        public void Save()
        {
            WebApiFileConfig.Save(this);
        }

        public List<IWebApiConfig> GetAll()
        {
            return WebApiFileConfig.GetAll();
        }

        public void CopyToThis(IWebApiConfig settings)
        {
            this.AppToken = settings.AppToken;
            this.AuthToken = settings.AuthToken;
            this.FriendlyName = settings.FriendlyName;
            this.Mandant = settings.Mandant;
            this.Url = settings.Url;
            this.CMSUrl = settings.CMSUrl;
            this.DocUrl = settings.DocUrl;
            this.Passwort = settings.Passwort;
            this.UserName = settings.UserName;
            this.InstallationId = settings.InstallationId;
            this.UserAgent = settings.UserAgent;
            this.I1Url = settings.I1Url;
            this.I2Url = settings.I2Url;
        }


        public async Task<bool> Discover()
        {
            if (await ServerDiscovery.ExecuteUDP())
            {
                Url = ServerDiscovery.WebAPIBaseURL;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
