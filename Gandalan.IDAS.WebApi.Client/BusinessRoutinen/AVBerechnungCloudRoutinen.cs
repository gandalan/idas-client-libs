using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AVBerechnungCloudRoutinen : WebRoutinenBase
    {
        public AVBerechnungCloudRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<BerechnungParameterDTO> ProcessAsync(BerechnungParameterDTO parameter)
        {
            return await PostAsync<BerechnungParameterDTO>($"ProcessIbos/Process", parameter);
        }
    }
}
