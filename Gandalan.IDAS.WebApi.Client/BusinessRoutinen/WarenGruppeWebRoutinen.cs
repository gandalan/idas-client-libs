using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class WarenGruppeWebRoutinen : WebRoutinenBase
    {
        public WarenGruppeWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public WarenGruppeDTO[] GetAll()
        {
            if (Login())
            {
                return Get<WarenGruppeDTO[]>("WarenGruppe");
            }
            return null;
        }

        public string SaveWarenGruppe(WarenGruppeDTO dto)
        {
            if (Login())
            {
                return Put("WarenGruppe/" + dto.WarenGruppeGuid, dto);
            }
            return null;
        }


        public async Task<WarenGruppeDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task SaveWarenGruppeAsync(WarenGruppeDTO dto)
        {
            await Task.Run(() => SaveWarenGruppe(dto));
        }
    }
}
