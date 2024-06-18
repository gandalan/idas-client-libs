using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class TemplateWebRoutinen : WebRoutinenBase
{
    public TemplateWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<TemplateDTO[]> GetAllAsync()
        => await GetAsync<TemplateDTO[]>("Template");

    public async Task<TemplateDTO> GetTemplateAsync(Guid id)
        => await GetAsync<TemplateDTO>($"Template?id={id}");

    public async Task SaveTemplateAsync(TemplateDTO dto)
        => await PutAsync($"Template/{dto.TemplateGuid}", dto);

    public async Task DeleteTemplateAsync(Guid templateGuid)
        => await DeleteAsync($"Template/{templateGuid}");
}