using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Ergebnis eines Händler-Archivieren-/E-Mail-Umbenennen-Vorgangs
/// (api/HaendlerArchivieren). Wird sowohl vom Backend zurückgegeben als
/// auch vom Client (NeherAdmin) zur Ergebnisanzeige deserialisiert.
/// </summary>
public class HaendlerArchivierenResultDTO
{
    /// <summary>True, wenn die DB-Umstellung erfolgreich committet wurde.</summary>
    public bool Erfolgreich { get; set; }

    public string AlteMail { get; set; }
    public string NeueMail { get; set; }

    /// <summary>Guid des neu angelegten Benutzers.</summary>
    public Guid NeuerBenutzerGuid { get; set; }

    /// <summary>Anzahl der auf den neuen Benutzer umgehängten Vorgänge.</summary>
    public int VerschobeneVorgaenge { get; set; }

    /// <summary>Anzahl der auf den neuen Benutzer umgehängten Vorgangs-ListItems.</summary>
    public int VerschobeneVorgaengeListItems { get; set; }

    /// <summary>Anzahl der archivierten (gelöschten) Alt-Benutzer.</summary>
    public int ArchivierteBenutzer { get; set; }

    /// <summary>
    /// Nicht-fatale Warnungen (z.B. CMS-Synchronisierung oder Passwort-Mail
    /// fehlgeschlagen). Die DB-Umstellung war in diesem Fall trotzdem erfolgreich.
    /// </summary>
    public List<string> Warnungen { get; set; } = new List<string>();

    /// <summary>Menschenlesbare Zusammenfassung des Ergebnisses.</summary>
    public string Meldung { get; set; }
}
