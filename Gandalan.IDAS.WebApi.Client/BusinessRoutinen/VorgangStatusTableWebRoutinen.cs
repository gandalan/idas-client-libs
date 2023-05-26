using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class VorgangStatusTableWebRoutinen : WebRoutinenBase
    {
        public VorgangStatusTableWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task UpdateVorgangStatusTableForFunctionAsync(VorgangStatusTableDTO dto) 
            => await PostAsync("VorgangStatus/UpdateVorgangStatusTableForFunction", dto);

        public async Task<IList<VorgangStatusTableDTO>> GetNotCalculatedVorgangStatusTableForFunctionAsync() 
            => await GetAsync<IList<VorgangStatusTableDTO>>("VorgangStatus/GetNotCalculatedVorgangStatusTableForFunction");
    }
}
