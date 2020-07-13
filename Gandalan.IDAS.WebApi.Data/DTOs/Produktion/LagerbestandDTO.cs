using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für die Lagerverwaltung
    /// </summary>
    public class LagerbestandDTO
    {
        public Guid LagerbestandGuid { get; set; }
        public Guid KatalogArtikelGuid { get; set; }

        public string KatalogNummer { get; set; }

        public Guid FarbGuid { get; set; }

        public string FarbKuerzel { get; set; }
        public decimal Lagerbestand { get; set; }

        public decimal Mindestbestand { get; set; }

        public decimal Reserviert { get; set; }

        public decimal Maximalbestand { get; set; }
        public decimal EisernerBestand { get; set; }

        public string Einheit { get; set; }

        public DateTime ChangedDate { get; set; }
    }
}
