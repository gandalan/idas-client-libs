using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;
using Gandalan.IDAS.WebApi.DTO;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class LieferzusageWebRoutinen : WebRoutinenBase
    {
        public LieferzusageWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public string MaterialZusagen(LieferzusageDTO lieferzusage)
        {
            if (Login())
            {
                return Post<string>("Lieferzusage", JsonConvert.SerializeObject(lieferzusage));
            }
            return null;
        }
        
        public string ResetZusage(Guid lieferzusageGuid)
        {
            if (Login())
            {
                return Get<string>("Lieferzusage?zusageGuid=" + lieferzusageGuid.ToString());
            }
            return null;
        }


        public async Task<string> MaterialZusagenAsync(LieferzusageDTO lieferzusage)
        {
            return await Task<string>.Run(() => { return MaterialZusagen(lieferzusage); });
        }

        public async Task<string> ResetZusageAsync(Guid lieferzusageGuid)
        {
            return await Task<string>.Run(() => { return ResetZusage(lieferzusageGuid); });
        }        
    }
}
