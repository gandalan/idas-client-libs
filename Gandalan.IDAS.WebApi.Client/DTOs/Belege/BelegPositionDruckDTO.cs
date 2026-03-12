using System;
using System.Collections.Generic;
using System.Linq;

using Gandalan.IDAS.WebApi.Client.Constants;
using Gandalan.IDAS.WebApi.Client.DTOs.Allgemein;

namespace Gandalan.IDAS.WebApi.DTO;

public class BelegPositionDruckDTO
{
    public string PositionsKommission { get; set; }
    public int LaufendeNummer { get; set; }
    public string ArtikelNummer { get; set; }
    public string Variante { get; set; }
    public bool IstAlternativPosition { get; set; }
    public bool IstAktiv { get; set; }
    public decimal Menge { get; set; }
    public string EinzelpreisOhneFarbzuschlag { get; set; }
    public string Einzelpreis { get; set; }
    public string Rabatt { get; set; }
    public string Gesamtpreis { get; set; }
    public string Farbzuschlag { get; set; }
    public string MengenEinheit { get; set; }
    public string Text { get; set; }
    public string AngebotsText { get; set; }
    public string PulverCode { get; set; }
    public string SonderwunschText { get; set; }
    public string SonderwunschAngebotsText { get; set; }
    public string ProduktionZusatzInfo { get; set; }
    public bool ProduktionZusatzInfoPrintOnReport { get; set; }
    public bool ProduktionZusatzInfoPrintZusatzEtikett { get; set; }
    public bool IstVE { get; set; }
    public decimal? VE_Menge { get; set; }
    public IList<ZusatztextDTO> Zusatztexte { get; set; }
    public Guid BelegPositionGuid { get; set; }

    private readonly BelegPositionDTO _positionDto;

    public BelegPositionDruckDTO() { }

    public BelegPositionDruckDTO(BelegPositionDTO positionDto, bool preiseAnzeigen = true)
    {
        if (_positionDto == null)
        {
            return;
        }

        _positionDto = positionDto;

        InitialisiereGrunddaten();
        BestimmeMengenEinheit();
        IntegrieereEinbauort();
        InitialisiereProduktionsdaten();
        InitialisierePreise(preiseAnzeigen);
    }

    private void InitialisiereGrunddaten()
    {
        PositionsKommission = _positionDto.PositionsKommission;
        LaufendeNummer = _positionDto.LaufendeNummer;
        ArtikelNummer = _positionDto.ArtikelNummer;
        Variante = _positionDto.Variante;
        IstAlternativPosition = _positionDto.IstAlternativPosition;
        IstAktiv = _positionDto.IstAktiv;
        Menge = _positionDto.Menge;
        PulverCode = _positionDto.Daten.FirstOrDefault(d => d.KonfigName.Equals($"Konfig.{PosDataKonfigKeys.PulverCode}"))?.Wert;
        SonderwunschText = _positionDto.SonderwunschText;
        SonderwunschAngebotsText = _positionDto.SonderwunschAngebotsText;
        Zusatztexte = _positionDto.Zusatztexte;
        BelegPositionGuid = _positionDto.BelegPositionGuid;
    }

    private void BestimmeMengenEinheit()
    {
        // Zuschnitt hat Vorrang
        var hatZuschnittLaenge = _positionDto.Daten.FirstOrDefault(d => d.KonfigName.Equals("Konfig.ZuschnittLaenge")) != null;
        if (hatZuschnittLaenge)
        {
            MengenEinheit = "Stk.";
            return;
        }

        // VE-spezifische Einheit
        if (_positionDto.IstVE)
        {
            MengenEinheit = _positionDto.Daten.FirstOrDefault(d => d.KonfigName.Equals("Konfig.Artikel_VE_Einheit"))?.Wert;
            VE_Menge = _positionDto.VE_Menge;
            IstVE = _positionDto.IstVE;
        }
        else
        {
            MengenEinheit = _positionDto.MengenEinheit;
        }

        // Normalisierung auf Standard
        if (string.IsNullOrEmpty(MengenEinheit) || MengenEinheit.Equals("st", StringComparison.InvariantCultureIgnoreCase))
        {
            MengenEinheit = "Stk.";
        }
    }

    private void IntegrieereEinbauort()
    {
        var einbauortPraefix = ErstelleEinbauortPraefix();
        Text = einbauortPraefix + _positionDto.Text;
        AngebotsText = einbauortPraefix + _positionDto.AngebotsText;
    }

    private string ErstelleEinbauortPraefix()
    {
        return string.IsNullOrWhiteSpace(_positionDto.Einbauort) || _positionDto.Text.StartsWith("Einbauort")
            ? string.Empty
            : $"Einbauort: {_positionDto.Einbauort} - ";
    }

    private void InitialisiereProduktionsdaten()
    {
        ProduktionZusatzInfo = _positionDto.ProduktionZusatzInfo;
        ProduktionZusatzInfoPrintOnReport = _positionDto.ProduktionZusatzInfoPrintOnReport;
        ProduktionZusatzInfoPrintZusatzEtikett = _positionDto.ProduktionZusatzInfoPrintZusatzEtikett;
    }

    private void InitialisierePreise(bool preiseAnzeigen)
    {
        if (!preiseAnzeigen)
        {
            return;
        }

        if (_positionDto.PreisAufAnfrage)
        {
            InitialisierePreiseAufAnfrage();
        }
        else
        {
            InitialisierePreiseNormal();
        }
    }

    private void InitialisierePreiseAufAnfrage()
    {
        Rabatt = string.Empty;
        Farbzuschlag = string.Empty;
        EinzelpreisOhneFarbzuschlag = string.Empty;
        Gesamtpreis = string.Empty;
        Einzelpreis = "auf Anfrage";
    }

    private void InitialisierePreiseNormal()
    {
        Farbzuschlag = _positionDto.Farbzuschlag.ToString(Global.CultureInfo);
        EinzelpreisOhneFarbzuschlag = _positionDto.Einzelpreis.ToString(Global.CultureInfo);
        Rabatt = _positionDto.Rabatt.Equals(0m) ? string.Empty : _positionDto.Rabatt.ToString(Global.CultureInfo);
        Gesamtpreis = _positionDto.Gesamtpreis.ToString("N2", Global.CultureInfo);
        Einzelpreis = (_positionDto.Einzelpreis + _positionDto.Farbzuschlag).ToString("N2", Global.CultureInfo);
    }
}
