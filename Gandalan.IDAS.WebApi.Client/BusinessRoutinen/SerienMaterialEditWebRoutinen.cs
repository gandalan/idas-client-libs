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

        public async Task<SerienMaterialEditDTO> AddOrUpdateAsync(MaterialbedarfDTO dto) 
            => await PutAsync<SerienMaterialEditDTO>("SerieMaterialbedarfEdit", dto);

        public async Task DeleteMaterialAsync(Guid materialbedarfGuid) 
            => await DeleteAsync($"SerieMaterialbedarfEdit?bedarfGuid={materialbedarfGuid}");
    }
}
