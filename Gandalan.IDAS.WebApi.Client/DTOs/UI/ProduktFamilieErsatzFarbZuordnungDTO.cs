using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class ProduktFamilieErsatzFarbZuordnungDTO
{
    public Guid ProduktFamilieErsatzFarbZuordnungGuid { get; set; }
    public DateTime ChangedDate { get; set; }
    public long Version { get; set; }
    public Guid FarbItemGuid { get; set; }
    public Guid ErsatzFarbItemGuid { get; set; }
    public DateTime? GueltigAb { get; set; }
    public DateTime? GueltigBis { get; set; }
}