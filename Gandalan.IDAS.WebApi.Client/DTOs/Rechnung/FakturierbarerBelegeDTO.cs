using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung
{
    public class FakturierbarerBelegeDTO
    {
        public Guid VorgangGuid { get; set; }
        public Guid BelegGuid { get; set; }
        public Guid KontaktGuid { get; set; }

        public long Vorgangsnummer { get; set; }
        public int PosAnzahl { get; set; }
        public double GesamtBetrag { get; set; }
        public string Kundennummer { get; set; }
        public string Kundenname { get; set; }

    }
}
