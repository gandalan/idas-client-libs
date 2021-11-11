using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Produktion;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktionsfreigabeListeWebRoutinen : WebRoutinenBase
    {
        public ProduktionsfreigabeListeWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public ProduktionsfreigabeItemDTO[] GetAll()
        {
            if (Login())
            {
                return Get<ProduktionsfreigabeItemDTO[]>("ProduktionsfreigabeListe");
            }
            return null;
        }

        public async Task<ProduktionsfreigabeItemDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
    }
}
