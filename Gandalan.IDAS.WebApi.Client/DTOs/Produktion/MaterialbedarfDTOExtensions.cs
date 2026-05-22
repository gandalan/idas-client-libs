namespace Gandalan.IDAS.WebApi.DTO
{
    public static class MaterialbedarfDTOExtensions
    {
        public static ExportFarbArt GetExportFarbArt(this MaterialbedarfDTO materialbedarf)
        {
            return !string.IsNullOrEmpty(materialbedarf.FarbZusatzText) 
                ? ExportFarbArt.Trendfarbe 
                : materialbedarf.FarbKuerzel == "SF" 
                    ? ExportFarbArt.Sonderfarbe
                    : ExportFarbArt.Standardfarbe;
        }
    }
}
