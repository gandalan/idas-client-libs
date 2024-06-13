using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class FarbKuerzelGruppeDTO
{
    /// <summary>
    /// Eindeutiger Bezeichner einer FarbKuerzelGruppe
    /// Wenn Guid.Empty wird Guid vom Server vergeben
    /// </summary>
    public Guid FarbKuerzelGruppeGuid { get; set; }
    public IList<Guid> Kuerzel { get; set; }
    public string Bezeichnung { get; set; }
    public DateTime? GueltigAb { get; set; }
    public DateTime? GueltigBis { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
}