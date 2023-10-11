using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class RechnungenWebRoutinen : WebRoutinenBase
    {
        public RechnungenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<List<BelegeInfoDTO>> GetAllABFakturierbarAsync()
            => await GetAsync<List<BelegeInfoDTO>>("Rechnungen/GetABFakturierbar");

        public async Task<List<BelegeInfoDTO>> GetAllRechnungenDruckbarAsync(DateTime? printedSince = null)
            => await GetAsync<List<BelegeInfoDTO>>($"Rechnungen/GetNotPrintedRechnungen?printedSince={printedSince}");
        public async Task<List<BelegeInfoDTO>> GetAllRechnungenExportierbarAsync(DateTime? exportedSince = null)
            => await GetAsync<List<BelegeInfoDTO>>($"Rechnungen/GetNotExportedRechnungen?exportedSince={exportedSince}");
        public async Task SetBelegePrintedAsync(List<Guid> belegListe)
            => await PostAsync($"Rechnungen/SetBelegePrinted", belegListe);
        public async Task SetBelegeExportedAsync(List<Guid> belegListe)
            => await PostAsync($"Rechnungen/SetBelegeExported", belegListe);

        public async Task<Dictionary<Guid, Guid>> ErstelleRechnungenAsync(List<BelegartWechselDTO> belegeWechsel) 
            => await PostAsync<Dictionary<Guid, Guid>>("Rechnungen/ErstelleRechnungen", belegeWechsel);
    }
}
