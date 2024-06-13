using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class AnpassungDTO
{
    public Guid AnpassungGuid { get; set; }
    public string Art { get; set; }
    public bool GiltFuerBesitzer { get; set; }
    public bool GiltFuerAlleUntermandanten { get; set; }
    public bool GiltFuerZielMandant { get; set; }
    public Guid ZielMandantGuid { get; set; }
    public string Content { get; set; }

    public Guid WarengruppeGuid { get; set; }
    public Guid ArtikelGuid { get; set; }

    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
}