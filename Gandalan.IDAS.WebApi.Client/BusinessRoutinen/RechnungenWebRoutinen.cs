using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;
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

        public async Task<List<FakturierbarerBelegeDTO>> GetAllABFakturierbarAsync()
        {
            return await Task.Run(() => GetAllABFakturierbar());
        }
    }
}
