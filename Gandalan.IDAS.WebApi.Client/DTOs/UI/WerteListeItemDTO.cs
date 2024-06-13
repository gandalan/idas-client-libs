using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class WerteListeItemDTO
{
    public string BelegBlattText { get; set; }
    public string AngebotsText { get; set; }
    public string Beschreibung { get; set; }
    public DateTime ChangedDate { get; set; }
    public string Kuerzel { get; set; }
    public int Reihenfolge { get; set; }
    public long Version { get; set; }
    public Guid WerteListeItemGuid { get; set; }
    public DateTime? GueltigAb { get; set; }
    public DateTime? GueltigBis { get; set; }

    public override string ToString()
    {
            return Kuerzel;
        }
}