using System;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Refresh token for JWT
/// </summary>
public class RefreshTokenDTO
{
    /// <summary>
    /// Token GUID
    /// </summary>
    public Guid Token { get; set; }

    /// <summary>
    /// Token expire date
    /// </summary>
    public DateTime Expires { get; set; }

    /// <summary>
    /// Related UserToken GUID
    /// </summary>
    public Guid UserTokenGuid { get; set; }

    /// <summary>
    /// Related UserToken object
    /// </summary>
    public UserAuthTokenDTO UserToken { get; set; }

    /// <summary>
    /// App token
    /// </summary>
    public Guid AppToken { get; set; }
}
