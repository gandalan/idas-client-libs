namespace Gandalan.IDAS.Client.Contracts.Contracts;

internal interface IJwtWebApiConfig : IWebApiConfig
{
    string JwtToken { get; set; }
}