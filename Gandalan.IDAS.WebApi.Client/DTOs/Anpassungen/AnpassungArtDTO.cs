namespace Gandalan.IDAS.WebApi.DTO;

public enum AnpassungArtDTO
{
    Unbekannt = 0,
    ZusatzArtikel = 1,
    ArtikelSperre = 2,
    Produktion = 4,
    Standardfarben = 8,
    Anbauteilfarben = 16,
    Preisfaktoren = 32,
    Aufpreise = 64,
    MbAufpreise = 256,
    Grenzenfreigabe = 512,
    FarbGruppen = 1024,
    MbAufpreiseKlebe = 2048,
}
