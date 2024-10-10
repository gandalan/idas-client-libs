using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen.UIPflegeSync;

public class MaterialWebRoutinen : WebRoutinenBase
{
    public MaterialWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<MaterialDTO> GetAsync()
        => await GetAsync<MaterialDTO>("Material/Get");

    public async Task SaveMaterialAsync(MaterialDTO dto)
        => await PutAsync("Material/Create", dto);
}
