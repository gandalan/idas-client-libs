using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Client.DTOs.Allgemein;
using Gandalan.IDAS.WebApi.Data.DTO;
using Gandalan.IDAS.WebApi.Util;

namespace Gandalan.IDAS.WebApi.DTO;

public class BelegPositionDTO : IDTOWithApplicationSpecificProperties
{
    public Guid BelegPositionGuid { get; set; }
    public Guid NachfolgeBelegPositionGuid { get; set; }
    public DateTime ErfassungsDatum { get; set; }

    /// <summary>
    /// Die fortlaufende Nummer für jede Position innerhalb des Beleges.
    /// Über diese Nummer wird auch die Ausgabenreihenfolge bestimmt.
    /// </summary>
    public int LaufendeNummer { get; set; }
    /// <summary>
    /// Die sichtbare PositionsNummer, sie kann auch leer sein, z.Bsp. bei Titeln, Text-  oder alternativen Positionen.
    /// Sie sollte nicht mehr als max. 4 Zeichen lang sein, damit die Pos.-Splate auf dem Beleg nicht zu breit wird.
    /// </summary>
    public string PositionsNummer { get; set; }

    public string ArtikelNummer { get; set; }
    public string Variante { get; set; }
    public Guid VarianteGuid { get; set; }
    public string Einbauort { get; set; }
    public string PositionsKommission { get; set; }
    public bool IstAlternativPosition { get; set; }
    public bool IstAktiv { get; set; }
    public bool IstFehlerhaft { get; set; }
    public bool IstStorniert { get; set; }
    public bool IstFehlerhaftSFOhnePreis { get; set; }
    public bool IstGesperrt { get; set; }
    public decimal Menge { get; set; }
    public decimal Listenpreis { get; set; }
    public decimal Einzelpreis { get; set; }
    public decimal Rabatt { get; set; }
    public decimal AufAbschlag { get; set; }
    public decimal Gesamtpreis { get; set; }
    public decimal Steuersatz { get; set; }
    public string MengenEinheit { get; set; }
    public string Text { get; set; }
    public virtual IList<BelegPositionDatenDTO> Daten { get; set; }
    public virtual IList<BelegPositionSonderwunschDTO> Sonderwuensche { get; set; }
    public virtual IList<BelegPositionHistorieDTO> Historie { get; set; }
    public virtual IList<ZusatztextDTO> Zusatztexte { get; set; }
    public string Besonderheiten { get; set; }
    public string ProduktionZusatzInfo { get; set; }
    public bool ProduktionZusatzInfoPrintOnReport { get; set; }
    public bool ProduktionZusatzInfoPrintZusatzEtikett { get; set; }
    public bool IstBruttoGesamtpreis { get; set; }
    public bool IstBruttoEinzelpreis { get; set; }
    public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }
    public bool IstSonderfarbPosition { get; set; }
    public decimal Farbzuschlag { get; set; }
    public bool IstFarbzuschlagManuell { get; set; }
    public string AngebotsText { get; set; }
    public string SonderwunschText { get; set; }
    public string SonderwunschAngebotsText { get; set; }
    public DateTime? ProduktionsDatum { get; set; }
    public DateTime? LieferDatum { get; set; }
    public DateTime? ProduktionsAuftragErstellt { get; set; }
    public Guid? GeplanteSerieGuid { get; set; }
    public Guid? VorgaengerBelegPositionGuid { get; set; }
    /// <summary>
    /// Gültige Werte: "NichtFreigegeben", "Freigegeben", "Abgerechnet"
    /// </summary>
    public string FakturaKennzeichen { get; set; }
    public bool IstAusserhalbGewaehrleistung { get; set; }
    public bool IstVE { get; set; }
    public decimal? VE_Menge { get; set; }
    public Guid? FrontendLogikGuid { get; set; }

    public bool IstFremdfertigung { get; set; }
    public Guid? FremdfertigungMandantGuid { get; set; }

    public decimal? Arbeitsminuten { get; set; }
    public decimal? Elementgewicht { get; set; }
    public bool PreisAufAnfrage { get; set; }

    public BelegPositionDTO()
    {
        Daten = [];
        Historie = [];
        Zusatztexte = [];
    }

    public BelegPositionDTO Clone()
    {
        return ObjectCloner.Clone(this);
    }
}