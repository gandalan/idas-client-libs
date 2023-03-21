using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AVPostProzessWebRoutinen : WebRoutinenBase
    {
        public AVPostProzessWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }
   
        public ProduktionsDatenDTO Berechnen(BelegPositionAVDTO dto)
        {
            if (Login())
            {
                return Put<ProduktionsDatenDTO>("AVPostProcess", dto);
            }
            return null;
        }


        public async Task<ProduktionsDatenDTO> BerechnenAsync(BelegPositionAVDTO dto)
        {
            return await Task.Run(() => { return Berechnen(dto); });
        }
    }
}
