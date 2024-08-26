using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Produktion;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class ProduktionsfreigabeListeWebRoutinen : WebRoutinenBase
{
    public ProduktionsfreigabeListeWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<ProduktionsfreigabeItemDTO[]> GetAllAsync()
        => await GetAsync<ProduktionsfreigabeItemDTO[]>("ProduktionsfreigabeListe");
}