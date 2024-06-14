using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class KonturenWebRoutinen : WebRoutinenBase
{
    public KonturenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
            Settings.Url = Settings.Url.Replace("/api/", "/ModellDaten/");
        }

    public async Task<KonturDTO[]> GetAllAsync()
        => await GetAsync<KonturDTO[]>("Kontur");

    public async Task SaveKonturAsync(KonturDTO dto)
        => await PutAsync("Kontur", dto);
}