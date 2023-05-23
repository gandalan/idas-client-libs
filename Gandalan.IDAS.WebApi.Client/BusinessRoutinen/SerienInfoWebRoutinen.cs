using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Belege;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class SerienInfoWebRoutinen : WebRoutinenBase
    {
        public SerienInfoWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public List<BelegSerienInfoDTO> GetBelegSerienInfos(IList<Guid> belegGuids)
        {
            if (Login())
            {
                return Post<List<BelegSerienInfoDTO>>($"BelegSerienInfo", belegGuids);
            }
            return null;
        }

        public List<BelegSerienInfoDTO> GetVorgangSerienInfos(IList<Guid> vorgangGuids)
        {
            if (Login())
            {
                return Post<List<BelegSerienInfoDTO>>($"BelegSerienInfo/GetByVorgangGuids", vorgangGuids);
            }
            return null;
        }

        public async Task<List<BelegSerienInfoDTO>> GetBelegSerienInfosAsync(IList<Guid> belegGuids)
        {
            return await Task.Run(() => { return GetBelegSerienInfos(belegGuids); });
        }

        public async Task<List<BelegSerienInfoDTO>> GetVorgangSerienInfosAsync(IList<Guid> vorgangGuids)
        {
            return await Task.Run(() => { return GetVorgangSerienInfos(vorgangGuids); });
        }
    }
}
