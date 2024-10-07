using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class MandantFreigabeDTO
{
    public string Code { get; set; }
    public DateTime GueltigAb { get; set; }
    public FreigabeLevel Level { get; set; }
    public FreigabeArt Art { get; set; }
    public string ZusatzDaten { get; set; }
}

public enum FreigabeLevel
{
    Unbekannt,
    Gesperrt,
    Lesen,
    LesenSchreiben,
    LesenSchreibenLoeschen,
}

public enum FreigabeArt
{
    Unbekannt,
    ProgrammModul,
    Variante,
}
