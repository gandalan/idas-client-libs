using System;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class IBOS1ImportRoutinen : WebRoutinenBase
    {
        public IBOS1ImportRoutinen(IWebApiConfig settings) : base(settings)
        {
            this.Settings.Url = this.Settings.Url.Replace("/api/", "/ibos-api/");
        }

        // eigentlich kann man die Funktionen LadeBestellungen() und LadeMaterialBestellungen() sowie ResetBestellungen() und ResetMaterialBestellungen() auch noch zusammenfassen aber da war ich jetzt echt zu faul für...
        public async Task<BestellungListItemDTO[]> LadeBestellungenAsync(int jahr = -1, bool includeAbegholte = false) 
            => await GetAsync<BestellungListItemDTO[]>($"Bestellungen?jahr={jahr}&includeAbegholte={includeAbegholte}");

        public async Task ResetBestellungenAsync(DateTime resetAb)
            => await GetAsync($"BestellungenReset?resetAb={resetAb.ToString("o")}");

        public async Task<MaterialBestellungListItemDTO[]> LadeMaterialBestellungenAsync(int jahr = -1, bool includeAbegholte = false) 
            => await GetAsync<MaterialBestellungListItemDTO[]>($"MaterialBestellungen?jahr={jahr}&includeAbegholte={includeAbegholte}");

        public async Task ResetMaterialBestellungenAsync(DateTime resetAb) 
            => await GetAsync($"MaterialBestellungenReset?resetAb={resetAb.ToString("o")}");

        public async Task<string> GetgSQLBelegAsync(Guid belegGuid) 
            => Encoding.UTF8.GetString(await GetDataAsync("Bestellungen/" + belegGuid.ToString()));
    }
}
