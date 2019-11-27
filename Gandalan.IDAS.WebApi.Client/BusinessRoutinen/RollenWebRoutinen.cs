using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class RollenWebRoutinen : WebRoutinenBase
    {
        public RollenWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public RolleDTO[] GetAll()
        {
            if (Login())
            {
                return Get<RolleDTO[]>("Rollen");
            }
            return null;
        }

        public async Task<RolleDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

    }
}
