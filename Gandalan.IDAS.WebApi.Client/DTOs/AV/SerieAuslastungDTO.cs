using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class SerieAuslastungDTO
    {
        public SerieAuslastungDTO()
        {
        }

        public SerieAuslastungDTO(VirtualSerieWithAuslastungDTO dto)
        {
            Produktfamilie = "Summe:";
            IstSumme = true;
            foreach (var vAuslastung in dto.Auslastungen)
            {
                Anzahl += vAuslastung.Anzahl;
                Reserviert += vAuslastung.Reserviert;
                Arbeitsminuten += vAuslastung.Arbeitsminuten;
                ArbeitsminutenReserviert += vAuslastung.ArbeitsminutenReserviert;
                Elementgewicht += vAuslastung.Elementgewicht;
                ElementgewichtReserviert += vAuslastung.ElementgewichtReserviert;
                Rahmenanzahl += vAuslastung.Rahmenanzahl;
                RahmenanzahlReserviert += vAuslastung.RahmenanzahlReserviert;
                AnzahlMax += vAuslastung.AnzahlMax;
                KapazitaetBelegt += vAuslastung.KapazitaetBelegt;
                KapazitaetMax += vAuslastung.KapazitaetMax;
            }
        }

        public SerieAuslastungDTO(IList<SerieAuslastungDTO> value)
        {
            Produktfamilie = "Summe:";
            IstSumme = true;
            foreach (var vAuslastung in value)
            {
                Anzahl += vAuslastung.Anzahl;
                Reserviert += vAuslastung.Reserviert;
                Arbeitsminuten += vAuslastung.Arbeitsminuten;
                ArbeitsminutenReserviert += vAuslastung.ArbeitsminutenReserviert;
                Elementgewicht += vAuslastung.Elementgewicht;
                ElementgewichtReserviert += vAuslastung.ElementgewichtReserviert;
                Rahmenanzahl += vAuslastung.Rahmenanzahl;
                RahmenanzahlReserviert += vAuslastung.RahmenanzahlReserviert;
                AnzahlMax += vAuslastung.AnzahlMax;
                KapazitaetBelegt += vAuslastung.KapazitaetBelegt;
                KapazitaetMax += vAuslastung.KapazitaetMax;
            }
        }

        public bool IstSumme { get; set; }
        public string Produktfamilie { get; set; }
        public int Anzahl { get; set; }
        public int Reserviert { get; set; }
        public decimal Arbeitsminuten { get; set; }
        public decimal ArbeitsminutenReserviert { get; set; }
        public decimal Elementgewicht { get; set; }
        public decimal ElementgewichtReserviert { get; set; }
        public int Rahmenanzahl { get; set; }
        public int RahmenanzahlReserviert { get; set; }
        public int AnzahlMax { get; set; }
        public decimal KapazitaetBelegt { get; set; }
        public decimal KapazitaetMax { get; set; }
    }
}
