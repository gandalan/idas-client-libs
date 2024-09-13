using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Settings;

public class ArtosStartSettingsDTO
{
    public MaterialBedarfLogik MaterialBedarfLogik { get; set; }
    public UserAuthTokenDTO UserAuthToken { get; set; }
    public string Environment { get; set; }
}

public enum MaterialBedarfLogik
{
    Serienbezogen,
    Stichtagbezogen,
}
