#nullable enable
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.SSO;

public class SsoLoginResult
{
    public bool Success { get; set; }
    public UserAuthTokenDTO? AuthToken { get; set; }
    public string? ErrorMessage { get; set; }
    public string? UserName => AuthToken?.Benutzer?.Benutzername;
    public string? MandantName => AuthToken?.Mandant?.Name;
}
