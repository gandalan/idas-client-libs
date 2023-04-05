using Gandalan.IDAS.WebApi.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Gandalan.IDAS.Contracts.Token
{
    public class JwtTokenData
    {
        public string Id { get; set; }
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
        public const string TOKEN_COOKIE_NAME = "jwt-token";

        private string _issuer = "https://gandalan.de";
        private DateTime? _issuedAt = null;
        private string _claimId = "id";
        private string _claimMandantGuid = "mandantGuid";
        private string _claimBenutzerGuid = "benutzerGuid";
        private string _claimAppToken = "appToken";
        private string _claimIdasAuthToken = "idasAuthToken";
        private string _claimRefreshToken = "refreshToken";
        private string _claimTokenType = "type";
        private string _claimRole = "role";
        private string _claimRights = "rights";

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
        /// <param name="expireDateTime">Expiry date (optional, default: 7 days)</param>
        /// <param name="tokenType">Token type, default: Normal</param>
        /// <returns>Token string</returns>
        public string GenerateToken(UserAuthTokenDTO authToken, RefreshTokenDTO refreshToken, string privateKey, DateTime? expireDateTime = null, TokenType tokenType = TokenType.Normal)
        {
            if (string.IsNullOrWhiteSpace(privateKey))
            {
                throw new ArgumentNullException(nameof(privateKey));
            }

            var credentials = GetSigningCredentials(privateKey);

            // roles
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
            rights.AddRange(roleCodes.Select(c => new Claim(_claimRole, c)));
            rights.AddRange(rightCodes.Select(c => new Claim(_claimRights, c)));
            rights.Add(new Claim(_claimId, authToken.Benutzer.EmailAdresse));
            rights.Add(new Claim(_claimMandantGuid, authToken.MandantGuid.ToString()));
            rights.Add(new Claim(_claimAppToken, authToken.AppToken.ToString()));
            rights.Add(new Claim(_claimBenutzerGuid, authToken.Benutzer.BenutzerGuid.ToString()));
            rights.Add(new Claim(_claimIdasAuthToken, authToken.Token.ToString()));
            rights.Add(new Claim(_claimRefreshToken, refreshToken.Token.ToString()));
            rights.Add(new Claim(_claimTokenType, tokenType.ToString()));

            expireDateTime = expireDateTime ?? DateTime.UtcNow.AddMinutes(5);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(rights),
                NotBefore = DateTime.Parse("2021-01-01 00:00:00"),
                IssuedAt = _issuedAt ?? DateTime.UtcNow,
                Expires = expireDateTime,
                Issuer = _issuer,
                SigningCredentials = credentials
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
                tokenHandler.ValidateToken(token, validations, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == _claimId).Value;
                var mandantGuidClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == _claimMandantGuid);
                var appTokenClaim = jwtToken.Claims.First(x => x.Type == _claimAppToken);
                var authTokenClaim = jwtToken.Claims.First(x => x.Type == _claimIdasAuthToken);
                var refreshTokenClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == _claimRefreshToken);
                var tokenTypeClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == _claimTokenType);
                var roles = jwtToken.Claims
                    .Where(x => x.Type == _claimRole)
                    .Select(x => x.Value)
                    .ToList();
                var rights = jwtToken.Claims
                    .Where(x => x.Type == _claimRights)
                    .Select(x => x.Value)
                    .ToList();

                return new TokenParseResult()
                {
                    Status = ParseStatus.Valid,
                    Token = new JwtTokenData()
                    {
                        Id = userId,
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
                return new TokenParseResult()
                {
                    Status = ParseStatus.Expired
                };
            }
            catch (Exception)
            {
                // token is invalid
                return new TokenParseResult()
                {
                    Status = ParseStatus.Invalid
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
            RsaSecurityKey issuerSigningKey = GetIssuerSigningKey(publicKey);

            var validationParams = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = !allowExpired,
                ValidIssuer = _issuer,
                IssuerSigningKey = issuerSigningKey
            };

            return validationParams;
        }

        private RsaSecurityKey GetIssuerSigningKey(string publicKey)
        {
            var rsa = RSA.Create();
            rsa.FromXmlString(publicKey);
            return new RsaSecurityKey(rsa);
        }

        private SigningCredentials GetSigningCredentials(string privateKey)
        {
            var rsa = RSA.Create();
            rsa.FromXmlString(privateKey);

            return new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
