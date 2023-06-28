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

        public async Task<ProduktGruppeDTO[]> GetAllAsync(bool includeFamilien = true) 
            => await GetAsync<ProduktGruppeDTO[]>($"ProduktGruppe?includeFamilien={includeFamilien}&includeVarianten={includeFamilien}&includeUIDefs={includeFamilien}&maxLevel=99");
        public async Task SaveProduktGruppeAsync(ProduktGruppeDTO produktGruppe) 
            => await PutAsync<ProduktGruppeDTO>($"ProduktGruppe/{produktGruppe.ProduktGruppeGuid}", produktGruppe);

        [Obsolete("Funktion 'SaveProduktGruppeAsync()' verwenden")]
        public async Task SaveAsync(ProduktGruppeDTO dto) 
            => await PutAsync("ProduktGruppe/" + dto.ProduktGruppeGuid, dto);

    }
}
