using System;
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
    /// List of API endpoints configured to use the new backend API on remote calls.
    /// Each entry specifies the endpoint path and optionally the allowed HTTP methods.
    /// This list must be maintained by clients. Available endpoints that can be used with the new API will be announced.
    /// </summary>
    string[] NewApiOptInUrls { get; set; }

    /// <summary>
    /// Sends <c>X-Gateway-Cluster: legacy</c> on every request, so the gateway routes it to the legacy API even
    /// where the new API is its default. Takes precedence over <see cref="NewApiOptInUrls"/>. A local client
    /// decision, never delivered by the hub, therefore not copied by <see cref="CopyToThis"/>.
    /// </summary>
    bool ForceLegacyApi { get; set; }

    void CopyToThis(IWebApiConfig settings);
}
