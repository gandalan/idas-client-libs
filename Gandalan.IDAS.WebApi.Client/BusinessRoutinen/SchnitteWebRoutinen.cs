using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class SchnitteWebRoutinen : WebRoutinenBase
{
    public SchnitteWebRoutinen(IWebApiConfig settings) : base(settings)
    {
            Settings.Url = Settings.Url.Replace("/api/", "/ModellDaten/");
        }

    public async Task<SchnittDTO[]> GetAllAsync()
        => await GetAsync<SchnittDTO[]>("Schnitt");

    public async Task SaveSchnittAsync(SchnittDTO dto)
        => await PutAsync("Schnitt", dto);
}