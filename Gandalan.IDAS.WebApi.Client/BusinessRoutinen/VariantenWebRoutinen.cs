using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class VariantenWebRoutinen : WebRoutinenBase
{
    public VariantenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<VarianteDTO[]> GetAllAsync()
        => await GetAsync<VarianteDTO[]>("Variante?includeUIDefs=true&maxLevel=99");

    public async Task<Guid[]> GetAllGuidsAsync()
        => await GetAsync<Guid[]>("Variante/GetAllGuids");

    public async Task<Guid[]> GetAllVariantenChanges(DateTime? changedSince = null)
    {
            if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
            {
                return await GetAsync<Guid[]>("Variante/GetAllVariantenChanges?changedSince=" + changedSince.Value.ToString("o"));
            }

            return await GetAsync<Guid[]>("Variante/GetAllGuids");
        }

    public async Task<VarianteDTO> GetAsync(Guid varianteGuid, bool includeUIDefs = true, bool includeKonfigs = true)
        => await GetAsync<VarianteDTO>($"Variante/{varianteGuid}?includeUIDefs={includeUIDefs}&maxLevel=99&includeKonfigs={includeKonfigs}");

    public async Task<VarianteDTO> SaveVarianteAsync(VarianteDTO variante)
        => await PutAsync<VarianteDTO>($"Variante/{variante.VarianteGuid}", variante);

    public async Task CacheWebJob()
        => await PostAsync("Variante/CacheWebJob", null);

    [Obsolete("Funktion 'SaveVarianteAsync()' verwenden")]
    public async Task SaveAsync(VarianteDTO dto)
        => await PutAsync("Variante/" + dto.VarianteGuid, dto);
}