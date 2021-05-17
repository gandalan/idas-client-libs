using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class SerienMaterialWebRoutinen : WebRoutinenBase
    {
        public SerienMaterialWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public string MaterialBerechnen(Guid serieGuid)
        {
            if (Login())
            {
                return Post<string>("SerieMaterialbedarf", JsonConvert.SerializeObject(serieGuid));
            }
            return null;
        }
        
        public List<MaterialbedarfDTO> GetMaterial(Guid serieGuid)
        {
            if (Login())
            {
                return Get<List<MaterialbedarfDTO>>("SerieMaterialbedarf?serieGuid=" + serieGuid.ToString());
            }
            return null;
        }

        public string ResetMaterial(Guid serieGuid)
        {
            if (Login())
            {
                return Get<string>("SerieMaterialbedarf?serieGuid=" + serieGuid.ToString());
            }
            return null;
        }


        public async Task<List<MaterialbedarfDTO>> GetMaterialAsync(Guid serieGuid)
        {
            return await Task<List<MaterialbedarfDTO>>.Run(() => { return GetMaterial(serieGuid); });
        }

        public async Task<string> ResetMaterialAsync(Guid serieGuid)
        {
            return await Task<string>.Run(() => { return ResetMaterial(serieGuid); });
        }
        
        public async Task<string> MaterialBerechnenAsync(Guid serieGuid)
        {
            return await Task<string>.Run(() => { return MaterialBerechnen(serieGuid); });
        }
    }
}
