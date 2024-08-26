using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class OberflaecheDTO
{
    public Guid OberflaecheGuid { get; set; }
    public string Bezeichnung { get; set; }
    public DateTime? GueltigAb { get; set; }
    public DateTime? GueltigBis { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
}