using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class ProduktFamilienWebRoutinen : WebRoutinenBase
{
    public ProduktFamilienWebRoutinen(IWebApiConfig settings) : base(settings) { }

    public async Task<ProduktFamilieDTO[]> GetAllAsync(bool includeVarianten = true)
        => await GetAsync<ProduktFamilieDTO[]>($"ProduktFamilie?includeVarianten={includeVarianten}&includeUIDefs={includeVarianten}&maxLevel=99");

    public async Task SaveProduktFamilieAsync(ProduktFamilieDTO produktFamilie)
        => await PutAsync<ProduktFamilieDTO>($"ProduktFamilie/{produktFamilie.ProduktFamilieGuid}", produktFamilie);

    [Obsolete("Funktion 'SaveProduktFamilieAsync()' verwenden")]
    public async Task SaveAsync(ProduktFamilieDTO dto)
        => await PutAsync("ProduktFamilie/" + dto.ProduktFamilieGuid, dto);
}