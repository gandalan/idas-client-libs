namespace Gandalan.IDAS.Client.Contracts.Contracts;

public interface IJwtWebApiConfig : IWebApiConfig
{
    string JwtToken { get; set; }
}
