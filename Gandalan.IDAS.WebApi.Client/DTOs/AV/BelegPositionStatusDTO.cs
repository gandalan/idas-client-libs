using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.AV;

public class BelegPositionStatusDTO
{
    public Guid BelegPositionGuid { get; set; }

    public bool AVPosAnzahlPruefen { get; set; }

    public bool AVDatenBerechnen { get; set; }

    public bool AVDatenAktualisieren { get; set; }
    public bool ResetFailCounter { get; set; }

    public DateTime ChangedDate { get; set; }
}
