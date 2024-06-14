using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class ProduktFamilieFarbZuordnungDTO
{
    public string Kuerzel { get; set; }
    public Guid ProduktFamilieFarbZuordnungGuid { get; set; }
    public DateTime ChangedDate { get; set; }
    public long Version { get; set; }
    public Guid FarbItemGuid { get; set; }
    public DateTime? GueltigAb { get; set; }
    public DateTime? GueltigBis { get; set; }
}