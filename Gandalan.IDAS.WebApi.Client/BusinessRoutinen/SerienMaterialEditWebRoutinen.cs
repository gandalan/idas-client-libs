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
    public class SerienMaterialEditWebRoutinen : WebRoutinenBase
    {
        public SerienMaterialEditWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }
   
        public MaterialbedarfDTO AddOrUpdate(MaterialbedarfDTO dto)
        {
            if (Login())
            {
                return Put<MaterialbedarfDTO>("SerieMaterialbedarfEdit", dto);
            }
            return null;
        }

        public string DeleteMaterial(Guid materialbedarfGuid)
        {
            if (Login())
            {
                return Delete<string>("SerieMaterialbedarfEdit?serieGuid=" + materialbedarfGuid.ToString());
            }
            return null;
        }


        public async Task<MaterialbedarfDTO> AddOrUpdateAsync(MaterialbedarfDTO dto)
        {
            return await Task.Run(() => { return AddOrUpdate(dto); });
        }

        public async Task<string> DeleteMaterialAsync(Guid materialbedarfGuid)
        {
            return await Task.Run(() => { return DeleteMaterial(materialbedarfGuid); });
        }
    }
}
