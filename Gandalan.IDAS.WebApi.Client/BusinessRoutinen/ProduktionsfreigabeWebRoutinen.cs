using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktionsfreigabeWebRoutinen : WebRoutinenBase
    {
        public ProduktionsfreigabeWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public VorgangDTO AddProduktionsfreigabe(BelegartWechselDTO dto)
        {
            if (Login())
            {
                return Put<VorgangDTO>("Produktionsfreigabe", dto);
            }
            return null;
        }

        public async Task<VorgangDTO> AddProduktionsfreigabeAsync(BelegartWechselDTO dto)
        {
            return await Task.Run(() => AddProduktionsfreigabe(dto));
        }
    }
}
