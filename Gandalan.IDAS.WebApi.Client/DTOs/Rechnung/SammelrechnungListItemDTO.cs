using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung
{
    public class SammelrechnungListItemDTO
    {
        public Guid SammelrechnungGuid { get; set; }
        public long SammelrechnungNummer { get; set; }
        public string Kundenname { get; set; }
        public string Kundennummer { get; set; }
        public DateTime ErstellDatum { get; set; }
        public int AnzahlPositionen { get; set; }
        public decimal GesamtBetrag { get; set; }
        public Guid KundenGuid { get; set; }
    }
}
