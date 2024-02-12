using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class OberflaechenWebRoutinen : WebRoutinenBase
    {
        public OberflaechenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<OberflaecheDTO[]> GetAllAsync()
            => await GetAsync<OberflaecheDTO[]>("Oberflaeche");

        public async Task SaveOberflaecheAsync(OberflaecheDTO dto)
            => await PutAsync("Oberflaeche/" + dto.OberflaecheGuid, dto);
    }
}
