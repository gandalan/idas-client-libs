using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class BearbeitungsGruppeDTO
{
    public Guid BearbeitungsGruppeGuid { get; set; }
    public string BearbeitungsGruppeName { get; set; }
    public decimal AnkerPunktX { get; set; }
    public decimal AnkerPunktY { get; set; }
    public List<Guid> BearbeitungGuids { get; set; }
}
