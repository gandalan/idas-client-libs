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
            if (Login())
            {
                return Get<UpdateInfoDTO>("UpdateInfo");
            }
            return null;
        }

        public async Task<UpdateInfoDTO> GetUpdateInfoAsync()
        {
            return await Task.Run(() => GetUpdateInfo());
        }
    }
}