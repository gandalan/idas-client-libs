using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Produktion;

public class SaegeDatenHistorieDTO
{
    public Guid SaegeDatenHistorieGuid { get; set; }
    public Guid SerieGuid { get; set; }
    public string SerienName { get; set; }
    public DateTime ErstelltAm { get; set; }
    public string DateiName { get; set; }
    public string DateiPfad { get; set; }
    public string SaegeModell { get; set; }
    public string Benutzername { get; set; }
    public string SaegeDatei { get; set; }
    public string Meldungen { get; set; }
}
