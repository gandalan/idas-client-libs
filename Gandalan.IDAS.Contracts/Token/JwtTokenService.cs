using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using Gandalan.IDAS.WebApi.DTO;
using Microsoft.IdentityModel.Tokens;

namespace Gandalan.IDAS.Contracts.Token;

public class JwtTokenData
{
    /// <summary>
    /// Kennung des Benutzers: der <c>Benutzername</c>. Tokens, die vor #16404 ausgestellt wurden,
    /// tragen hier noch die Mailadresse - Service-Tokens laufen drei Jahre, also ist damit bis
    /// dahin zu rechnen.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Mailadresse des Benutzers, ausschliesslich fuer Mailversand und Anzeige. Null bei Tokens,
    /// die vor #16404 ausgestellt wurden - dort steckt die Mailadresse in <see cref="Id"/>.
    /// In 99% der Fälle ist Id und Email identisch.
    /// </summary>
    public string Email { get; set; }

    public Guid MandantGuid { get; set; }
    public DateTime Expires { get; set; }
    public Guid AppToken { get; set; }
    public Guid AuthToken { get; set; }
    public Guid? RefreshToken { get; set; }
    public TokenType TokenType { get; set; }
    public List<string> Roles { get; set; }
    public List<string> Rights { get; set; }
}

public class TokenParseResult
{
    public ParseStatus Status { get; set; }
    public JwtTokenData Token { get; set; }
}

public enum ParseStatus
{
    Empty,
    Invalid,
    Expired,
    Valid,
}

public enum TokenType
{
    Normal,
    Function,
    Service,
}

public class JwtTokenService
{
    private const string Issuer = "https://gandalan.de";
    private readonly DateTime? _issuedAt;
    private const string ClaimId = "id";
    private const string ClaimEmail = "email";
    private const string ClaimMandantGuid = "mandantGuid";
    private const string ClaimBenutzerGuid = "benutzerGuid";
    private const string ClaimAppToken = "appToken";
    private const string ClaimIdasAuthToken = "idasAuthToken";
    private const string ClaimRefreshToken = "refreshToken";
    private const string ClaimTokenType = "type";
    public static string ClaimRole = "role";
    public static string ClaimRights = "rights";

    public JwtTokenService(DateTime? issuedAt = null)
    {
        if (issuedAt != null)
        {
            _issuedAt = issuedAt;
        }
    }

    /// <summary>
    /// Generate JWT token
    /// </summary>
    /// <param name="authToken">User token</param>
    /// <param name="refreshToken">RefreshTokenDTO</param>
    /// <param name="privateKey">Private key</param>
    /// <param name="expireDateTime">Expiry date (optional, default: 5 minutes)</param>
    /// <param name="tokenType">Token type, default: Normal</param>
    /// <returns>Token string</returns>
    public string GenerateToken(UserAuthTokenDTO authToken, RefreshTokenDTO refreshToken, string privateKey, DateTime? expireDateTime = null, TokenType tokenType = TokenType.Normal)
    {
        if (string.IsNullOrWhiteSpace(privateKey))
        {
            throw new ArgumentNullException(nameof(privateKey));
        }

        var credentials = GetSigningCredentials(privateKey);

        // roles & rights
        var roleCodes = new List<string>();
        var rightCodes = new List<string>();
        if (authToken.Benutzer?.Rollen != null)
        {
            roleCodes = authToken.Benutzer.Rollen.Select(r => r.Name).ToList();
            rightCodes = authToken.Benutzer.Rollen.SelectMany(r => r.Berechtigungen.Select(b => b.Code)).Distinct().ToList();
        }

        // claims
        var rights = new List<Claim>();
        rights.AddRange(roleCodes.Select(c => new Claim(ClaimRole, c)));
        rights.AddRange(rightCodes.Select(c => new Claim(ClaimRights, c)));
        // #16404: `id` ist der Benutzername, nicht die Mailadresse. Die Mailadresse steht im
        // separaten `email`-Claim und ist nur fuer Mailversand und Anzeige gedacht.
        if (string.IsNullOrWhiteSpace(authToken.Benutzer?.Benutzername))
        {
            throw new ArgumentException("Benutzer.Benutzername muss gesetzt sein, er fuellt den id-Claim.", nameof(authToken));
        }

        rights.Add(new Claim(ClaimId, authToken.Benutzer.Benutzername));
        if (!string.IsNullOrWhiteSpace(authToken.Benutzer.EmailAdresse))
        {
            rights.Add(new Claim(ClaimEmail, authToken.Benutzer.EmailAdresse));
        }

        rights.Add(new Claim(ClaimMandantGuid, authToken.MandantGuid.ToString()));
        rights.Add(new Claim(ClaimAppToken, authToken.AppToken.ToString()));
        rights.Add(new Claim(ClaimBenutzerGuid, authToken.Benutzer.BenutzerGuid.ToString()));
        rights.Add(new Claim(ClaimIdasAuthToken, authToken.Token.ToString()));
        rights.Add(new Claim(ClaimRefreshToken, refreshToken.Token.ToString()));
        rights.Add(new Claim(ClaimTokenType, tokenType.ToString()));

        expireDateTime = expireDateTime ?? DateTime.UtcNow.AddMinutes(5);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(rights),
            NotBefore = new DateTime(2021, 1, 1),
            IssuedAt = _issuedAt ?? DateTime.UtcNow,
            Expires = expireDateTime,
            Issuer = Issuer,
            SigningCredentials = credentials,
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Parse token data
    /// </summary>
    /// <param name="token">Token string</param>
    /// <param name="publicKey">Public key</param>
    /// <param name="allowExpired">Default: false</param>
    /// <returns>Token data or null if token is invalid or expired</returns>
    public TokenParseResult ParseToken(string token, string publicKey, bool allowExpired = false)
    {
        if (string.IsNullOrEmpty(token))
        {
            return new TokenParseResult
            {
                Status = ParseStatus.Empty,
            };
        }

        try
        {
            var validations = ValidationParams(publicKey, allowExpired);
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, validations, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == ClaimId).Value;
            // Fehlt bei Tokens von vor #16404; dort traegt `id` die Mailadresse.
            var emailClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimEmail);
            var mandantGuidClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimMandantGuid);
            var appTokenClaim = jwtToken.Claims.First(x => x.Type == ClaimAppToken);
            var authTokenClaim = jwtToken.Claims.First(x => x.Type == ClaimIdasAuthToken);
            var refreshTokenClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimRefreshToken);
            var tokenTypeClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTokenType);
            var roles = jwtToken.Claims
                .Where(x => x.Type == ClaimRole)
                .Select(x => x.Value)
                .ToList();
            var rights = jwtToken.Claims
                .Where(x => x.Type == ClaimRights)
                .Select(x => x.Value)
                .ToList();

            return new TokenParseResult
            {
                Status = ParseStatus.Valid,
                Token = new JwtTokenData
                {
                    Id = userId,
                    Email = emailClaim?.Value,
                    Expires = validatedToken.ValidTo,
                    MandantGuid = mandantGuidClaim == null ? Guid.Empty : Guid.Parse(mandantGuidClaim.Value),
                    AppToken = appTokenClaim == null ? Guid.Empty : Guid.Parse(appTokenClaim.Value),
                    AuthToken = authTokenClaim == null ? Guid.Empty : Guid.Parse(authTokenClaim.Value),
                    RefreshToken = refreshTokenClaim == null ? Guid.Empty : Guid.Parse(refreshTokenClaim.Value),
                    TokenType = tokenTypeClaim == null ? TokenType.Normal : (TokenType)Enum.Parse(typeof(TokenType), tokenTypeClaim.Value),
                    Roles = roles,
                    Rights = rights,
                }
            };
        }
        catch (SecurityTokenExpiredException)
        {
            // token is expired
            return new TokenParseResult
            {
                Status = ParseStatus.Expired,
            };
        }
        catch (Exception)
        {
            // token is invalid
            return new TokenParseResult
            {
                Status = ParseStatus.Invalid,
            };
        }
    }

    /// <summary>
    /// Get token validation parameters
    /// </summary>
    /// <param name="publicKey">Public key</param>
    /// <param name="allowExpired">Default: false</param>
    /// <returns>Token validation parameters</returns>
    public TokenValidationParameters ValidationParams(string publicKey, bool allowExpired = false)
    {
        var issuerSigningKey = GetIssuerSigningKey(publicKey);

        var validationParams = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = !allowExpired,
            ValidIssuer = Issuer,
            IssuerSigningKey = issuerSigningKey,
        };

        return validationParams;
    }

    private static RsaSecurityKey GetIssuerSigningKey(string publicKey)
    {
        var rsa = RSA.Create();
        rsa.FromXmlString(publicKey);
        return new RsaSecurityKey(rsa);
    }

    private static SigningCredentials GetSigningCredentials(string privateKey)
    {
        var rsa = RSA.Create();
        rsa.FromXmlString(privateKey);

        return new SigningCredentials(
            key: new RsaSecurityKey(rsa),
            SecurityAlgorithms.RsaSha256Signature);
    }
}
