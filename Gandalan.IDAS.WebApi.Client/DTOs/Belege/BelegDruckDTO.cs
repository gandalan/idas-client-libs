using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using Gandalan.IDAS.WebApi.Client.Constants;
using Gandalan.IDAS.WebApi.Client.DTOs.Allgemein;

namespace Gandalan.IDAS.WebApi.DTO;

public class BelegDruckDTO
{
    public BelegDruckDTO(VorgangDTO vorgang, BelegDTO beleg)
    {
        var culture = new CultureInfo("de-de");
        Salden = [];
        PositionsObjekte = [];

        if (beleg != null && vorgang != null)
        {
            beleg.SetupObjekte(vorgang);

            BelegGuid = beleg.BelegGuid;
            VorgangGuid = vorgang.VorgangGuid;
            BelegArt = beleg.BelegArt;
            BelegNummer = vorgang.VorgangsNummer;
            VorgangsNummer = vorgang.VorgangsNummer;
            BelegDatum = beleg.BelegDatum;
            VorgangErstellDatum = vorgang.ErstellDatum.ToString("d", culture);
            AenderungsDatum = beleg.AenderungsDatum;
            BelegJahr = beleg.BelegJahr;
            Schlusstext = beleg.Schlusstext;
            SammelbelegNummer = beleg.SammelbelegNummer;
            Kommission = string.IsNullOrEmpty(vorgang.Kommission) ? string.Empty : $"Kommission: {vorgang.Kommission}";
            Ausfuehrungsdatum = string.IsNullOrEmpty(beleg.AusfuehrungsDatum) ? string.Empty : $"Ausführungsdatum: {beleg.AusfuehrungsDatum}";
            AnsprechpartnerKunde = beleg.AnsprechpartnerKunde ?? "";
            Ansprechpartner = ""; //??? _apiSettings?.AuthToken?.Benutzer?.Vorname + " " + _apiSettings?.AuthToken?.Benutzer?.Nachname;
            Telefonnummer = ""; //??? _apiSettings?.AuthToken?.Benutzer?.TelefonNummer ?? "";

            if (vorgang.ApplicationSpecificProperties != null && vorgang.ApplicationSpecificProperties.Count != 0 && vorgang.ApplicationSpecificProperties.TryGetValue("settings", out var settings) && settings.TryGetValue("Kontrollkuerzel", out var kontrollkuerzel))
            {
                Kontrollkuerzel = kontrollkuerzel as string;
            }

            var abBelege = vorgang.Belege.Where(b => b.BelegArt == "AB" || b.BelegArt == "Auftragsbestätigung");
#pragma warning disable CS0618 // Suppress the warning for obsolete code
            Bestelldatum = abBelege.AnyOptimized() ? abBelege.Last().BelegDatum.ToString("d", culture) : "";
#pragma warning restore CS0618
            Belegdatum = beleg.BelegDatum.ToString("d", culture);
            Lieferzeit = ""; //???
            IsEndkunde = vorgang.Kunde?.IstEndkunde ?? false;
            IsRabatt = beleg.PositionsObjekte?.Any(i => !i.Rabatt.Equals(0m)) ?? false;
            IstSelbstabholer = beleg.IstSelbstabholer;

            if (string.IsNullOrEmpty(beleg.BelegTitelUeberschrift))
            {
                switch (beleg.BelegArt)
                {
                    case "AB":
                        BelegTitelUeberschrift = "Auftragsbestätigung";
                        break;
                    default:
                        BelegTitelUeberschrift = beleg.BelegArt;
                        break;
                }

                if (string.IsNullOrEmpty(beleg.BelegTitelZeile1))
                {
                    switch (beleg.BelegArt)
                    {
                        case "Rechnung":
                            BelegTitelZeile1 =
                                $"Nr. {beleg.BelegNummer} vom {beleg.BelegDatum.ToString(culture.DateTimeFormat.ShortDatePattern, culture)}";
                            BelegTitelZeile2 =
                                $"Vorgang Nr. {vorgang.VorgangsNummer}";
                            break;
                        default:
                            BelegTitelZeile1 =
                                $"Vorgang Nr. {vorgang.VorgangsNummer} vom {beleg.BelegDatum.ToString(culture.DateTimeFormat.ShortDatePattern, culture)}";
                            break;
                    }
                }
            }
            else
            {
                BelegTitelUeberschrift = beleg.BelegTitelUeberschrift;
                BelegTitelZeile1 = beleg.BelegTitelZeile1;
                BelegTitelZeile2 = beleg.BelegTitelZeile2;
            }

            TextFuerAnschreiben = beleg.TextFuerAnschreiben;
            BelegAdresse = new AdresseDruckDTO(beleg.BelegAdresse);
            BelegAdresseString = BelegAdresse.ToString();
            VersandAdresse = new AdresseDruckDTO(beleg.VersandAdresse);
            VersandAdresseString = VersandAdresse.ToString();

            var preiseAnzeigen = beleg.BelegArt != "Lieferschein" && beleg.BelegArt != "Bestellschein" && beleg.BelegArt != "ProduktionsAuftrag";

            if (beleg.PositionsObjekte.Any(p => p.IstSonderfarbPosition && p.Farbzuschlag == -1))
            {
                preiseAnzeigen = false;
            }

            foreach (var dto in beleg.PositionsObjekte)
            {
                if (!dto.IstAktiv && !dto.IstAlternativPosition)
                {
                    continue;
                }

                PositionsObjekte.Add(new BelegPositionDruckDTO(dto, preiseAnzeigen));
            }

            if (preiseAnzeigen)
            {
                var saldenSorted = beleg.Salden.Where(s => s.Betrag != 0 || s.SaldenStatus == "AufAnfrage").OrderBy(i => i.Reihenfolge);
                var aufAnfrage = false;
#pragma warning disable CS0618 // Suppress the warning for obsolete code
                if (saldenSorted.AnyOptimized())
#pragma warning restore CS0618
                {
                    var lastActivSalde = saldenSorted.LastOrDefault(s => !s.IstInaktiv);
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

                        Salden.Add(new BelegSaldoDruckDTO(dto, aufAnfrage) { IsLastElement = lastActivSalde != null && lastActivSalde == dto });
                    }
                }
            }

            CountValuePositionen = PositionsObjekte.Count;
            CountValueSalden = Salden.Count;
        }
    }

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
    public ObservableCollection<BelegPositionDruckDTO> PositionsObjekte { get; set; }
    public IList<BelegSaldoDruckDTO> Salden { get; set; }
    public int CountValuePositionen { get; set; }
    public int CountValueSalden { get; set; }
    public string Lieferzeit { get; set; }
    public bool IsEndkunde { get; set; }
    public bool IsRabatt { get; set; }
    public bool IstSelbstabholer { get; set; }
    public long? SammelbelegNummer { get; set; }
    public string Kontrollkuerzel { get; set; }

    public void SetTextBausteine(object textBausteine)
    {
        if (textBausteine is ExpandoObject)
        {
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
}

public class AdresseDruckDTO
{
    public AdresseDruckDTO()
    {
    }

    public AdresseDruckDTO(BeleganschriftDTO beleganschrift)
    {
        if (beleganschrift != null)
        {
            Anrede = beleganschrift.Anrede;
            Nachname = beleganschrift.Nachname;
            Vorname = beleganschrift.Vorname;
            Firmenname = beleganschrift.Firmenname;
            Zusatz = beleganschrift.Zusatz;
            AdressZusatz1 = beleganschrift.AdressZusatz1;
            Strasse = beleganschrift.Strasse;
            Hausnummer = beleganschrift.Hausnummer;
            Postleitzahl = beleganschrift.Postleitzahl;
            Ort = beleganschrift.Ort;
            Ortsteil = beleganschrift.Ortsteil;
            Land = beleganschrift.Land;
            IstInland = beleganschrift.IstInland;
        }
    }

    public string Anrede { get; set; }
    public string Nachname { get; set; }
    public string Vorname { get; set; }
    public string Firmenname { get; set; }
    public string Zusatz { get; set; }
    public string AdressZusatz1 { get; set; }
    public string Strasse { get; set; }
    public string Hausnummer { get; set; }
    public string Postleitzahl { get; set; }
    public string Ort { get; set; }
    public string Ortsteil { get; set; }
    public string Land { get; set; }
    public bool IstInland { get; set; }

    public override string ToString()
    {
        var adressText = new StringBuilder();
        {
            adressText.AppendLine(Anrede);
            adressText.AppendLine(BuildAnschriftsName());
            if (!string.IsNullOrEmpty(AdressZusatz1))
            {
                adressText.AppendLine(AdressZusatz1);
            }

            if (!string.IsNullOrEmpty(Ortsteil))
            {
                adressText.AppendLine(Ortsteil);
            }

            adressText.AppendLine($"{Strasse} {Hausnummer}");
            adressText.Append($"{Postleitzahl} {Ort}");
            if (!IstInland)
            {
                adressText.AppendLine().Append(Land?.ToUpper());
            }
        }
        return adressText.ToString();
    }

    private string BuildAnschriftsName()
    {
        var adesszusatz = "";
        var name1 = string.IsNullOrEmpty(Vorname) ? Nachname : Vorname;
        var name2 = string.IsNullOrEmpty(Vorname) ? adesszusatz : Nachname;
        return (!string.IsNullOrEmpty(Firmenname) ? $"{Firmenname}" : ($"{name1} {name2}")).Trim();
    }
}

public class BelegSaldoDruckDTO
{
    public BelegSaldoDruckDTO()
    {
    }

    public BelegSaldoDruckDTO(BelegSaldoDTO saldo, bool isAufAnfrage = false)
    {
        var culture = new CultureInfo("de-de");
        if (saldo != null)
        {
            Reihenfolge = saldo.Reihenfolge;
            Text = saldo.Text;
            if (isAufAnfrage)
            {
                Betrag = "auf Anfrage";
                Rabatt = string.Empty;
            }
            else
            {
                var vorzeichen = saldo.Typ == "Abschlag" ? '-' : ' ';
                Betrag = vorzeichen + saldo.Betrag.ToString(culture);
                Rabatt = saldo.Rabatt > 0 ? saldo.Rabatt.ToString("G29", culture) : "";
            }
        }
    }

    public int Reihenfolge { get; set; }
    public string Text { get; set; }
    public string Betrag { get; set; }
    public string Rabatt { get; set; }
    public bool IsLastElement { get; set; }
}

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

    public BelegPositionDruckDTO()
    {
    }

    public BelegPositionDruckDTO(BelegPositionDTO position, bool preiseAnzeigen = true)
    {
        var culture = new CultureInfo("de-de");
        if (position != null)
        {
            PositionsKommission = position.PositionsKommission;
            LaufendeNummer = position.LaufendeNummer;
            ArtikelNummer = position.ArtikelNummer;
            Variante = position.Variante;
            IstAlternativPosition = position.IstAlternativPosition;
            IstAktiv = position.IstAktiv;
            Menge = position.Menge;
            MengenEinheit = position.Daten.FirstOrDefault(d => d.KonfigName.Equals("Konfig.ZuschnittLaenge")) != null ? "Stk." : position.MengenEinheit;

            if (position.IstVE)
            {
                MengenEinheit = position.Daten.FirstOrDefault(d => d.KonfigName.Equals("Konfig.Artikel_VE_Einheit"))?.Wert;
                VE_Menge = position.VE_Menge;
                IstVE = position.IstVE;
            }

            if (MengenEinheit == null || MengenEinheit.Equals("st", StringComparison.InvariantCultureIgnoreCase))
            {
                MengenEinheit = "Stk.";
            }

            var einbauort = string.Empty;
            if (!string.IsNullOrWhiteSpace(position.Einbauort) && !position.Text.StartsWith("Einbauort"))
            {
                einbauort = $"Einbauort: {position.Einbauort} - ";
            }

            Text = einbauort + position.Text;
            AngebotsText = einbauort + position.AngebotsText;
            PulverCode = position.Daten.FirstOrDefault(d => d.KonfigName.Equals($"Konfig.{PosDataKonfigKeys.PulverCode}"))?.Wert;
            SonderwunschText = position.SonderwunschText;
            SonderwunschAngebotsText = position.SonderwunschAngebotsText;
            ProduktionZusatzInfo = position.ProduktionZusatzInfo;
            ProduktionZusatzInfoPrintOnReport = position.ProduktionZusatzInfoPrintOnReport;
            ProduktionZusatzInfoPrintZusatzEtikett = position.ProduktionZusatzInfoPrintZusatzEtikett;
            Zusatztexte = position.Zusatztexte;
            BelegPositionGuid = position.BelegPositionGuid;
            if (preiseAnzeigen)
            {
                if (position.PreisAufAnfrage || position.IstFehlerhaft)
                {
                    Rabatt = string.Empty;
                    Farbzuschlag = string.Empty;
                    EinzelpreisOhneFarbzuschlag = string.Empty;
                    Gesamtpreis = string.Empty;
                    Einzelpreis = "auf Anfrage";
                }
                else
                {
                    Farbzuschlag = position.Farbzuschlag.ToString(culture);
                    EinzelpreisOhneFarbzuschlag = position.Einzelpreis.ToString(culture);
                    Rabatt = position.Rabatt.Equals(0m) ? string.Empty : position.Rabatt.ToString(culture);
                    Gesamtpreis = position.Gesamtpreis.ToString(culture);
                    Einzelpreis = (position.Einzelpreis + position.Farbzuschlag).ToString(culture);
                }
            }
        }
    }
}
