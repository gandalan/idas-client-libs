using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client;

public class MandantenWebRoutinen(IWebApiConfig settings) : WebRoutinenBase(settings)
{
    public async Task<MandantDTO> MandantenAnlegenAsync(MandantDTO mandant)
        => await PutAsync<MandantDTO>("Mandanten", mandant);
}
