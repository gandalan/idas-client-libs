namespace Gandalan.IDAS.WebApi.DTO
{
    public static class MaterialbedarfDTOExtensions
    {
        public static bool IsSonderfarbe(this MaterialbedarfDTO dto)
        {
            return dto.FarbKuerzel == "SF" && string.IsNullOrEmpty(dto.FarbZusatzText);
        }

        public static bool IsTrendfarbe(this MaterialbedarfDTO dto)
        {
            return dto.FarbKuerzel == "SF" && !string.IsNullOrEmpty(dto.FarbZusatzText);
        }
    }
}
