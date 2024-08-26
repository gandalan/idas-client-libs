using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class PositionsDatenDTO
{
    public Guid PositionsDatenGuid { get; set; }
    public string VariantenName { get; set; }
    public string ArtikelNummer { get; set; }
    public int PositionsNummer { get; set; }
    public int AlternativPositionZuNummer { get; set; }
    public string Besonderheiten { get; set; }
    public string Einbauort { get; set; }
    public decimal Menge { get; set; }
    public string MengenEinheit { get; set; }
    public string BelegKommission { get; set; }
    public string PositionsKommission { get; set; }
    public string Text { get; set; }
    public string AngebotsText { get; set; }
    public string SonderwunschText { get; set; }
    public string SonderwunschAngebotsText { get; set; }
    public DateTime ErfassungsDatum { get; set; }
    public float BmBreite { get; set; }
    public float BmHoehe { get; set; }
    public string FarbKuerzel { get; set; }
    public Guid FarbKuerzelGuid { get; set; }
    public string FarbItem { get; set; }
    public Guid FarbItemGuid { get; set; }
    public string FarbCode { get; set; }
    public string FarbBezeichnung { get; set; }
    public string FarbZusatzText { get; set; }
    public string OberflaecheBezeichnung { get; set; }
    public Guid OberflaecheGuid { get; set; }
    public string PulverCode { get; set; }
    public bool IstSonderFarbPosition { get; set; }
    public string Gewebe { get; set; }

    public DateTime LieferDatum { get; set; }
    public string Serie { get; set; }
    public string PCode { get; set; }
    public string VorgangsNummer { get; set; }
    public string DruckDatum { get; set; }
    public string VersandAdresse { get; set; }

    public string DataErstellDatum { get; set; }
    public string BelegNummer { get; set; }
    public string BelegJahr { get; set; }
    public string Breite { get; set; }
    public string Hoehe { get; set; }
    public string Oeffnungsrichtung { get; set; }
    public string Farbe { get; set; }
}