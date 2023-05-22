using System;
using System.Collections.Generic;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Belege;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    internal class SerienInfoWebRoutinen : WebRoutinenBase
    {
        public SerienInfoWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public List<BelegSerienInfoDTO> GetBelegSerienInfos(List<Guid> belegGuids)
        {
            if (Login())
            {
                return Post<List<BelegSerienInfoDTO>>($"BelegSerienInfo", belegGuids);
            }
            return null;
        }

        public List<BelegSerienInfoDTO> GetVorgangSerienInfos(List<Guid> vorgangGuids)
        {
            if (Login())
            {
                return Post<List<BelegSerienInfoDTO>>($"BelegSerienInfo/GetByVorgangGuids", vorgangGuids);
            }
            return null;
        }
    }
}
