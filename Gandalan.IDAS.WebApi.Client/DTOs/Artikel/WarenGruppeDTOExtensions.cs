using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO;

public static class WarenGruppeDTOExtensions
{
    public static KatalogArtikelDTO GetKatalogArtikel(this IList<WarenGruppeDTO> list, string katalogNummer) =>
        list.SelectMany(wg => wg.Artikel).FirstOrDefault(artikel => artikel.KatalogNummer == katalogNummer);
}
