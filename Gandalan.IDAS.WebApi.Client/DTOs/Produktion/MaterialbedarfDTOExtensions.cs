namespace Gandalan.IDAS.WebApi.DTO
{
    public static class MaterialbedarfDTOExtensions
    {
        public static ExportFarbArt GetExportFarbArt(this MaterialbedarfDTO materialbedarf)
        {
            return materialbedarf.FarbKuerzel != "SF"
                ? ExportFarbArt.Standardfarbe
                : (materialbedarf.FarbKuerzel == "SF" && !string.IsNullOrEmpty(materialbedarf.FarbZusatzText))
                    ? ExportFarbArt.Trendfarbe
                    : ExportFarbArt.Sonderfarbe;
        }
    }
}
