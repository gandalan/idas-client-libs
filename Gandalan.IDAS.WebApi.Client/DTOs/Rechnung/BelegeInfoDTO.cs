using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung
{
    public class BelegeInfoDTO
    {
        public Guid VorgangGuid { get; set; }
        public Guid BelegGuid { get; set; }
        public Guid KontaktGuid { get; set; }

        public string Belegart { get; set; }
        public long Vorgangsnummer { get; set; }
        public long BelegNummer { get; set; }
        public DateTime BelegDatum { get; set; }
        public int PosAnzahl { get; set; }
        public decimal GesamtBetrag { get; set; }
        public string Kundennummer { get; set; }
        public string Kundenname { get; set; }
        public string Lieferadresse { get; set; }
        public bool IstSammelrechnungsKunde { get; set; }
        public long? SammelrechnungsNummer { get; set; }
        public bool IstGedruckt { get; set; }
        public decimal MwSt { get; set; }
        public Lieferungstyp Lieferungstyp { get; set; }
    }
}
