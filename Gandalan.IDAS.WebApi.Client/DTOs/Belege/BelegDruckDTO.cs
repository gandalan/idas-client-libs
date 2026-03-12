using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;

using Gandalan.IDAS.WebApi.Client.Constants;

namespace Gandalan.IDAS.WebApi.DTO;

public class BelegDruckDTO
{
    public Guid BelegGuid { get; set; }
    public Guid VorgangGuid { get; set; }
    public string Kopfzeile { get; set; }
    public string Fusszeile { get; set; }
    public string BelegArt { get; set; }
    public long BelegNummer { get; set; }
    public long VorgangsNummer { get; set; }
    public DateTime BelegDatum { get; set; }
    public string VorgangErstellDatum { get; set; }
    public DateTime AenderungsDatum { get; set; }
    public int BelegJahr { get; set; }
    public string Schlusstext { get; set; }
    public string BelegTitelUeberschrift { get; set; }
    public string BelegTitelZeile1 { get; set; }
    public string BelegTitelZeile2 { get; set; }
    public string TextFuerAnschreiben { get; set; }
    public string Kommission { get; set; }
    public string Ausfuehrungsdatum { get; set; }
    public string AnsprechpartnerKunde { get; set; }
    public string Ansprechpartner { get; set; }
    public string Telefonnummer { get; set; }
    public string Bestelldatum { get; set; }
    public string Belegdatum { get; set; }
    public AdresseDruckDTO BelegAdresse { get; set; }
    public string BelegAdresseString { get; set; }
    public AdresseDruckDTO VersandAdresse { get; set; }
    public string VersandAdresseString { get; set; }

    /// <summary>
    /// BG-5: Seller Postal Adresse (Anschrift des Rechnungssteller für ZUGfeRD
    /// </summary>
    public AdresseDruckDTO RechnungsstellerAdresse { get; set; }
    public string RechnungsstellerAdresseString { get; set; }

    public 

    public ObservableCollection<BelegPositionDruckDTO> PositionsObjekte { get; set; } = [];
    public IList<BelegSaldoDruckDTO> Salden { get; set; } = [];
    public int CountValuePositionen { get; set; }
    public int CountValueSalden { get; set; }
    public string Lieferzeit { get; set; }
    public bool IsEndkunde { get; set; }
    public bool IsRabatt { get; set; }
    public bool IstSelbstabholer { get; set; }
    public long? SammelbelegNummer { get; set; }
    public string Kontrollkuerzel { get; set; }

    /// <summary>
    /// Gets or sets if positions in the voucher have prices or capture data that are stale and differ to the price list/capture data list that
    /// was valid on the created date of the voucher
    /// </summary>
    public bool HasVariantPriceCaptureInfo { get; set; }

    private readonly VorgangDTO _vorgangDto;
    private readonly BelegDTO _belegDto;

    public BelegDruckDTO(VorgangDTO vorgangDto, BelegDTO belegDto, MandantDTO mandantDto = null, bool hasVariantPriceCaptureInfo = false)
    {
        if (_belegDto == null || _vorgangDto == null)
        {
            return;
        }

        _vorgangDto = vorgangDto;
        _belegDto = belegDto;

        _belegDto.SetupObjekte(_vorgangDto);

        InitialisiereGrunddaten(hasVariantPriceCaptureInfo);
        InitialisiereFormattierteStrings();
        InitialisiereUntertitel();
        InitialisiereAdressen();
        InitialisierePositionenUndSalden();
    }

    private void InitialisiereGrunddaten(bool hasVariantPriceCaptureInfo)
    {
        BelegGuid = _belegDto.BelegGuid;
        VorgangGuid = _vorgangDto.VorgangGuid;
        BelegArt = _belegDto.BelegArt;
        BelegNummer = _vorgangDto.VorgangsNummer;
        VorgangsNummer = _vorgangDto.VorgangsNummer;
        BelegDatum = _belegDto.BelegDatum;
        VorgangErstellDatum = _vorgangDto.ErstellDatum.ToString("d", Global.CultureInfo);
        AenderungsDatum = _belegDto.AenderungsDatum;
        BelegJahr = _belegDto.BelegJahr;
        Schlusstext = _belegDto.Schlusstext;
        SammelbelegNummer = _belegDto.SammelbelegNummer;
        HasVariantPriceCaptureInfo = hasVariantPriceCaptureInfo;
        TextFuerAnschreiben = _belegDto.TextFuerAnschreiben;
        AnsprechpartnerKunde = _belegDto.AnsprechpartnerKunde ?? "";
        IsEndkunde = _vorgangDto.Kunde?.IstEndkunde ?? false;
        IsRabatt = _belegDto.PositionsObjekte?.Any(i => !i.Rabatt.Equals(0m)) ?? false;
        IstSelbstabholer = _belegDto.IstSelbstabholer;
        Kontrollkuerzel = ExtrahiereKontrollkuerzel();
    }

    private void InitialisiereFormattierteStrings()
    {
        Kommission = string.IsNullOrEmpty(_vorgangDto.Kommission) ? string.Empty : $"Kommission: {_vorgangDto.Kommission}";
        Ausfuehrungsdatum = string.IsNullOrEmpty(_belegDto.AusfuehrungsDatum) ? string.Empty : $"Ausführungsdatum: {_belegDto.AusfuehrungsDatum}";
        Bestelldatum = BestimmeBestelldatum();
        Belegdatum = _belegDto.BelegDatum.ToString("d", Global.CultureInfo);
        Lieferzeit = "";
        Ansprechpartner = "";
        Telefonnummer = "";
    }

    private string ExtrahiereKontrollkuerzel()
    {
        if (_vorgangDto.ApplicationSpecificProperties?.Count == 0)
        {
            return null;
        }

        if (_vorgangDto.ApplicationSpecificProperties.TryGetValue("settings", out var settings) &&
            settings.TryGetValue("Kontrollkuerzel", out var kontrollkuerzel))
        {
            return kontrollkuerzel as string;
        }

        return null;
    }

    private string BestimmeBestelldatum()
    {
        var abBelege = _vorgangDto.Belege.Where(b => b.BelegArt == "AB" || b.BelegArt == "Auftragsbestätigung");
        return abBelege.Any() ? abBelege.Last().BelegDatum.ToString("d", Global.CultureInfo) : "";
    }

    private void InitialisiereUntertitel()
    {
        if (!string.IsNullOrEmpty(_belegDto.BelegTitelUeberschrift))
        {
            BelegTitelUeberschrift = _belegDto.BelegTitelUeberschrift;
            BelegTitelZeile1 = _belegDto.BelegTitelZeile1;
            BelegTitelZeile2 = _belegDto.BelegTitelZeile2;
            return;
        }

        BelegTitelUeberschrift = _belegDto.BelegArt switch
        {
            "AB" => "Auftragsbestätigung",
            _ => _belegDto.BelegArt,
        };

        if (string.IsNullOrEmpty(_belegDto.BelegTitelZeile1))
        {
            SetzeMerkmaleUntertitel();
        }
    }

    private void SetzeMerkmaleUntertitel()
    {
        var dateString = _belegDto.BelegDatum.ToString(Global.CultureInfo.DateTimeFormat.ShortDatePattern, Global.CultureInfo);

        if (_belegDto.BelegArt == "Rechnung")
        {
            BelegTitelZeile1 = $"Nr. {_belegDto.BelegNummer} vom {dateString}";
            BelegTitelZeile2 = $"Vorgang Nr. {_vorgangDto.VorgangsNummer}";
        }
        else
        {
            BelegTitelZeile1 = $"Vorgang Nr. {_vorgangDto.VorgangsNummer} vom {dateString}";
        }
    }

    private void InitialisiereAdressen()
    {
        BelegAdresse = new AdresseDruckDTO(_belegDto.BelegAdresse);
        BelegAdresseString = BelegAdresse.ToString();
        VersandAdresse = new AdresseDruckDTO(_belegDto.VersandAdresse);
        VersandAdresseString = VersandAdresse.ToString();
    }

    private void InitialisierePositionenUndSalden()
    {
        var preiseAnzeigen = BestimmePreisichtbarkeit();
        VerarbeitePositionen(preiseAnzeigen);

        if (preiseAnzeigen)
        {
            VerarbeiteSalden();
        }

        CountValuePositionen = PositionsObjekte.Count;
        CountValueSalden = Salden.Count;
    }

    private bool BestimmePreisichtbarkeit()
    {
        var preiseAnzeigen = _belegDto.BelegArt != "Lieferschein" && _belegDto.BelegArt != "Bestellschein" && _belegDto.BelegArt != "ProduktionsAuftrag";

        if (preiseAnzeigen && _belegDto.PositionsObjekte.Any(p => p.IstSonderfarbPosition && p.Farbzuschlag == -1))
        {
            return false;
        }

        return preiseAnzeigen;
    }

    private void VerarbeitePositionen(bool preiseAnzeigen)
    {
        foreach (var dto in _belegDto.PositionsObjekte)
        {
            if (!dto.IstAktiv && !dto.IstAlternativPosition)
            {
                continue;
            }

            PositionsObjekte.Add(new BelegPositionDruckDTO(dto, preiseAnzeigen));
        }
    }

    private void VerarbeiteSalden()
    {
        var saldenSorted = _belegDto.Salden.OrderBy(i => i.Reihenfolge).ToList();

        if (saldenSorted.Count == 0)
        {
            return;
        }

        var lastActiveSalde = saldenSorted.LastOrDefault(s => !s.IstInaktiv);
        var aufAnfrage = false;

        foreach (var dto in saldenSorted)
        {
            if (dto.IstInaktiv)
            {
                continue;
            }

            if (dto.SaldenStatus == "AufAnfrage")
            {
                aufAnfrage = true;
            }

            Salden.Add(new BelegSaldoDruckDTO(dto, aufAnfrage)
            {
                IsLastElement = lastActiveSalde != null && lastActiveSalde == dto
            });
        }
    }

    public void SetTextBausteine(object textBausteine)
    {
        if (textBausteine is not ExpandoObject)
        {
            return;
        }

        var settingsDict = textBausteine as IDictionary<string, object>;
        var keys = new List<string>(settingsDict.Keys);

        if (keys.Contains(BelegArt))
        {
            dynamic existingValue = settingsDict[BelegArt];
            Kopfzeile = existingValue.Kopfzeile;
            Fusszeile = existingValue.Fusszeile;
        }
    }
}
