using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Logging;
using Gandalan.IDAS.WebApi.DTO;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.Settings;

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
    [JsonIgnore]
    public bool UseCompression { get; set; }

    /// <summary>
    /// CMSUrl für Dokumente
    /// </summary>
    public string DocUrl { get; set; }

    /// <summary>
    /// CMS für Variantenspez
    /// </summary>
    public string CMSUrl { get; set; }

    /// <summary>
    /// Paket-Store
    /// </summary>
    public string StoreUrl { get; set; }

    /// <summary>
    /// Feedback-Tool
    /// </summary>
    public string FeedbackUrl { get; set; }

    public string NotifyUrl { get; set; }
    public string HelpCenterUrl { get; set; }
    public string WebhookServiceUrl { get; set; }
    public string TranslateUrl { get; set; }

    /// <remarks>
    /// Remember to call <see cref="WebApiConfigurations.InitializeAsync"/> before.
    /// </remarks>
    [Obsolete("Call InitializeAsync")]
    public virtual async Task Initialize(Guid appToken, string env)
    {
        await InitializeAsync(appToken, env);
    }

    /// <remarks>
    /// Remember to call <see cref="WebApiConfigurations.InitializeAsync"/> before.
    /// </remarks>
    public virtual async Task InitializeAsync(Guid appToken, string env)
    {
        try
        {
            if (appToken.Equals(Guid.Empty))
            {
                throw new ArgumentException("WebApiSettings: AppToken must not be Guid.Empty", nameof(appToken));
            }

            if (string.IsNullOrEmpty(env))
            {
                throw new ArgumentNullException(nameof(env), "WebApiSettings: Environment must not be null or empty");
            }

            var settings = WebApiConfigurations.ByName(env);
            if (settings != null)
            {
                CopyToThis(settings);
            }

            await Task.CompletedTask;
        }
        catch (Exception e)
        {
            // Non awaitable callers will not see exception thrown here, but we will always have logged exception
            L.Fehler(e, $"Exception in InitializeAsync. Env: '{env}'");
            throw;
        }
    }

    public virtual void CopyToThis(IWebApiConfig settings)
    {
        AppToken = settings.AppToken;
        AuthToken = settings.AuthToken;
        FriendlyName = settings.FriendlyName;
        Mandant = settings.Mandant;
        Passwort = settings.Passwort;
        UserName = settings.UserName;
        InstallationId = settings.InstallationId;
        UserAgent = settings.UserAgent;

        Url = settings.Url;
        CMSUrl = settings.CMSUrl;
        DocUrl = settings.DocUrl;
        FeedbackUrl = settings.FeedbackUrl;
        StoreUrl = settings.StoreUrl;
        NotifyUrl = settings.NotifyUrl;
        HelpCenterUrl = settings.HelpCenterUrl;
        TranslateUrl = settings.TranslateUrl;
    }
}
