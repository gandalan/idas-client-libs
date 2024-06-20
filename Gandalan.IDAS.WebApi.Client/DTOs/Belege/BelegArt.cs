using System;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Belege;

public enum BelegArt
{
    Unbekannt = 0,
    Angebot = 1,
    AB = 2,
    Rechnung = 3,
    Lieferschein = 4,
    Bestellschein = 5,
    ProduktionsAuftrag = 6,
    ZuschnittAuftrag = 7,
    VersandAuftrag = 8,
    MaterialBestellschein = 9,
    ReklamationsBestellschein = 10,
    Gutschrift = 11,
    Storno = 12,
    FremdfertigungsAuftrag = 13,
}

public struct BelegWorkflow
{
    public static BelegArt[] Steps =
    [
        BelegArt.Angebot,
        BelegArt.Bestellschein,
        BelegArt.AB,
        BelegArt.ProduktionsAuftrag,
        BelegArt.ZuschnittAuftrag,
        BelegArt.VersandAuftrag,
        BelegArt.Lieferschein,
        BelegArt.ReklamationsBestellschein,
        BelegArt.Rechnung,
    ];

    /// <summary>
    /// Prüft, ob neueBelegArt logisch hinter belegArt liegt
    /// </summary>
    /// <param name="neueBelegArt"></param>
    /// <param name="belegArt"></param>
    /// <returns>true/false</returns>
    public static bool IsBehind(BelegArt neueBelegArt, BelegArt belegArt)
    {
        return Array.IndexOf(Steps, neueBelegArt) > Array.IndexOf(Steps, belegArt);
    }

    /// <summary>
    /// Prüft, ob neueBelegArt logisch vor belegArt liegt
    /// </summary>
    /// <param name="neueBelegArt"></param>
    /// <param name="belegArt"></param>
    /// <returns>true/false</returns>
    public static bool IsBefore(BelegArt neueBelegArt, BelegArt belegArt)
    {
        return Array.IndexOf(Steps, neueBelegArt) < Array.IndexOf(Steps, belegArt);
    }
}