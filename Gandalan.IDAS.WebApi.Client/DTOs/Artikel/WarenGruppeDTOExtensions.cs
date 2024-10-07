using System.Collections.Generic;
using System.Linq;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Artikel;

public static class WarenGruppeDTOExtensions
{
    public static KatalogArtikelDTO GetKatalogArtikel(this IList<WarenGruppeDTO> list, string katalogNummer) =>
        list.SelectMany(wg => wg.Artikel).FirstOrDefault(artikel => artikel.KatalogNummer == katalogNummer);
}
