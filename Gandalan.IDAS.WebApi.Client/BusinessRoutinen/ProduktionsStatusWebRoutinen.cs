using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktionsStatusWebRoutinen : WebRoutinenBase
    {
        public ProduktionsStatusWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }
 
        public ProduktionsStatusDTO GetProduktionsStatus(Guid guid)
        {
            if (Login())
            {
                try
                {
                    return Get<ProduktionsStatusDTO>("ProduktionsStatus/" + guid.ToString());
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

        public string SaveProduktionsStatus(ProduktionsStatusDTO status)
        {
            if (Login())
            {
                return Put<string>("ProduktionsStatus", status);
            }
            return "Not logged in";
        }

        public async Task<ProduktionsStatusDTO> GetProduktionsStatusAsync(Guid guid)
        {
            return await Task.Run(() => GetProduktionsStatus(guid));
        }

        public async Task<string> SaveProduktionsStatusAsync(ProduktionsStatusDTO status)
        {
            return await Task.Run(() => SaveProduktionsStatus(status));
        }
    }
}
