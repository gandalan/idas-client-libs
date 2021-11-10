using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Produktion;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktionsInfoWebRoutinen : WebRoutinenBase
    {
        public ProduktionsInfoWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public ProduktionsInfoDTO GetProduktionsInfo(Guid vorgangGuid)
        {
            if (Login())
            {
                try
                {
                    return Get<ProduktionsInfoDTO>("ProduktionsInfo/" + vorgangGuid.ToString());
                }
                catch (WebException wex)
                {
                    if (wex.Response is HttpWebResponse)
                    {
                        HttpStatusCode code = (wex.Response as HttpWebResponse).StatusCode;
                        if (code == HttpStatusCode.NotFound)
                            return null;
                    }
                    throw;
                }
            }
            return null;
        }

        public async Task<ProduktionsInfoDTO> GetProduktionsInfoAsync(Guid vorgangGuid)
        {
            return await Task.Run(() => GetProduktionsInfo(vorgangGuid));
        }
    }
}
