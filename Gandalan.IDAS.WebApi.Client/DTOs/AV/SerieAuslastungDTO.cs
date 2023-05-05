namespace Gandalan.IDAS.WebApi.DTO
{
    public class SerieAuslastungDTO
    {
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
