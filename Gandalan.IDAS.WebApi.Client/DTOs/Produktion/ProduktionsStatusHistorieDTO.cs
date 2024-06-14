using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class ProduktionsStatusHistorieDTO
{
    public Guid ProduktionsStatusHistorieGuid { get; set; }
    public ProduktionsStatiWerteDTO Status { get; set; }
    public string Text { get; set; }
    public int Produktionsminuten { get; set; }
    public string ProduktionsStatusInfoText { get; set; }
    public int ProduktionsStatusInProzent { get; set; }
    public DateTime Zeitstempel { get; set; }
    public string Benutzer { get; set; }
}