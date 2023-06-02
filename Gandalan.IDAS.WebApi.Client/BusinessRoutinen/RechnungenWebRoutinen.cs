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

        public async Task<List<BelegeInfoDTO>> GetAllRechnungenDruckbarAsync()
            => await GetAsync<List<BelegeInfoDTO>>("Rechnungen/GetNotPrintedRechnungen");

        public async Task<Dictionary<Guid, Guid>> ErstelleRechnungenAsync(List<BelegartWechselDTO> belegeWechsel) 
            => await PostAsync<Dictionary<Guid, Guid>>("Rechnungen/ErstelleRechnungen", belegeWechsel);
    }
}
