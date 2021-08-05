using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AuthTokenWebRoutinen : WebRoutinenBase
    {
        public AuthTokenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public string RemoveExpiredTokens()
        {
            return Post("AuthToken/RemoveExpiredTokens", null);
        }
    }
}
