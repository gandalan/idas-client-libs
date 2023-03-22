namespace Gandalan.IDAS.WebApi.DTO
{
    public class SerieAuslastungDTO
    {
        public string Produktfamilie { get; set; }
        public int Anzahl { get; set; }
        public int AnzahlMax { get; set; }
        public decimal KapazitaetBelegt { get; set; }
        public decimal KapazitaetMax { get; set; }
    }
}
