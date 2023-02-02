using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung
{
    public class SammelrechnungDruckDTO
    {
        public SammelrechnungDruckDTO(/*SammelrechnungDTO sammelrechnung*/)
        {
            Salden = new List<SammelrechnungSaldoDruckDTO>();
            RechnungPositionen = new List<SammelrechnungPositionDruckDTO>();

            // TODO: Set values from DTO
            //SammelrechnungGuid;
            //SammelrechnungNummer;
            //Kunde;
            //ErstellDatum;
            //Kopfzeile;
            //Fusszeile;
            //Schlusstext;
            //PageTitle;
            //PageSubtitle1;
            //PageSubtitle2;
            //Ansprechpartner;
            //Telefonnummer;
            //Lieferzeit;
            //RechnungsAdresse;
            //RechnungsAdresseString;
            //RechnungPositionen;
            //Salden;
            //CountValuePositionen;
            //CountValueSalden;
            //IsEndkunde;
        }

        public Guid SammelrechnungGuid { get; set; }
        public long SammelrechnungNummer { get; set; }
        public KontaktDTO Kunde { get; set; }
        public DateTime ErstellDatum { get; set; }
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
    }

    public class SammelrechnungPositionDruckDTO
    {
        public int LaufendeNummer { get; set; }
        public string RechnungNummer { get; set; }
        public DateTime RechnungDatum { get; set; }
        public string RechnungKommision { get; set; }
        public string RechnungBetrag { get; set; }
        public IList<SammelrechnungSaldoDruckDTO> RechnungSalden { get; set; }
    }

    public class SammelrechnungSaldoDruckDTO
    {
        public int Reihenfolge { get; set; }
        public string Text { get; set; }
        public string Betrag { get; set; }
        public bool IsLastElement { get; set; } = false;
    }
}
