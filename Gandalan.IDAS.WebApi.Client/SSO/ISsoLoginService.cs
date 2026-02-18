#nullable enable
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.SSO;

public interface ISsoLoginService
{
    Task<SsoLoginResult> LoginAsync(
        Guid appGuid,
        Action<string>? logger = null,
        Func<string, bool>? openBrowser = null);
    string BuildSsoUrl(Guid appGuid);
}
