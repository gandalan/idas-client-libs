using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Client.DTOs.Artikel;

namespace Gandalan.IDAS.WebApi.DTO
{
    public static class MaterialbedarfDTOExtensions
    {
        public static bool HasSonderfarbe(this MaterialbedarfDTO dto) =>
            dto.FarbKuerzel == "SF" && string.IsNullOrEmpty(dto.FarbZusatzText);

        public static bool HasTrendfarbe(this MaterialbedarfDTO dto) =>
            dto.FarbKuerzel == "SF" && !string.IsNullOrEmpty(dto.FarbZusatzText);

        public static bool IsFromEigenArtikel(this MaterialbedarfDTO dto, IList<WarenGruppeDTO> warengruppen) =>
            warengruppen.GetKatalogArtikel(dto.KatalogNummer)?.IstEigenartikel ?? false;

        public static bool IsFromUeberschriebenerArtikel(this MaterialbedarfDTO dto, IList<WarenGruppeDTO> warengruppen) =>
            warengruppen.GetKatalogArtikel(dto.KatalogNummer)?.ErsetztNeherArtikel ?? false;
    }
}
