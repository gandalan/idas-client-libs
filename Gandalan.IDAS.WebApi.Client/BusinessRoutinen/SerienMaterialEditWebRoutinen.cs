using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.AV;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class SerienMaterialEditWebRoutinen : WebRoutinenBase
    {
        public SerienMaterialEditWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }
   
        public SerienMaterialEditDTO AddOrUpdate(SerienMaterialEditDTO dto)
        {
            if (Login())
            {
                return Put<SerienMaterialEditDTO>("SerieMaterialbedarfEdit", dto);
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


        public async Task<SerienMaterialEditDTO> AddOrUpdateAsync(MaterialbedarfDTO dto)
        {
            if (Login())
            {
                return await PutAsync<SerienMaterialEditDTO>("SerieMaterialbedarfEdit", dto);
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
