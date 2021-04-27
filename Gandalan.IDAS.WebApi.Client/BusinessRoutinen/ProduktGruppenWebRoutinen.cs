using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ProduktGruppenWebRoutinen : WebRoutinenBase
    {
        public ProduktGruppenWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public ProduktGruppeDTO[] GetAll(bool includeFamilien)
        {
            if (Login())
                return Get<ProduktGruppeDTO[]>($"ProduktGruppe?includeFamilien={includeFamilien}&includeVarianten = {includeFamilien} &includeUIDefs={includeFamilien}&maxLevel=99");
            throw new ApiException("Login fehlgeschlagen");
        }
        public ProduktGruppeDTO SaveProduktGruppe(ProduktGruppeDTO produktGruppe)
        {
            if (Login())
                return Put<ProduktGruppeDTO>($"ProduktGruppe/{produktGruppe.ProduktGruppeGuid}", produktGruppe);
            throw new ApiException("Login fehlgeschlagen");
        }
        public async Task SaveProduktGruppeAsync(ProduktGruppeDTO produktGruppe) => await Task.Run(() => SaveProduktGruppe(produktGruppe));
        public async Task<ProduktGruppeDTO[]> GetAllAsync(bool includeFamilien = true) => await Task.Run(() => GetAll(includeFamilien));

        [Obsolete("Funktion 'SaveProduktGruppe()' verwenden")]
        public string Save(ProduktGruppeDTO dto)
        {
            if (Login())
            {
                return Put("ProduktGruppe/" + dto.ProduktGruppeGuid, dto);
            }
            return null;
        }
        [Obsolete("Funktion 'SaveProduktGruppeAsync()' verwenden")]
        public async Task SaveAsync(ProduktGruppeDTO dto)
        {
            await Task.Run(() => Save(dto));
        }
    }
}
