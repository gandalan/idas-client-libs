using Gandalan.IDAS.WebApi.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts
{
    public interface IWebApiConfig
    {
        string Url { get; set; }
        string UserName { get; set; }
        [JsonIgnore]
        string Passwort { get; set; }
        [JsonIgnore]
        string Mandant { get; set; }
        UserAuthTokenDTO AuthToken { get; set; }
        [JsonIgnore]
        Guid AppToken { get; set; }
        string FriendlyName { get; set; }
        string DisplayText { get; }

        [JsonIgnore]
        Guid InstallationId { get; set; }
        [JsonIgnore]
        string UserAgent { get; set; }
        /// <summary>
        /// CMSUrl für Dokumente
        /// </summary>
        string DocUrl { get; set; }
        /// <summary>
        /// CMS für Variantenspez
        /// </summary>
        string CMSUrl { get; set; }
        /// <summary>
        /// Latex-Reports 
        /// </summary>
        string LatexReportUrl { get; set; }
        /// <summary>
        /// IBOS2-Varianten Produktionsberechnung 
        /// </summary>
        string I2Url { get; set; }
        /// <summary>
        /// IBOS1-Varianten Produktionsberechnung 
        /// </summary>
        string I1Url { get; set; }

        void Save();

        List<IWebApiConfig> GetAll();

        void CopyToThis(IWebApiConfig settings);

        Task<bool> Discover();
    }
}
