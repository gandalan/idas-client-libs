using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{

    public class AblageFachWebRoutinen : WebRoutinenBase
    {
        public AblageFachWebRoutinen(IWebApiConfig settings) : base(settings)
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
            if (await LoginAsync())
            {
                return await GetAsync<AblageFachDTO>("AblageFach/?id=" + guid.ToString());
            }
            return null;
        }

        public async Task<List<AblageFachDTO>> GetAllAsync(DateTime? changedSince)
        {
            if (await LoginAsync())
            {
                if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
                {
                    return await GetAsync<List<AblageFachDTO>>("AblageFach?changedSince=" + changedSince.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                else
                {
                    return await GetAsync<List<AblageFachDTO>>("AblageFach");
                }
            }
            return null;
        }

        public async Task<string> SaveAsync(AblageFachDTO dto)
        {
            if (await LoginAsync())
            {
                return await PutAsync("AblageFach/", dto);
            }
            return null;
        }

        public async Task<string> DeleteAsync(Guid guid)
        {
            if (await LoginAsync())
            {
                return await DeleteAsync("AblageFach/?id=" + guid.ToString());
            }
            return "Not logged in";
        }
    }
}