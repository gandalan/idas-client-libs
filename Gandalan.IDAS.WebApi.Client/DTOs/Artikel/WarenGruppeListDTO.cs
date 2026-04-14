using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Kompakte Darstellung einer Warengruppe für Listenansichten.
/// Enthält Metadaten und ArtikelGuids, aber keine vollständigen Artikeldaten.
/// Für vollständige Artikeldaten: GET /api/warengruppe/{id}/artikel
/// </summary>
public class WarenGruppeListDTO
{
    public Guid WarenGruppeGuid { get; set; }
    public int Nummer { get; set; }
    public string Bezeichnung { get; set; } = string.Empty;
    public bool IstEKPWarengruppe { get; set; }
    public string FrontendLogik { get; set; } = string.Empty;
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
    public int ArtikelAnzahl { get; set; }
    public IList<Guid> ArtikelGuids { get; set; } = [];
}
