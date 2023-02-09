using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung
{
    public class SammelrechnungDTO
    {
        public SammelrechnungDTO()
        {
            Positionen = new List<SammelrechnungPositionenDTO>();
            Salden = new List<SammelrechnungSaldenDTO>();
        }

        public Guid SammelrechnungGuid { get; set; }
        public long SammelrechnungsNummer { get; set; }
        public DateTime ErstellDatum { get; set; }
        public string Ansprechpartner { get; set; }
        public string Telefonnummer { get; set; }
        public string Liefertermin { get; set; }
        public string ZahlungsBedingungen { get; set; }
        public string Kopfzeile { get; set; }
        public string Fusszeile { get; set; }
        public string Schlusstext { get; set; }
        public string PageTitle { get; set; }
        public string PageSubtitle1 { get; set; }
        public string PageSubtitle2 { get; set; }
        public KontaktDTO Kontakt { get; set; }
        public BeleganschriftDTO RechnungsAdresse { get; set; }
        public IList<SammelrechnungPositionenDTO> Positionen { get; set; }
        public IList<SammelrechnungSaldenDTO> Salden { get; set; }
    }

    public class SammelrechnungPositionenDTO
    {
        public SammelrechnungPositionenDTO()
        {
            Salden = new List<SammelrechnungSaldenDTO>();
        }

        public Guid SammelrechnungPositionGuid { get; set; }
        public int LaufendeNummer { get; set; }
        public long RechnungNummer { get; set; }
        public DateTime RechnungDatum { get; set; }
        public string RechnungKommision { get; set; }
        public decimal RechnungBetrag { get; set; }

        public IList<SammelrechnungSaldenDTO> Salden { get; set; }
    }

    public class SammelrechnungSaldenDTO
    {
        public Guid SammelrechnungSaldenGuid { get; set; }
        public int Reihenfolge { get; set; }
        public string Text { get; set; }
        public decimal Betrag { get; set; }
    }
}
