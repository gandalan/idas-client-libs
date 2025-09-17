using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class FarbGruppeDTO
{
    public string Bezeichnung { get; set; }
    public string AnzeigeName { get; set; }
    public Guid FarbItemGroupGuid { get; set; }
    public DateTime? GueltigAb { get; set; }
    public DateTime? GueltigBis { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
    public int Reihenfolge { get; set; }

    public bool IstGesperrt { get; set; }

    public IList<Guid> FarbItemGuids { get; set; }
    public IList<Guid> OberflaecheGuids { get; set; }

    public FarbGruppeDTO()
    {
        FarbItemGuids = [];
        OberflaecheGuids = [];
    }

    public override string ToString()
    {
        return $"{AnzeigeName} ({Bezeichnung})";
    }
}
