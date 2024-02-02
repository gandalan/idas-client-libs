using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FarbKuerzelWebRoutinen : WebRoutinenBase
    {
        public FarbKuerzelWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<FarbKuerzelDTO[]> GetAllAsync()
            => await GetAsync<FarbKuerzelDTO[]>("FarbKuerzel");

        public async Task SaveFarbKuerzelAsync(FarbKuerzelDTO dto)
            => await PutAsync("FarbKuerzel/" + dto.FarbKuerzelGuid, dto);
    }
}
