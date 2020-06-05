using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{

    public class AblageFachWebRoutinen : WebRoutinenBase
    {
        public AblageFachWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public AblageFachDTO Get(Guid guid)
        {
            if (Login())
            {
                return Get<AblageFachDTO>("AblageFach/?id=" + guid.ToString());
            }
            return null;
        }

        public List<AblageFachDTO> GetAll(DateTime? changedSince)
        {
            if (Login())
            {
                if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
                {
                    return Get<List<AblageFachDTO>>("AblageFach?changedSince=" + changedSince.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                else
                {
                    return Get<List<AblageFachDTO>>("AblageFach");
                }
            }
            return null;
        }
                
        public string Save(AblageFachDTO dto)
        {
            if (Login())
            {
                return Put("AblageFach/", dto);
            }
            return null;
        }

        public string Delete(Guid guid)
        {
            if (Login())
            {
                return Delete("AblageFach/?id=" + guid.ToString());
            }
            return "Not logged in";
        }


        public async Task<AblageFachDTO> GetAsync(Guid guid)
        {
            return await Task.Run(() => Get(guid));
        }

        public async Task<List<AblageFachDTO>> GetAllAsync(DateTime? changedSince)
        {
            return await Task.Run(() => GetAll(changedSince));
        }

        public async Task SaveAsync(AblageFachDTO dto)
        {
            await Task.Run(() => Save(dto));
        }

        public async Task<string> DeleteAsync(Guid guid)
        {
            return await Task.Run(() => Delete(guid));
        }
    }
}