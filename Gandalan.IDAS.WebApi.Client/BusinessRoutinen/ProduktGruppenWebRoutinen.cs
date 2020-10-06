using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktGruppenWebRoutinen : WebRoutinenBase
    {
        public ProduktGruppenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public ProduktGruppeDTO[] GetAll(bool includeFamilien)
        {
            if (Login())
            {
                return Get<ProduktGruppeDTO[]>("ProduktGruppe?includeFamilien=" + includeFamilien + "&includeVarianten = " + includeFamilien + " &includeUIDefs=" + includeFamilien + "&maxLevel=99");
            }
            return null;
        }

        public string Save(ProduktGruppeDTO dto)
        {
            if (Login())
            {
                return Put("ProduktGruppe/" + dto.ProduktGruppeGuid, dto);
            }
            return null;
        }


        public async Task SaveAsync(ProduktGruppeDTO dto)
        {
            await Task.Run(() => Save(dto));
        }

        public async Task<ProduktGruppeDTO[]> GetAllAsync(bool includeFamilien = true)
        {
            return await Task.Run(() => GetAll(includeFamilien));
        }
    }
}
