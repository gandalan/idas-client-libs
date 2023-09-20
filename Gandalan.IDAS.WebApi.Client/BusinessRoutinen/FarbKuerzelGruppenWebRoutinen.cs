using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FarbKuerzelGruppenWebRoutinen : WebRoutinenBase
    {
        public FarbKuerzelGruppenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<FarbKuerzelGruppeDTO[]> GetAllAsync()
            => await GetAsync<FarbKuerzelGruppeDTO[]>("FarbKuerzelGruppe");

        public async Task SaveFarbKuerzelGruppeAsync(FarbKuerzelGruppeDTO dto)
            => await PutAsync("FarbKuerzelGruppe/", dto);
    }
}
