using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class MaterialBearbeitungsMethodeDTO
{
    public Guid MaterialBearbeitungsMethodeGuid { get; set; }
    public string Bezeichnung { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
}