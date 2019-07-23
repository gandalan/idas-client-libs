using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktionsStatusWebRoutinen : WebRoutinenBase
    {
        public ProduktionsStatusWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }
 
        public ProduktionsStatusDTO GetProduktionsStatus(Guid guid)
        {
            if (Login())
            {
                return Get<ProduktionsStatusDTO>("ProduktionsStatus/" + guid.ToString());
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

        public async Task<string> SaveProduktionsAsync(ProduktionsStatusDTO status)
        {
            return await Task.Run(() => SaveProduktionsStatus(status));
        }
    }
}
