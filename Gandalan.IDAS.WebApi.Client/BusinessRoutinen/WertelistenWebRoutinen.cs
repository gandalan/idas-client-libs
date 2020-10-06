using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class WertelistenWebRoutinen : WebRoutinenBase
    {
        public WertelistenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public WerteListeDTO[] GetAll(bool includeAutoWerteListen)
        {
            if (Login())
            {
                return Get<WerteListeDTO[]>("WerteListe?includeAutoWerteListen=" + includeAutoWerteListen.ToString());
            }
            return null;
        }

        public string Save(WerteListeDTO dto)
        {
            if (Login())
            {
                return Put("WerteListe/" + dto.WerteListeGuid.ToString(), dto);
            }
            return null;
        }


        public async Task<WerteListeDTO[]> GetAllAsync(bool includeAutoWerteListen)
        {
            return await Task.Run(() => GetAll(includeAutoWerteListen));
        }

        public async Task SaveAsync(WerteListeDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}
