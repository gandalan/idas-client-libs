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

        public Dictionary<Guid, Guid> ErstelleRechnungen(List<BelegartWechselDTO> belegeWechsel)
        {
            if (Login())
            {
                return Post<Dictionary<Guid, Guid>>("Rechnungen/ErstelleRechnungen", belegeWechsel);
            }
            return null;
        }

        public async Task<List<BelegeInfoDTO>> GetAllABFakturierbarAsync()
        {
            return await Task.Run(() => GetAllABFakturierbar());
        }

        public async Task<Dictionary<Guid, Guid>> ErstelleRechnungenAsync(List<BelegartWechselDTO> belegeWechsel)
        {
            return await Task.Run(() => ErstelleRechnungen(belegeWechsel));
        }

        public async Task<List<BelegeInfoDTO>> GetAllRechnungenDruckbarAsync()
        {
            return await Task.Run(() => GetAllRechnungenDruckbar());
        }
    }
}
