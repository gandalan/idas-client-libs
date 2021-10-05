using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Produktion
{
    public class LieferzusageDTO
    {
        public Guid LieferzusageGuid { get; set; }
        public Guid MaterialBedarfGuid { get; set; }
        public decimal Stueckzahl { get; set; }
        public decimal Laufmeter { get; set; }
        public string Lieferant { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
