using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.WebJob;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class WebJobWebRoutinen : WebRoutinenBase
    {
        public WebJobWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task AddHistorie(WebJobHistorieDTO historyDto)
            => await PostAsync("Historie", historyDto);

        public async Task DeleteOldHistorie()
            => await GetAsync("Historie/DeleteOldHistorie");
    }
}
