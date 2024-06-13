using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Reports;

public class SerienSaegelisteProfilgruppeDataDTO
{
    public string Titel { get; set; }
    public string ProduktionsFarbText { get; set; }
    public string Farbe { get; set; }
    public string FarbeR { get; set; }
    public string FarbeG { get; set; }
    public string FarbeB { get; set; }
    public string Oberflaeche { get; set; }
    public string ProfilSchnittBild { get; set; }
    public string Gesamtbedarf { get; set; }

    public List<SerienSaegelistenProfilgruppeSchnittDataDTO> Schnitte { get; set; } = [];
    public int FarbeAsInt { get; set; }

    public string KatalogNummer { get; set; }

    public string FarbKuerzel { get; set; }
}