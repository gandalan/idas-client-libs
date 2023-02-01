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

        public List<FakturierbarerBelegeDTO> GetAllABFakturierbar()
        {
            if (Login())
            {
                return Get<List<FakturierbarerBelegeDTO>>("Rechnungen/GetABFakturierbar");
            }
            return null;
        }

        public List<FakturierbarerBelegeDTO> GetAllRechnungenDruckbar()
        {
            if (Login())
            {
                return Get<List<FakturierbarerBelegeDTO>>("Rechnungen/GetNotPrintedRechnungen");
            }
            return null;
        }

        public void ErstelleRechnungen(List<BelegartWechselDTO> belegeWechsel)
        {
            if (Login())
            {
                Post("Rechnungen/ErstelleRechnungen", belegeWechsel);
            }
        }

        public async Task<List<FakturierbarerBelegeDTO>> GetAllABFakturierbarAsync()
        {
            return await Task.Run(() => GetAllABFakturierbar());
        }

        public async Task ErstelleRechnungenAsync(List<DTO.BelegartWechselDTO> belegeWechsel)
        {
            await Task.Run(() => ErstelleRechnungen(belegeWechsel));
        }

        public async Task<List<FakturierbarerBelegeDTO>> GetAllRechnungenDruckbarAsync()
        {
            return await Task.Run(() => GetAllRechnungenDruckbar());
        }
    }
}
