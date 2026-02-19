#nullable enable
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.SSO;

public class SsoLoginService : ISsoLoginService
{
    private readonly IWebApiConfig _settings;
    private readonly int _timeoutSeconds;

    public SsoLoginService(IWebApiConfig settings, int timeoutSeconds = 120)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _timeoutSeconds = timeoutSeconds;
    }

    public async Task<SsoLoginResult> LoginAsync(
        Guid appGuid,
        Action<string>? logger = null,
        Func<string, bool>? openBrowser = null)
    {
        if (appGuid == Guid.Empty)
        {
            return new SsoLoginResult
            {
                Success = false,
                ErrorMessage = "AppGuid must not be empty."
            };
        }

        using var server = new SsoCallbackServer(_timeoutSeconds);
        await server.StartAsync();

        var ssoUrl = BuildSsoUrl(appGuid, server.CallbackUrl + "?token=%token%");
        
        var browserOpened = false;
        try
        {
            if (openBrowser != null)
            {
                browserOpened = openBrowser(ssoUrl);
            }
            else
            {
                Process.Start(new ProcessStartInfo(ssoUrl) { UseShellExecute = true });
                browserOpened = true;
            }
        }
        catch (Exception ex)
        {
            logger?.Invoke($"Could not open browser automatically: {ex.Message}");
        }

        if (browserOpened)
        {
            logger?.Invoke("Browser opened. Please log in...");
        }
        else
        {
            logger?.Invoke("Please open the SSO URL manually to continue the login.");
            logger?.Invoke($"SSO URL: {ssoUrl}");
        }

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(_timeoutSeconds));
        string token;
        
        try
        {
            token = await server.WaitForTokenAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            return new SsoLoginResult
            {
                Success = false,
                ErrorMessage = $"Login timeout - no token received within {_timeoutSeconds} seconds."
            };
        }

        if (string.IsNullOrWhiteSpace(token) || !Guid.TryParse(token, out var tokenGuid))
        {
            return new SsoLoginResult
            {
                Success = false,
                ErrorMessage = "Invalid login token received from SSO callback."
            };
        }

        var initialAuthToken = new UserAuthTokenDTO
        {
            Token = tokenGuid,
            AppToken = appGuid
        };

        _settings.AuthToken = initialAuthToken;

        var client = new WebRoutinenBase(_settings);
        client.IgnoreOnErrorOccured = true;

        try
        {
            var refreshedToken = await client.RefreshTokenAsync(tokenGuid);

            if (refreshedToken != null)
            {
                _settings.AuthToken = refreshedToken;
                logger?.Invoke($"Login successful: User={_settings.UserName}, Mandant={_settings.AuthToken.Mandant?.Name}");
                
                return new SsoLoginResult
                {
                    Success = true,
                    AuthToken = refreshedToken
                };
            }
            else
            {
                // Restore previous token on failure
                _settings.AuthToken = initialAuthToken;
                return new SsoLoginResult
                {
                    Success = false,
                    ErrorMessage = "Could not refresh token from server."
                };
            }
        }
        catch (Exception ex)
        {
            // Restore previous token on failure
            _settings.AuthToken = initialAuthToken;
            var errorMsg = ex.InnerException?.Message ?? ex.Message;
            return new SsoLoginResult
            {
                Success = false,
                ErrorMessage = $"Login error: {errorMsg}"
            };
        }
    }

    public string BuildSsoUrl(Guid appGuid)
    {
        return BuildSsoUrl(appGuid, null);
    }

    private string BuildSsoUrl(Guid appGuid, string? callbackUrl)
    {
        var baseUrl = _settings.IDASUrl?.TrimEnd('/') ?? _settings.Url?.TrimEnd('/');
        if (string.IsNullOrEmpty(baseUrl))
        {
            throw new InvalidOperationException("IDASUrl or Url must be set in settings.");
        }

        var idasUri = new Uri(baseUrl);
        var hostUrl = $"{idasUri.Scheme}://{idasUri.Host}";
        
        if (!idasUri.IsDefaultPort)
        {
            hostUrl += $":{idasUri.Port}";
        }

        if (string.IsNullOrEmpty(callbackUrl))
        {
            return $"{hostUrl}/SSO?a={appGuid}";
        }

        var redirectUrl = Uri.EscapeDataString(callbackUrl);
        return $"{hostUrl}/SSO?a={appGuid}&r={redirectUrl}";
    }
}
