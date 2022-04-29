using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{

    public class AblageWebRoutinen : WebRoutinenBase
    {
        public AblageWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public AblageDTO Get(Guid guid)
        {
            if (Login())
            {
                return Get<AblageDTO>("Ablage/?id=" + guid.ToString());
            }
            return null;
        }

        public List<AblageDTO> GetAll(DateTime? changedSince)
        {
            if (Login())
            {
                if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
                {
                    return Get<List<AblageDTO>>("Ablage?changedSince=" + changedSince.Value.ToString("o"));
                }
                else
                {
                    return Get<List<AblageDTO>>("Ablage");
                }
            }
            return null;
        }
                
        public string Save(AblageDTO dto)
        {
            if (Login())
            {
                return Put("Ablage/", dto);
            }
            return null;
        }

        public string Delete(Guid guid)
        {
            if (Login())
            {
                return Delete("Ablage/?id=" + guid.ToString());
            }
            return "Not logged in";
        }

        public void SerienFachverteilung(Guid serieGuid)
        {
            if(Login())
            {
                Put($"Ablage/SerienFachverteilung/{serieGuid.ToString()}",null);
            }
        }


        public async Task<AblageDTO> GetAsync(Guid guid)
        {
            if (await LoginAsync())
            {
                return await GetAsync<AblageDTO>("Ablage/?id=" + guid.ToString());
            }
            return null;
        }

        public async Task<List<AblageDTO>> GetAllAsync(DateTime? changedSince)
        {
            if (await LoginAsync())
            {
                if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
                {
                    return await GetAsync<List<AblageDTO>>("Ablage?changedSince=" + changedSince.Value.ToString("o"));
                }
                else
                {
                    return await GetAsync<List<AblageDTO>>("Ablage");
                }
            }
            return null;
        }

        public async Task<string> SaveAsync(AblageDTO dto)
        {
            if (await LoginAsync())
            {
                return await PutAsync("Ablage/", dto);
            }
            return null;
        }

        public async Task<string> DeleteAsync(Guid guid)
        {
            if (await LoginAsync())
            {
                return await DeleteAsync("Ablage/?id=" + guid.ToString());
            }
            return "Not logged in";
        }

        public async Task SerienFachverteilungAsync(Guid serieGuid)
        {
            if (await LoginAsync())
            {
                await PutAsync($"Ablage/SerienFachverteilung/{serieGuid.ToString()}", null);
            }
        }


    }
}