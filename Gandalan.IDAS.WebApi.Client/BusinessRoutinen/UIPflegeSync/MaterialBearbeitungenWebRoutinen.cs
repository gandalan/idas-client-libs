using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen.UIPflegeSync;

public class MaterialBearbeitungenWebRoutinen : WebRoutinenBase
{
    public MaterialBearbeitungenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<MaterialBearbeitungsMethodeDTO> GetAsync()
        => await GetAsync<MaterialBearbeitungsMethodeDTO>("MaterialBearbeitungsMethode/Get");

    public async Task SaveMethodeAsync(MaterialBearbeitungsMethodeDTO dto)
        => await PutAsync("MaterialBearbeitungsMethode/Create", dto);
}
