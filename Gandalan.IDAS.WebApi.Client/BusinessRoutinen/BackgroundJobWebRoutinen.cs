using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BackgroundJobWebRoutinen : WebRoutinenBase
    {
        public BackgroundJobWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public string Update(FeedbackDTO payload)
        {
            return Post("BackgroundJob/Post", payload);
        }
    }
}
