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

        public List<BelegeInfoDTO> GetAllABFakturierbar()
        {
            if (Login())
            {
                return Get<List<BelegeInfoDTO>>("Rechnungen/GetABFakturierbar");
            }
            return null;
        }

        public List<BelegeInfoDTO> GetAllRechnungenDruckbar()
        {
            if (Login())
            {
                return Get<List<BelegeInfoDTO>>("Rechnungen/GetNotPrintedRechnungen");
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

        public async Task<List<BelegeInfoDTO>> GetAllABFakturierbarAsync()
        {
            return await Task.Run(() => GetAllABFakturierbar());
        }

        public async Task ErstelleRechnungenAsync(List<DTO.BelegartWechselDTO> belegeWechsel)
        {
            await Task.Run(() => ErstelleRechnungen(belegeWechsel));
        }

        public async Task<List<BelegeInfoDTO>> GetAllRechnungenDruckbarAsync()
        {
            return await Task.Run(() => GetAllRechnungenDruckbar());
        }
    }
}
