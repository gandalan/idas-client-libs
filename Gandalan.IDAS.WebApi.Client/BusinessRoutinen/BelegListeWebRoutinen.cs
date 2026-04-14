using System.Threading.Tasks;

using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BelegListeWebRoutinen(IWebApiConfig settings) : WebRoutinenBase(settings)
{
    public async Task<VorgangDTO> GetBelegListAsync(int jahr = 0, string belegart = null, string kundennummer = null, bool includeArchive = true)
        => await GetAsync<VorgangDTO>($"BelegListe?jahr={jahr}&belegart={belegart}&kundennummer={kundennummer}&includeArchive={includeArchive}");
}
