using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class MaterialBearbeitungenWebRoutinen : WebRoutinenBase
{
    public MaterialBearbeitungenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<MaterialBearbeitungsMethodeDTO[]> GetAllAsync()
        => await GetAsync<MaterialBearbeitungsMethodeDTO[]>("MaterialBearbeitungsMethoden");

    public async Task SaveMethodeAsync(MaterialBearbeitungsMethodeDTO dto)
        => await PutAsync("MaterialBearbeitungsMethoden", dto);
}