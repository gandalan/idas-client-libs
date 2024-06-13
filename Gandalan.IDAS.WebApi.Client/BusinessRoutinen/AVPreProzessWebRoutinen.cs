using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class AVPreProzessWebRoutinen : WebRoutinenBase
{
    public AVPreProzessWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<BerechnungParameterDTO> BerechnenAsync(BerechnungParameterDTO dto)
    {
            return await PutAsync<BerechnungParameterDTO>("AVPreProcess", dto);
        }
}