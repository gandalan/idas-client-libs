namespace Gandalan.IDAS.WebApi.Client.DTOs.Settings;

public class ArtosStartSettingsDTO
{
    public MaterialBedarfLogik MaterialBedarfLogik { get; set; }
}

public enum MaterialBedarfLogik
{
    Serienbezogen,
    Stichtagbezogen,
}
