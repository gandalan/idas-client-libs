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

        public BestellungListItemDTO[] LadeBestellungen()
        {
            if (Login())
            {
                return Get<BestellungListItemDTO[]>("Bestellungen/");
            }
            return null;
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

        public async Task<BestellungListItemDTO[]> LadeBestellungenAsync()
        {
            return await Task<VorgangListItemDTO[]>.Run(() => { return LadeBestellungen(); });
        }
    }
}
