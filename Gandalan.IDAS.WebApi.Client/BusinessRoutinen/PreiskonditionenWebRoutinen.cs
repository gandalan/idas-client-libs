using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class PreiskonditionenWebRoutinen : WebRoutinenBase
{
    public PreiskonditionenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<PreisermittlungsEinstellungenDTO> GetPreiskonditionenAsync()
        => await GetAsync<PreisermittlungsEinstellungenDTO>("Preiskonditionen/");

    public async Task SavePreiskonditionenAsync(string konditionen)
        => await PutAsync<string>("Preiskonditionen/", konditionen);
}