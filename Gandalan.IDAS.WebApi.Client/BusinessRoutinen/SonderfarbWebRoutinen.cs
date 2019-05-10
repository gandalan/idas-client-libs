using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class SonderfarbWebRoutinen : WebRoutinenBase
    {
        public SonderfarbWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public BelegDTO BerechneSonderfarben(Guid belegGuid)
        {
            if (Login())
            {
                return Post<BelegDTO>("BelegSonderfarben?bguid=" + belegGuid.ToString(), null);
            }
            return null;
        }


        public async Task<BelegDTO> BerechneSonderfarbenAsync(Guid belegGuid)
        {
            return await Task<VorgangListItemDTO[]>.Run(() => { return BerechneSonderfarben(belegGuid); });
        }        
    }
}
