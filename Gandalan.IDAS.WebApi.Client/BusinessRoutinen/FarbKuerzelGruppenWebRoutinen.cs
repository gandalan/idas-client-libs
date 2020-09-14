using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FarbKuerzelGruppenWebRoutinen : WebRoutinenBase
    {
        public FarbKuerzelGruppenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public FarbKuerzelGruppeDTO[] GetAll()
        {
            if (Login())
            {
                return Get<FarbKuerzelGruppeDTO[]>("FarbKuerzelGruppe");
            }
            return null;
        }

        public string SaveFarbKuerzelGruppe(FarbKuerzelGruppeDTO dto)
        {
            if (Login())
            {
                return Put("FarbKuerzelGruppe/", dto);
            }
            return null;
        }


        public async Task<FarbKuerzelGruppeDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task SaveFarbKuerzelAsync(FarbKuerzelGruppeDTO dto)
        {
            await Task.Run(() => SaveFarbKuerzelGruppe(dto));
        }
    }
}
