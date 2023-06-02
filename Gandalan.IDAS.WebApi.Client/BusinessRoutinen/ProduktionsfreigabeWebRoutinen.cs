using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktionsfreigabeWebRoutinen : WebRoutinenBase
    {
        public ProduktionsfreigabeWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<VorgangDTO> AddProduktionsfreigabeAsync(BelegartWechselDTO dto)
            => await PutAsync<VorgangDTO>("Produktionsfreigabe", dto);

        public async Task WebJob() 
            => await PostAsync("Produktionsfreigabe/WebJob", null);
    }
}
