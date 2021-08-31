using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.WebJob;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class WebJobWebRoutinen : WebRoutinenBase
    {
        public WebJobWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public string AddHistorie(WebJobHistorieDTO historyDto)
        {
            return Post("Historie", historyDto);
        }
    }
}
