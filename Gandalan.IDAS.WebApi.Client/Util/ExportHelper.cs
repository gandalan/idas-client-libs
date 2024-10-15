using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Util;

public static class ExportHelper
{
    public static ExportArtikelArt GetExportArtikelArt(bool IstEigenartikel, bool ErsetztNeherArtikel) =>
        IstEigenartikel
            ? ExportArtikelArt.Eigene
            : ErsetztNeherArtikel
                ? ExportArtikelArt.Ueberschriebene
                : ExportArtikelArt.Neher;

    public static ExportFarbArt GetExportFarbArt(string farbKuerzel, string farbZusatzText) => farbKuerzel != "SF"
            ? ExportFarbArt.Standardfarbe
            : farbKuerzel == "SF" && !string.IsNullOrEmpty(farbZusatzText)
                ? ExportFarbArt.Trendfarbe
                : ExportFarbArt.Sonderfarbe;
}
