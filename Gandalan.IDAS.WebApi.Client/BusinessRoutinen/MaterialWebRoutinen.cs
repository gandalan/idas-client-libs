using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class MaterialWebRoutinen : WebRoutinenBase
    {
        public MaterialWebRoutinen(IWebApiConfig settings) : base(settings)
        {
            Settings.Url = Settings.Url.Replace("/api/", "/ModellDaten/");
        }

        public async Task<MaterialDTO[]> GetAllAsync()
            => await GetAsync<MaterialDTO[]>("Material");

        public async Task SaveMaterialAsync(MaterialDTO dto)
            => await PutAsync("Material", dto);
    }
}
