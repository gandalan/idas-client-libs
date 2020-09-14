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
                    return Get<List<AblageDTO>>("Ablage?changedSince=" + changedSince.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
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


        public async Task<AblageDTO> GetAsync(Guid guid)
        {
            return await Task.Run(() => Get(guid));
        }

        public async Task<List<AblageDTO>> GetAllAsync(DateTime? changedSince)
        {
            return await Task.Run(() => GetAll(changedSince));
        }

        public async Task SaveAsync(AblageDTO dto)
        {
            await Task.Run(() => Save(dto));
        }

        public async Task<string> DeleteAsync(Guid guid)
        {
            return await Task.Run(() => Delete(guid));
        }
    }
}