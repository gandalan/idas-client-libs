using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class KonfigSatzInfoWebRoutinen : WebRoutinenBase
{
    public KonfigSatzInfoWebRoutinen(IWebApiConfig settings) : base(settings) { }

    public async Task<KonfigSatzInfoDTO[]> GetAllAsync()
        => await GetAsync<KonfigSatzInfoDTO[]>("KonfigSatzInfo");

    public async Task SaveKonfigSatzInfoAsync(KonfigSatzInfoDTO konfigSatzInfo)
        => await PutAsync<KonfigSatzInfoDTO>("KonfigSatzInfo", konfigSatzInfo);

    [Obsolete("Funktion 'SaveKonfigSatzInfoAsync()' verwenden")]
    public async Task SaveAsync(KonfigSatzInfoDTO dto)
        => await PutAsync("KonfigSatzInfo", dto);
}