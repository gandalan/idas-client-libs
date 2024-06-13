using System;

namespace Gandalan.IDAS.WebApi.DTO;

public partial class KonturElementDTO
{
    public Guid KonturElementGuid { get; set; }

    public int AX { get; set; }
    public int AY { get; set; }
    public int AZ { get; set; }
    public int EX { get; set; }
    public int EY { get; set; }
    public int EZ { get; set; }
    public int MX { get; set; }
    public int MY { get; set; }
    public int MZ { get; set; }
    public int KreisRichtung { get; set; }
    public string MakroName { get; set; }
    public string MakroParameter { get; set; }
    public string OperationArt { get; set; }
    public int OperationNr { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
}