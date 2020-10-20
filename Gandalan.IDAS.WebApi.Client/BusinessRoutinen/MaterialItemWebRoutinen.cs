using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class MaterialItemWebRoutinen : WebRoutinenBase
    {
        public MaterialItemWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        /// <summary>
        /// Liefert alle MaterialItems (optional alle zu einem PCode)
        /// </summary>
        /// <returns>Liste von MaterialItemDTO</returns>  
        public MaterialItemDTO[] GetAllMaterialItem(string pcode = null)
        {
            if (Login())
            {
                return Get<MaterialItemDTO[]>($"MaterialItem/?pcode={pcode}");
            }
            return null;
        }

        /// <summary>
        /// Liefert ein MaterialItem (als Guid ist möglich: MaterialItemGuid, MaterialBeschaffungsJobGuid, BelegPositionGuid)
        /// </summary>
        /// <returns>MaterialItemDTO</returns>
        public MaterialItemDTO[] GetMaterialItems(Guid guid)
        {
            if (Login())
            {
                return Get<MaterialItemDTO[]>($"MaterialItem/?guid={guid}");
            }
            return null;
        }

        public string SaveMaterialItem(MaterialItemDTO item)
        {
            if (Login())
            {
                return Put<string>("MaterialItem", item);
            }
            return "Not logged in";
        }

        /// <summary>
        /// Liefert alle MaterialItems (optional alle zu einem PCode)
        /// </summary>
        /// <returns>Liste von MaterialItemDTO</returns>  
        public MaterialItemDTO[] GetAllMaterialItemBulk(string status = null)
        {
            if (Login())
            {
                return Get<MaterialItemDTO[]>($"MaterialItemBulk/?status={status}");
            }
            return null;
        }

        public string SaveMaterialItemBulk(List<MaterialItemDTO> item)
        {
            if (Login())
            {
                return Put<string>("MaterialItemBulk", item);
            }
            return "Not logged in";
        }

        public string DeleteMaterialItem(Guid guid)
        {
            if (Login())
            {
                return Delete($"MaterialItem/{guid}");
            }
            return "Not logged in";
        }

        public List<Guid> DeleteMaterialItemBulk(List<Guid> guid)
        {
            if (Login())
            {
                return Delete<List<Guid>>($"MaterialItemBulk", guid);
            }
            return null;
        }

        public async Task<MaterialItemDTO[]> GetAllMaterialItemAsync(string pcode = null)
        {
            return await Task.Run(() => GetAllMaterialItem(pcode));
        }
        public async Task<MaterialItemDTO[]> GetMaterialItemsAsync(Guid guid)
        {
            return await Task.Run(() => GetMaterialItems(guid));
        }
        public async Task<string> SaveMaterialItemAsync(MaterialItemDTO item)
        {
            return await Task.Run(() => SaveMaterialItem(item));
        }

        public async Task<MaterialItemDTO[]> GetAllMaterialItemBulkAsync(string status = null)
        {
            return await Task.Run(() => GetAllMaterialItemBulk(status));
        }
        public async Task<string> SaveMaterialItemBulkAsync(List<MaterialItemDTO> item)
        {
            return await Task.Run(() => SaveMaterialItemBulk(item));
        }
        public async Task<string> DeleteMaterialItemAsync(Guid guid)
        {
            return await Task.Run(() => DeleteMaterialItem(guid));
        }
        public async Task<List<Guid>> DeleteMaterialItemBulkAsync(List<Guid> guid)
        {
            return await Task.Run(() => DeleteMaterialItemBulk(guid));
        }
    }
}
