using System.ComponentModel;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Belege;

public enum BelegStatus
{
    Unbekannt = 0,
    Erfasst = 10,
    [Description("Gelöscht")]
    Geloescht = 20,
    [Description("Angebot angefragt")]
    AngebotAngefragt = 30,
    Bestellt = 40,
    [Description("Auftrag bestätigt")]
    AuftragBestaetigt = 50,
    [Description("in Produktion")]
    InProduktion = 60,
    [Description("Produktion abgeschlossen")]
    ProduktionAbgeschlossen = 70,
    [Description("Versand vorbereitet")]
    VersandVorbereitet = 80,
    [Description("Versand ausgeführt")]
    VersandAusgefuehrt = 90,
    [Description("Ware ausgeliefert")]
    WareAusgeliefert = 100,
    Reklamation = 110,
    [Description("Bestellung abgeschlossen")]
    BestellungAbgeschlossen = 120,
    Fakturiert = 130,
    Storniert = 140,
    Importiert = 150,
    [Description("Beleg kopiert")]
    BelegKopiert = 160,
}
