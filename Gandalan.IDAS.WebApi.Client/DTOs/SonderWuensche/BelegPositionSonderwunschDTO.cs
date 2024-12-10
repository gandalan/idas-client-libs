using System;

namespace Gandalan.IDAS.WebApi.Data.DTO;

public class BelegPositionSonderwunschDTO
{
    public string Wert { get; set; }
    public decimal Laenge { get; set; }
    public string CalculatedLaenge { get; set; }
    public decimal Hoehe { get; set; }
    public string Typ { get; set; }
    public string Gruppe { get; set; }
    public string Farbe { get; set; }
    public string CalculatedFarbe { get; set; }
    public float Aufpreis { get; set; }
    public string Bezeichnung { get; set; }
    public string ExportName { get; set; }
    public string Kuerzel { get; set; }
    public string GehoertZuProfilMitKuerzel { get; set; }
    public string InternerName { get; set; }
    public string Standard { get; set; }
    public string ListenName { get; set; }
    public bool NichtSaegenMoeglich { get; set; }
    public bool ProfilNichtSaegen { get; set; }
    public Guid BelegPositionSonderwunschGuid { get; set; } = Guid.NewGuid();
    public bool IstKorrekturAktiv { get; set; }

    public BelegPositionSonderwunschDTO()
    {
    }

    public BelegPositionSonderwunschDTO(string bezeichnung, string exportname, string wert)
    {
        Bezeichnung = bezeichnung;
        ExportName = exportname;
        Wert = wert;
    }
}
