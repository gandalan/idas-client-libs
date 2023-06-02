using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class VorgangReaktivierenWebRoutinen : WebRoutinenBase
    {
        public VorgangReaktivierenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<VorgangDTO> VorgangReaktivierenAsync(BelegartWechselDTO dto) 
            => await PutAsync<VorgangDTO>("VorgangReaktivieren", dto);
    }
}