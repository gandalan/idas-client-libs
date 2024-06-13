using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Produktion;

public class ProduktionsfreigabeItemDTO
{
    public Guid VorgangGuid { get; set; }
    public long VorgangsNummer { get; set; }
    public Guid BelegGuid { get; set; }
    public DateTime Belegdatum { get; set; }
    public DateTime FreigabeDatum { get; set; }
    public string Kundenname { get; set; }
    public string Kommission { get; set; }
    public string Besitzer { get; set; }
    public string Besteller { get; set; }
    public string Bearbeiter { get; set; }
    public ProduktionsInfoDTO ProduktionsInfos { get; set; }
}