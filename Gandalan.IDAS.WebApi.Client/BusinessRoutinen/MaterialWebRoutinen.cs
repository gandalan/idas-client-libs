using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class MaterialWebRoutinen : WebRoutinenBase
    {
        public MaterialWebRoutinen(IWebApiConfig settings) : base(settings)
        {
            this.Settings.Url = this.Settings.Url.Replace("/api/", "/ModellDaten/");
        }

        public MaterialDTO[] GetAll()
        {
            if (Login())
            {
                return Get<MaterialDTO[]>("Material");
            }
            return null;
        }

        public string SaveMaterial(MaterialDTO dto)
        {
            if (Login())
            {
                return Put("Material", dto);
            }
            return null;
        }


        public async Task<MaterialDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task SaveMaterialAsync(MaterialDTO dto)
        {
            await Task.Run(() => SaveMaterial(dto));
        }
    }
}
