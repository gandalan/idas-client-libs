using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.Farben;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class FarbgruppenaufpreisWebRoutinen : WebRoutinenBase
{
    public FarbgruppenaufpreisWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<FarbgruppenaufpreiseDTO[]> GetAsync()
        => await GetAsync<FarbgruppenaufpreiseDTO[]>("Farbgruppenaufpreis");

    public async Task SaveFarbgruppenaufpreiseAsync(FarbgruppenaufpreiseDTO dto)
        => await PutAsync("Farbgruppenaufpreis", dto);
}