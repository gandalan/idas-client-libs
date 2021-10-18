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

        public VorgangDTO VorgangReaktivieren(BelegartWechselDTO dto)
        {
            if (Login())
            {
                return Put<VorgangDTO>("VorgangReaktivieren", dto);
            }
            return null;
        }

        public async Task<VorgangDTO> VorgangReaktivierenAsync(BelegartWechselDTO dto)
        {
            return await Task<VorgangDTO>.Run(() => { return VorgangReaktivieren(dto); });
        }
    }
}