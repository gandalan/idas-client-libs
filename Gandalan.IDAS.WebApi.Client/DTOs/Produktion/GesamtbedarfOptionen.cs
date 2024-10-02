using System;

namespace Gandalan.IDAS.WebApi.DTO.Gesamtbedarf;

[Flags]
public enum ZusammenfassungsOptionen
{
    Unbekannt = 0,
    Lieferdatum = 1,
    Serienzuordnung = 2,
    ArtikelnummerFrabeOberflaeche = 4,
    Vorgang = 8,
    FarbeOberflaeche = 16,
    Keine = 32,
}

[Flags]
public enum SchnittoptimierungsOptionen
{
    Keine = 0,
    Lieferdatum = 1,
    Serie = 2,
    FarbeOberflaeche = 4,
}
