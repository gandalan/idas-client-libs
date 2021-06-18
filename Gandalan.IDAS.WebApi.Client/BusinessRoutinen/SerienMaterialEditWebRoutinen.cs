using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.Data.DTOs.AV;
using Gandalan.IDAS.WebApi.DTO;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class SerienMaterialEditWebRoutinen : WebRoutinenBase
    {
        public SerienMaterialEditWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }
   
        public MaterialbedarfDTO AddOrUpdate(SerienMaterialEditDTO dto)
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
                return Delete<string>("SerieMaterialbedarfEdit?bedarfGuid=" + materialbedarfGuid.ToString());
            }
            return null;
        }


        public async Task<MaterialbedarfDTO> AddOrUpdateAsync(MaterialbedarfDTO dto)
        {
            if (Login())
            {
                return await PutAsync<MaterialbedarfDTO>("SerieMaterialbedarfEdit", dto);
            }
            return null;
        }

        public async Task<string> DeleteMaterialAsync(Guid materialbedarfGuid)
        {
            if (Login())
            {
                return await DeleteAsync<string>("SerieMaterialbedarfEdit?bedarfGuid=" + materialbedarfGuid.ToString());
            }
            return null;
        }
    }
}
