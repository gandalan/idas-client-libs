using System;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Gesamtbedarf;
public interface IGesamtMaterialbedarfItem
{
    public Guid GesamtMaterialbedarfGuid { get; set; }
    public string KatalogNummer { get; set; }
    public string ArtikelBezeichnung { get; set; }
    public string SerienName { get; set; }
    public string Einheit {  get; set; }
    public decimal Stueckzahl { get; set; }
    public decimal UngedeckteStueckzahl { get; }
    public float ZuschnittLaenge { get; set; }
    public decimal Laufmeter { get; set; }
    public decimal UngedeckteLaufmeter { get; }
    public decimal? VE_Menge { get; set; }
    public string FarbBezeichnung { get; set; }
    public string FarbZusatzText { get; set; }
    public string FarbKuerzel { get; set; }
    public Guid FarbKuerzelGuid { get; set; }
    public string FarbCode { get; set; }
    public string FarbeItem { get; set; }
    public Guid FarbItemGuid { get; set; }
    public string OberFlaeche { get; set; }
    public Guid OberFlaecheGuid { get; set; }
    public string PulverCode { get; set; }
    public DateTime Liefertermin { get; set; }
    public bool IstZuschnitt { get; set; }
    public bool IstSonderfarbe { get; set; }

    GesamtMaterialbedarfDTO ToDTO();
}
