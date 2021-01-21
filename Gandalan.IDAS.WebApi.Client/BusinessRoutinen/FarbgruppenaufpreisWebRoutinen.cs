using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.Data.DTOs.Farben;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FarbgruppenaufpreisWebRoutinen : WebRoutinenBase
    {
        public FarbgruppenaufpreisWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public FarbgruppenaufpreiseDTO Get()
        {
            if (Login())
            {
                return Get<FarbgruppenaufpreiseDTO>("Farbgruppenaufpreis");
            }
            return null;
        }

        public string SaveFarbgruppenaufpreise(FarbgruppenaufpreiseDTO dto)
        {
            if (Login())
            {
                return Put("Farbgruppenaufpreis" , dto);
            }
            return null;
        }


        public async Task<FarbgruppenaufpreiseDTO> GetAsync()
        {
            return await Task.Run(() => Get());
        }
        public async Task SavFarbgruppenaufpreiseAsync(FarbgruppenaufpreiseDTO dto)
        {
            await Task.Run(() => SaveFarbgruppenaufpreise(dto));
        }
    }
}
