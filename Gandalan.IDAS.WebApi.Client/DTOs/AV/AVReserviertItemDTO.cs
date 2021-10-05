using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Data.DTOs.AV
{
    public class AVReserviertItemDTO
    {
        public string Variante { get; set; }
        public int Menge { get; set; }
        public string Kommission { get; set; }
        public string Kunde { get; set; }
        public long VorgangsNummer { get; set; }
        public Guid VorgangGuid { get; set; }
        public long BelegNummer { get; set; }

    }
}
