using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IBelegPositionService
    {
        Task<VarianteDTO> GetVarianteAsync(Guid guid);
        Task SaveVorgangAsync(VorgangDTO vorgang);
        Task<ProduktFamilieDTO> GetProduktFamilie(Guid produktFamilieGuid);
        Task<WerteListeDTO> GetWerteListe(string name, Guid varianteGuid, DateTime erstellDatum);
        Task<KatalogArtikelDTO> GetArtikel(string artikelNummer);
        Task<WerteListeDTO> GetArtikelFarbWerteListe(KatalogArtikelDTO artikel, bool includeNeutral = false, bool onlyStandardFarben = false);
    }
}
