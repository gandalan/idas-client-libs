using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class AnpassungenWebRoutinen : WebRoutinenBase
{
    public AnpassungenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<AnpassungDTO[]> GetAllAsync()
    {
        return await GetAsync<AnpassungDTO[]>("Anpassungen");
    }

    public async Task SaveAnpassungAsync(AnpassungDTO dto)
    {
        await PutAsync("Anpassungen/" + dto.AnpassungGuid, dto);
    }

    public async Task DeleteAnpassungAsync(Guid anpassungGuid)
    {
        await DeleteAsync("Anpassungen/" + anpassungGuid);
    }

    public async Task WebJob()
    {
        await PostAsync<string>("Anpassungen/WebJob", "");
    }
}