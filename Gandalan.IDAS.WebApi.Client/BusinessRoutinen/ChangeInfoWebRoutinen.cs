using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ChangeInfoWebRoutinen : WebRoutinenBase
    {
        public ChangeInfoWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public ChangeInfoDTO GetChangeInfo()
        {
            return Get<ChangeInfoDTO>("ChangeInfo");
        }

        public async Task<ChangeInfoDTO> GetChangeInfoAsync()
        {
            return await Task.Run(() => GetChangeInfo());
        }
    }
}