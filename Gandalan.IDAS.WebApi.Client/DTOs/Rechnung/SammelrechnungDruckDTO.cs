using Gandalan.IDAS.WebApi.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung
{
    public class SammelrechnungDruckDTO
    {
        public Guid SammelrechnungGuid { get; set; }
        public long SammelrechnungNummer { get; set; }
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

        public SammelrechnungDruckDTO(SammelrechnungDTO sammelrechnung)
        {
            var culture = new CultureInfo("de-de");

            SammelrechnungGuid = sammelrechnung.SammelrechnungGuid;
            SammelrechnungNummer = sammelrechnung.SammelrechnungsNummer;
            Kunde = sammelrechnung.Kontakt;
            ErstellDatum = sammelrechnung.ErstellDatum.ToString("d", culture);
            Kopfzeile = sammelrechnung.Kopfzeile;
            Fusszeile = sammelrechnung.Fusszeile;
            Schlusstext = sammelrechnung.Schlusstext;
            SetTitleAndSubtitle(sammelrechnung, culture);
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
            if (dto.PageTitle.IsNullOrEmpty())
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

    public class SammelrechnungPositionDruckDTO
    {
        public int LaufendeNummer { get; set; }
        public string RechnungNummer { get; set; }
        public string RechnungDatum { get; set; }
        public string RechnungKommission { get; set; }
        public string RechnungBetrag { get; set; }
        public IList<SammelrechnungSaldoDruckDTO> RechnungSalden { get; set; }

        public SammelrechnungPositionDruckDTO(SammelrechnungPositionenDTO position)
        {
            var culture = new CultureInfo("de-de");

            LaufendeNummer = position.LaufendeNummer;
            RechnungNummer = position.RechnungNummer.ToString();
            RechnungDatum = position.RechnungDatum.ToString("d", culture);
            RechnungKommission = position.RechnungKommision;
            RechnungBetrag = position.RechnungBetrag.ToString(culture);
            RechnungSalden = SammelrechnungSaldoDruckDTO.ListFromDTOs(position.Salden);
        }
        public static List<SammelrechnungPositionDruckDTO> ListFromDTOs(IList<SammelrechnungPositionenDTO> positionen)
        {
            var druckPositionen = new List<SammelrechnungPositionDruckDTO>();
            if (!positionen.IsNullOrEmpty())
            {
                foreach (var position in positionen)
                {
                    druckPositionen.Add(new SammelrechnungPositionDruckDTO(position));
                }
            }
            return druckPositionen.OrderBy(p => p.LaufendeNummer).ToList();
        }
    }

    public class SammelrechnungSaldoDruckDTO
    {
        public int Reihenfolge { get; set; }
        public string Text { get; set; }
        public string Betrag { get; set; }
        public string Rabatt { get; set; }
        public bool IsLastElement { get; set; }

        public SammelrechnungSaldoDruckDTO(SammelrechnungSaldenDTO saldo, bool isLastElement)
        {
            var culture = new CultureInfo("de-de");

            Reihenfolge = saldo.Reihenfolge;
            Text = saldo.Text;
            Betrag = saldo.Betrag.ToString(culture);
            Rabatt = saldo.Rabatt > 0 ? saldo.Rabatt.ToString("G29", culture) : "";
            IsLastElement = isLastElement;
        }

        public static List<SammelrechnungSaldoDruckDTO> ListFromDTOs(IList<SammelrechnungSaldenDTO> salden)
        {
            var druckSalden = new List<SammelrechnungSaldoDruckDTO>();
            if (!salden.IsNullOrEmpty())
            {
                var maxReihenfolge = salden.Max(p => p.Reihenfolge);
                foreach (var saldo in salden)
                {
                    druckSalden.Add(new SammelrechnungSaldoDruckDTO(saldo, isLastElement: saldo.Reihenfolge == maxReihenfolge));
                }
            }
            return druckSalden.OrderBy(s => s.Reihenfolge).ToList();
        }
    }
}
