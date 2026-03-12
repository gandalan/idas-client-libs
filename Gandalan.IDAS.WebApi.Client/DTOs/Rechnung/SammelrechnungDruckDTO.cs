using System;
using System.Collections.Generic;
using System.Globalization;

using Gandalan.IDAS.WebApi.Client.Constants;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;

public class SammelrechnungDruckDTO
{
    public Guid SammelrechnungGuid { get; set; }
    public long SammelrechnungNummer { get; set; }

    // Wird nur für den Druck verwendet, damit beim automatischen Export die Rechnungsnummer mit im Dateinamen ausgegeben wird
    public long Vorgangnummer { get; set; }
    public long Belegnummer { get; set; }
    public KontaktDTO Kunde { get; set; }
    public string ErstellDatum { get; set; }
    public string Kopfzeile { get; set; }
    public string Fusszeile { get; set; }
    public string Schlusstext { get; set; }
    public string PageTitle { get; set; }
    public string PageSubtitle1 { get; set; }
    public string PageSubtitle2 { get; set; }
    public string Ansprechpartner { get; set; }
    public string Telefonnummer { get; set; }
    public string Lieferzeit { get; set; }
    public AdresseDruckDTO RechnungsAdresse { get; set; }
    public string RechnungsAdresseString { get; set; }
    public IList<SammelrechnungPositionDruckDTO> RechnungPositionen { get; set; }
    public IList<SammelrechnungSaldoDruckDTO> Salden { get; set; }
    public int CountValuePositionen { get; set; }
    public int CountValueSalden { get; set; }
    public bool IsEndkunde { get; set; }
    public IList<BelegDruckDTO> EinzelrechnungDTOs { get; set; }
    public string Belegart { get; set; } = "Sammelrechnung";
    public string Ueberschrift { get; set; }

    public SammelrechnungDruckDTO(SammelrechnungDTO sammelrechnung)
    {
        SammelrechnungGuid = sammelrechnung.SammelrechnungGuid;
        SammelrechnungNummer = sammelrechnung.SammelrechnungsNummer;
        Belegnummer = Vorgangnummer = sammelrechnung.SammelrechnungsNummer;
        Kunde = sammelrechnung.Kontakt;
        Kunde.SchlussTextRechnung = sammelrechnung.Schlusstext;
        Kunde.Zahlungsbedingung = sammelrechnung.ZahlungsBedingungen;
        ErstellDatum = sammelrechnung.ErstellDatum.ToString("d", Global.CultureInfo);
        Kopfzeile = sammelrechnung.Kopfzeile;
        Fusszeile = sammelrechnung.Fusszeile;
        Schlusstext = sammelrechnung.Schlusstext;
        SetTitleAndSubtitle(sammelrechnung, Global.CultureInfo);
        Ansprechpartner = sammelrechnung.Ansprechpartner;
        Telefonnummer = sammelrechnung.Telefonnummer;
        Lieferzeit = sammelrechnung.Liefertermin;
        RechnungsAdresseString = sammelrechnung.RechnungsAdresse.ToString();
        RechnungPositionen = SammelrechnungPositionDruckDTO.ListFromDTOs(sammelrechnung.Positionen);
        Salden = SammelrechnungSaldoDruckDTO.ListFromDTOs(sammelrechnung.Salden);

        CountValuePositionen = sammelrechnung.Positionen.Count;
        CountValueSalden = sammelrechnung.Salden.Count;
        IsEndkunde = sammelrechnung.Kontakt.IstEndkunde;

        EinzelrechnungDTOs = sammelrechnung.EinzelrechnungDTOs;
    }

    private void SetTitleAndSubtitle(SammelrechnungDTO dto, CultureInfo culture)
    {
        if (string.IsNullOrEmpty(dto.PageTitle))
        {
            PageTitle = "Sammelrechnung";
            PageSubtitle1 = $"Nr. {dto.SammelrechnungsNummer} vom {dto.ErstellDatum.ToString(culture.DateTimeFormat.ShortDatePattern, culture)}";
        }
        else
        {
            PageTitle = dto.PageTitle;
            PageSubtitle1 = dto.PageSubtitle1;
            PageSubtitle2 = dto.PageSubtitle2;
        }
    }
}
