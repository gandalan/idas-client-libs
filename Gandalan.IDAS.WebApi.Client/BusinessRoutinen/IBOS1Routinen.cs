using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class IBOS1Routinen : WebRoutinenBase
    {
        public IBOS1Routinen(IWebApiConfig settings) : base(settings)
        {
        }

        public string ProduktionBerechnen(Guid belegPositionsGuid)
        {
            if (Login())
            {
                return Get<string>("IBOS1/Print?bguid=" + belegPositionsGuid.ToString());
            }
            return null;
        }

        public string PositionTesten(Guid belegPositionsGuid)
        {
            if (Login())
            {
                return Get<string>("Test?bguid=" + belegPositionsGuid.ToString());
            }
            return null;
        }

        public string GetProduktion(Guid guid)
        {
            if (Login())
            {
                return Get("Produktion/?posguid=" + guid.ToString());
            }
            return null;
        }


        public async Task<string> GetProduktionAsync(Guid guid)
        {
            return await Task<string>.Run(() => { return GetProduktion(guid); });
        }
        
        public async Task<string> PositionTestenAsync(Guid belegPositionsGuid)
        {
            return await Task<string>.Run(() => { return PositionTesten(belegPositionsGuid); });
        }

        public async Task<string> ProduktionBerechnenAsync(Guid belegPositionsGuid)
        {
            return await Task<string>.Run(() => { return ProduktionBerechnen(belegPositionsGuid); });
        }
    }
}
