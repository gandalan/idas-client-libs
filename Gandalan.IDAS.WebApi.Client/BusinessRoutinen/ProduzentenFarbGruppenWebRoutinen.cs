using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class ProduzentenFarbGruppenWebRoutinen : WebRoutinenBase
{
    public ProduzentenFarbGruppenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<ProduzentenFarbGruppeDTO[]> GetAllAsync()
        => await GetAsync<ProduzentenFarbGruppeDTO[]>("ProduzentenFarbGruppen");

    public async Task SaveProduzentenFarbGruppeAsync(ProduzentenFarbGruppeDTO dto)
        => await PutAsync("ProduzentenFarbGruppen/" + dto.ProduzentenFarbGruppeGuid, dto);

    public async Task DeleteProduzentenFarbGruppeAsync(Guid produzentenFarbGruppeGuid)
        => await DeleteAsync("ProduzentenFarbGruppen/" + produzentenFarbGruppeGuid);
}