using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class MaterialBeschaffungsJobWebRoutinen : WebRoutinenBase
    {
        public MaterialBeschaffungsJobWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        /// <summary>
        /// Liefert alle MaterialItems (optional alle zu einem PCode)
        /// </summary>
        /// <returns>Liste von MaterialItemDTO</returns>  
        public MaterialBeschaffungsJobDTO[] GetAllMaterialBeschaffungsJob(string pcode = null)
        {
            if (Login())
            {
                return Get<MaterialBeschaffungsJobDTO[]>($"MaterialBeschaffungsJob/?pcode={pcode}");
            }
            return null;
        }

        /// <summary>
        /// Liefert ein MaterialItem (als Guid ist möglich: MaterialItemGuid, MaterialBeschaffungsJobGuid, BelegPositionGuid)
        /// </summary>
        /// <returns>MaterialItemDTO</returns>
        public MaterialBeschaffungsJobDTO[] GetMaterialBeschaffungsJob(Guid guid)
        {
            if (Login())
            {
                return Get<MaterialBeschaffungsJobDTO[]>($"MaterialBeschaffungsJob/?guid={guid}");
            }
            return null;
        }


        /// <summary>
        /// Liefert alle MaterialItems (optional alle zu einem PCode)
        /// </summary>
        /// <returns>Liste von MaterialItemDTO</returns>  
        public MaterialBeschaffungsJobDTO[] GetAllMaterialBeschaffungsJobBulk(string status = null)
        {
            if (Login())
            {
                return Get<MaterialBeschaffungsJobDTO[]>($"MaterialBeschaffungsJobBulk/?status={status}");
            }
            return null;
        }

        public string UpdateMaterialBeschaffungsJob(MaterialBeschaffungsJobDTO item)
        {
            if (Login())
            {
                return Put<string>("MaterialBeschaffungsJob", item);
            }
            return "Not logged in";
        }

        public string UpdateMaterialBeschaffungsJobBulk(List<MaterialBeschaffungsJobDTO> item)
        {
            if (Login())
            {
                return Put<string>("MaterialBeschaffungsJobBulk", item);
            }
            return "Not logged in";
        }

        /// <summary>
        /// Zum speichern eines neuen Jobs werden spezielle Berechtigungen gebraucht.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string SaveMaterialBeschaffungsJob(MaterialBeschaffungsJobDTO item)
        {
            if (Login())
            {
                return Post<string>("MaterialBeschaffungsJob", item);
            }
            return "Not logged in";
        }

        /// <summary>
        /// Zum speichern eines neuen Jobs werden spezielle Berechtigungen gebraucht.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string SaveMaterialBeschaffungsJobBulk(List<MaterialBeschaffungsJobDTO> item)
        {
            if (Login())
            {
                return Post<string>("MaterialBeschaffungsJobBulk", item);
            }
            return "Not logged in";
        }

        public string DeleteMaterialBeschaffungsJob(Guid guid)
        {
            if (Login())
            {
                return Delete($"MaterialBeschaffungsJob/{guid}");
            }
            return "Not logged in";
        }

        public List<Guid> DeleteMaterialBeschaffungsJobBulk(List<Guid> guid)
        {
            if (Login())
            {
                return Delete<List<Guid>>($"MaterialBeschaffungsJobBulk", guid);
            }
            return null;
        }

        public async Task<MaterialBeschaffungsJobDTO[]> GetAllMaterialBeschaffungsJobAsync(string pcode = null)
        {
            return await Task.Run(() => GetAllMaterialBeschaffungsJob(pcode));
        }

        public async Task<MaterialBeschaffungsJobDTO[]> GetAllMaterialBeschaffungsJobBulkAsync(string status = null)
        {
            return await Task.Run(() => GetAllMaterialBeschaffungsJobBulk(status));
        }
        public async Task<MaterialBeschaffungsJobDTO[]> GetMaterialBeschaffungsJobAsync(Guid guid)
        {
            return await Task.Run(() => GetMaterialBeschaffungsJob(guid));
        }
        public async Task<string> UpdateMaterialBeschaffungsJobAsync(MaterialBeschaffungsJobDTO item)
        {
            return await Task.Run(() => UpdateMaterialBeschaffungsJob(item));
        }
        public async Task<string> UpdateMaterialBeschaffungsJobBulkAsync(List<MaterialBeschaffungsJobDTO> item)
        {
            return await Task.Run(() => UpdateMaterialBeschaffungsJobBulk(item));
        }
        /// <summary>
        /// Zum speichern eines neuen Jobs werden spezielle Berechtigungen gebraucht.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<string> SaveMaterialBeschaffungsJobAsync(MaterialBeschaffungsJobDTO item)
        {
            return await Task.Run(() => SaveMaterialBeschaffungsJob(item));
        }
        /// <summary>
        /// Zum speichern eines neuen Jobs werden spezielle Berechtigungen gebraucht.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<string> SaveMaterialBeschaffungsJobBulkAsync(List<MaterialBeschaffungsJobDTO> item)
        {
            return await Task.Run(() => SaveMaterialBeschaffungsJobBulk(item));
        }
        public async Task<string> DeleteMaterialBeschaffungsJobAsync(Guid guid)
        {
            return await Task.Run(() => DeleteMaterialBeschaffungsJob(guid));
        }
        public async Task<List<Guid>> DeleteMaterialBeschaffungsJobBulkAsync(List<Guid> guid)
        {
            return await Task.Run(() => DeleteMaterialBeschaffungsJobBulk(guid));
        }
    }
}
