using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktionWebRoutinen : WebRoutinenBase
    {
        public ProduktionWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public string ProduktionBerechnen(Guid belegPositionsGuid)
        {
            if (Login())
            {
                return Get<string>("Script/PosBerechnen?pguid=" + belegPositionsGuid.ToString());
            }
            return null;
        }
        
        public List<BearbeitungDTO> GetProduktion(Guid belegPositionsGuid)
        {
            //throw new Exception("TODO: DTOs definieren, Endpunkt MaterialBedarf aufrufen!");
            if (Login())
            {
                return Get<List<BearbeitungDTO>>("Produktion/?posguid=" + belegPositionsGuid.ToString());
            }
            return null;
        }

        public List<MaterialbedarfDTO> GetMaterialBedarf(Guid belegPositionsGuid)
        {
            if (Login())
            {
                return Get<List<MaterialbedarfDTO>>("MaterialBedarf/?posguid=" + belegPositionsGuid.ToString());
            }
            return null;
        }


        public async Task<List<BearbeitungDTO>> GetProduktionAsync(Guid belegPositionsGuid)
        {
            return await Task<List<BearbeitungDTO>>.Run(() => { return GetProduktion(belegPositionsGuid); });
        }

        public async Task<List<MaterialbedarfDTO>> GetMaterialBedarfAsync(Guid belegPositionsGuid)
        {
            return await Task<List<MaterialbedarfDTO>>.Run(() => { return GetMaterialBedarf(belegPositionsGuid); });
        }
        
        public async Task<string> ProduktionBerechnenAsync(Guid belegPositionsGuid)
        {
            return await Task<string>.Run(() => { return ProduktionBerechnen(belegPositionsGuid); });
        }
    }
}
