using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen.UIPflegeSync;

public class OberflaechenWebRoutinen : WebRoutinenBase
{
    public OberflaechenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<OberflaecheDTO> GetAsync()
        => await GetAsync<OberflaecheDTO>("Oberflaeche/Get");

    public async Task SaveOberflaecheAsync(OberflaecheDTO dto)
        => await PutAsync("Oberflaeche/Create", dto);
}
