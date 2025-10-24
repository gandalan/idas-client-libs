using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class SerieHistorieDTO
{
    public Guid SerieHistorieGuid { get; set; }
    public Guid SerieGuid { get; set; }
    public string SerienName { get; set; }
    public string Text { get; set; }
    public DateTime Zeitstempel { get; set; }
    public string Benutzer { get; set; }
}
