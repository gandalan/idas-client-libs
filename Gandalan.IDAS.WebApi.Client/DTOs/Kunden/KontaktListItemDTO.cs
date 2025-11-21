using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class KontaktListItemDTO
{
    public Guid KontaktGuid { get; set; }
    public Guid KontaktMandantGuid { get; set; }
    public Guid FremdfertigungMandantGuid { get; set; }

    /// <summary>
    /// Der KontaktMandant hat die App-Verwendung aktiv
    /// </summary>
    public bool KontaktMandantIstAktiv { get; set; }

    /// <summary>
    /// Nachname (für Endkunden)
    /// </summary>
    public string Nachname { get; set; }

    /// <summary>
    /// Vorname(n) (für Endkunden)
    /// </summary>
    public string Vorname { get; set; }

    /// <summary>
    /// Firmierung (für jur. Personen)
    /// </summary>
    public string Firmenname { get; set; }

    /// <summary>
    /// Kundennummer (alphanummerisch)
    /// </summary>
    public string KundenNummer { get; set; }

    /// <summary>
    /// Strasse
    /// </summary>
    public string Strasse { get; set; }

    /// <summary>
    /// Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)"
    /// </summary>
    public string Hausnummer { get; set; }

    /// <summary>
    /// Land
    /// </summary>
    public string Land { get; set; }

    /// <summary>
    /// Postleitzahl
    /// </summary>
    public string Plz { get; set; }

    /// <summary>
    /// Stadt / Ort
    /// </summary>
    public string Ort { get; set; }

    /// <summary>
    /// Ortsteil
    /// </summary>
    public string Ortsteil { get; set; }

    /// <summary>
    /// Telefon (Zentrale)
    /// </summary>
    public string Telefon { get; set; }

    /// <summary>
    /// E-Mail (Zentrale)
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Endkunde oder Firmenkunde
    /// </summary>
    public bool IstEndkunde { get; set; }

    public bool IstKunde { get; set; }

    /// <summary>
    /// Kunde gesperrt?
    /// </summary>
    public bool IstGesperrt { get; set; }

    /// <summary>
    /// Archivierte Kontakte werden nicht angezeigt
    /// </summary>
    public bool IstArchiviert { get; set; }

    public string URL { get; set; }
    public DateTime ChangedDate { get; set; }
}
