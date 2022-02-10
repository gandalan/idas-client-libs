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
        public List<LieferzusageDTO> GetAllZusagen(Guid serie, string lieferant = "")
        {
            if (Login())
            {
                return Get<List<LieferzusageDTO>>($"Lieferzusage/?serieGuid={serie.ToString()}&lieferant={lieferant}");
            }
            return null;
        }

        public int GetZusagenCount(Guid serie, string lieferant = "")
        {
            if (Login())
            {
                return Get<int>($"Lieferzusage/GetCount/{serie.ToString()}/{lieferant}");
            }
            return 0;
        }

        public string MaterialZusagen(LieferzusageDTO lieferzusage)
        {
            if (Login())
            {
                return Post<string>("Lieferzusage", lieferzusage);
            }
            return null;
        }

        public string ResetZusage(Guid lieferzusageGuid)
        {
            if (Login())
            {
                return Delete<string>("Lieferzusage?zusageGuid=" + lieferzusageGuid.ToString());
            }
            return null;
        }

        public async Task<List<LieferzusageDTO>> GetAllZusagenAsync(Guid serie, string lieferant = "")
        {
            return await Task.Run(() => { return GetAllZusagen(serie, lieferant); });
        }

        public async Task<string> MaterialZusagenAsync(LieferzusageDTO lieferzusage)
        {
            return await Task.Run(() => { return MaterialZusagen(lieferzusage); });
        }

        public async Task<string> ResetZusageAsync(Guid lieferzusageGuid)
        {
            return await Task.Run(() => { return ResetZusage(lieferzusageGuid); });
        }
    }
}
