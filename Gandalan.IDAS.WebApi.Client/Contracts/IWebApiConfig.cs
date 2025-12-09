using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;
using Newtonsoft.Json;

namespace Gandalan.IDAS.Client.Contracts.Contracts;

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
    [JsonIgnore]
    bool UseCompression { get; set; }

    /// <summary>
    /// Base IDAS Url
    /// </summary>
    [JsonIgnore]
    string IDASUrl { get; set; }

    /// <summary>
    /// CMSUrl für Dokumente
    /// </summary>
    string DocUrl { get; set; }

    /// <summary>
    /// CMS für Variantenspez
    /// </summary>
    string CMSUrl { get; set; }

    /// <summary>
    /// Package Store
    /// </summary>
    string StoreUrl { get; set; }

    /// <summary>
    /// Feedback-Tool
    /// </summary>
    string FeedbackUrl { get; set; }

    string NotifyUrl { get; set; }
    string HelpCenterUrl { get; set; }
    string WebhookServiceUrl { get; set; }

    string TranslateUrl { get; set; }

    /// <summary>
    /// List of API endpoints (e.g., /api/VorgangListe) configured to use the new backend API on remote calls.
    /// This list must be maintained by clients. Available endpoints that can be used with the new API will be announced.
    /// </summary>
    List<string> NewApiOptInUrls { get; set; }

    void CopyToThis(IWebApiConfig settings);
}
