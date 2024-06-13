using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class KomponenteVariableDTO
{
    public Guid KomponenteVariableGuid { get; set; }
    public bool? Anpassbar { get; set; }
    public string AnzeigeText { get; set; }
    public short Datentyp { get; set; }
    public bool EingabeFeldAnzeigen { get; set; }
    public string EingabeFeldArt { get; set; }
    public string EingabeFeldP1 { get; set; }
    public string EingabeFeldP2 { get; set; }
    public string EingabeFeldP3 { get; set; }
    public string Name { get; set; }
    public string WerteListe { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
}