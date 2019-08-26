using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class UpdateInfoWebRoutinen : WebRoutinenBase
    {
        public UpdateInfoWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public UpdateInfoDTO GetUpdateInfo()
        {
            return Get<UpdateInfoDTO>("UpdateInfo");
        }

        public async Task<UpdateInfoDTO> GetUpdateInfoAsync()
        {
            return await Task.Run(() => GetUpdateInfo());
        }
    }
}