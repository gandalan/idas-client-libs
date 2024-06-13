using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class MaterialDTO
{
    public Guid MaterialGuid { get; set; }
    public string Bezeichnung { get; set; }
    public bool IstSaegbar { get; set; }
    public bool IstBeschichtbar { get; set; }
    public bool IstFaerbbar { get; set; }
    public DateTime ChangedDate { get; set; }
    public int Version { get; set; }
    public List<Guid> MoeglicheBearbeitungsMethoden { get; set; }
}