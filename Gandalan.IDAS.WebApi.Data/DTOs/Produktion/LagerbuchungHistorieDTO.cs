using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für die Lagerbuchungshistorie
    /// </summary>
    public class LagerbuchungHistorieDTO
    {
        public Guid LagerbestandGuid { get; set; }
        public Guid KatalogArtikelGuid { get; set; }
        public Guid FarbGuid { get; set; }
        public decimal MengeBestand { get; set; }
        public decimal MengeReservierung { get; set; }
        public decimal MengeMindestbestand { get; set; }
        public decimal MengeEisernerBestand { get; set; }
        public decimal MengeMaximalbestand { get; set; }
        public string Einheit { get; set; }
        public string User { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}