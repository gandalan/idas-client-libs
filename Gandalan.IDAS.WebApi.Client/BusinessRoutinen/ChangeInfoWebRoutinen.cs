using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ChangeInfoWebRoutinen : WebRoutinenBase
    {
        public ChangeInfoWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public ChangeInfoDTO GetChangeInfo()
        {
            if (Login())
            {
                return Get<ChangeInfoDTO>("ChangeInfo");
            }
            return null;
        }

        public async Task<ChangeInfoDTO> GetChangeInfoAsync()
        {
            return await Task.Run(() => GetChangeInfo());
        }
    }
}