using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class IBOS1ImportRoutinen : WebRoutinenBase
    {
        public IBOS1ImportRoutinen(WebApiSettings settings) : base(settings)
        {
            this.Settings.Url = this.Settings.Url.Replace("/api/", "/ibos-api/");
        }

        public BestellungListItemDTO[] LadeBestellungen(int jahr = -1)
        {
            if (Login())
            {
                return Get<BestellungListItemDTO[]>($"Bestellungen?jahr={jahr}");
            }
            return null;
        }

        public void ResetBestellungen(DateTime resetAb)
        {
            if (Login())
            {
                Get($"BestellungenReset?resetAb={resetAb.ToString("yyyy-MM-ddTHH:mm:ss")}");
            }
        }

        public string GetgSQLBeleg(Guid belegGuid)
        {
            if (Login())
            {
                return Encoding.UTF8.GetString(GetData("Bestellungen/" + belegGuid.ToString()));
            }
            return null;
        }


        public async Task<string> GetgSQLBelegAsync(Guid belegGuid)
        {
            return await Task<string>.Run(() => { return GetgSQLBeleg(belegGuid); });
        }

        public async Task<BestellungListItemDTO[]> LadeBestellungenAsync(int jahr = -1)
        {
            return await Task<VorgangListItemDTO[]>.Run(() => { return LadeBestellungen(jahr); });
        }

        public async Task ResetBestellungenAsync(DateTime resetAb)
        {
            await Task.Run(() => { ResetBestellungen(resetAb); });
        }
    }
}
