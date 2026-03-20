using System;
using System.Collections.Generic;
using System.Linq;
using Gandalan.IDAS.WebApi.Util;

namespace Gandalan.IDAS.WebApi.DTO;

public class SerieDTO : IDTOWithApplicationSpecificProperties, IDTOWithAdditionalProperties
{
    /// <summary>
    /// Eindeutige ID der Serie
    /// </summary>
    public Guid SerieGuid { get; set; }

    /// <summary>
    /// Name der Serie (Langform)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Serienkürzel für Ausdrucke, Kurzanzeige usw.
    /// </summary>
    public string Kuerzel { get; set; }

    /// <summary>
    /// Beginn der Produktion (erster Produktionstag)
    /// </summary>
    public DateTime Start { get; set; } = new(2000, 1, 1);

    /// <summary>
    /// Ende der Produktion (letzter Produktionstag)
    /// </summary>
    public DateTime Ende { get; set; } = new(2099, 12, 31);

    /// <summary>
    /// Ständige Serie, dh. Start und Ende sind ungültig/irrelevant.
    /// </summary>
    public bool StaendigeSerie { get; set; }

    /// <summary>
    /// AV-Positionen in dieser Serie
    /// </summary>
    public IList<Guid> AVBelegPositionen { get; set; } = [];

    /// <summary>
    /// Kapazität dieser Serie in neutralen Kapazitätseinheiten (alt)
    /// </summary>
    public decimal Kapazitaet { get; set; }

    /// <summary>
    /// Kapazität der Serie in Minuten
    /// </summary>
    public decimal KapazitaetInMin { get; set; }

    /// <summary>
    /// Belegung der Serie in neutralen Kapazitätseinheiten. Muss beim Hinzfügen/Entfernen
    /// durch den entsprechenden Algorithmus ermittelt und gesetzt werden.
    /// </summary>
    public decimal KapazitaetReserviert { get; set; }

    /// <summary>
    /// Gibt den aktuellen Status des SerienMaterialbedarfs an. Mögliche Werte: NichtBerechnet, BerechnungGestartet, Berechnet
    /// </summary>
    public string MaterialBedarfStatus { get; set; }

    /// <summary>
    /// Gibt an, ob die Serie gesperrt ist.<br/>
    /// Wird die Serie gesperrt:
    /// <ul>
    /// <li>können keine weiteren Vorgänge automatische hinzugefügt werden.</li>
    /// <li>wird die eigentlich vorgegebene Kapazität nicht mehr automatisch berücksichtigt.</li>
    /// <li>kann "Daten aufbereiten" ausgewählt werden.</li>
    /// <li>kann "Unterlagen drucken" ausgewählt werden.</li>
    /// <li>kann "Produktionsdateien erzeugen" ausgewählt werden.</li>
    /// </ul>
    /// Die Serie kann wieder entsperrt werden.<br/>
    /// </summary>
    public bool IstGesperrt { get; set; }

    /// <summary>
    /// Informationen, wann welcher Anwender welches Dokument gedruckt hat
    /// </summary>
    public List<SerieDruckInfoDTO> DruckInfos { get; set; } = [];

    /// <summary>
    /// Änderungsdatum des Datensatzes
    /// </summary>
    public DateTime ChangedDate { get; set; }
    public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }
    public Dictionary<string, PropertyValueCollection> AdditionalProperties { get; set; }

    public void AddDruckInfo(string dokumentArt, string benutzerName)
    {
        DruckInfos.Add(new SerieDruckInfoDTO
        {
            Benutzername = benutzerName,
            DokumentArt = dokumentArt,
            Zeitstempel = DateTime.UtcNow,
        });
    }

    public IList<SerieDruckInfoDTO> GetDruckInfos(string dokumentArt)
    {
        return DruckInfos
            .Where(i => i.DokumentArt.Equals(dokumentArt, StringComparison.InvariantCultureIgnoreCase))
            .OrderBy(i => i.Zeitstempel)
            .ToList();
    }

    public SerieDruckInfoDTO GetLastDruckInfo(string dokumentArt)
    {
        return GetDruckInfos(dokumentArt).LastOrDefault();
    }
}

public class SerieDruckInfoDTO
{
    /// <summary>
    /// Eindeutige ID
    /// </summary>
    public Guid SerieDruckInfoGuid { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Benutzername des Anwenders
    /// </summary>
    public string Benutzername { get; set; }

    /// <summary>
    /// Welches Dokument wurde gedruckt (Freitext, setzt der Client)
    /// </summary>
    public string DokumentArt { get; set; }

    /// <summary>
    /// Zeitstempel (UTC)
    /// </summary>
    public DateTime Zeitstempel { get; set; }
}
