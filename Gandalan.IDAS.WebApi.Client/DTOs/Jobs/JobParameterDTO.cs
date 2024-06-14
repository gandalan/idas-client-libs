using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class JobParameterDTO
{
    public Guid JobParameterId { get; set; }
    /// <summary>
    /// E=Eingabe, A=Ausgabe
    /// </summary>
    public string Richtung { get; set; }
    public string Name { get; set; }
    public string Wert { get; set; }
    public string DatenTyp { get; set; }
}