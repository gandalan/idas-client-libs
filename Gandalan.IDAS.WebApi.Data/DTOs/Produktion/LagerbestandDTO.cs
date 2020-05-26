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
        public Guid Guid { get; set; }
        public Guid KatalogArtikelGuid { get; set; }

        public string KatalogNummer { get; set; }

        public Guid FarbeGuid { get; set; }

        public string FarbKuerzel { get; set; }
        public decimal Lagerbestand { get; set; }

        public decimal Mindestbestand { get; set; }

        [JsonIgnore]
        public decimal Reserviert
        {
            get
            {
                if (Einheit == "lfm")
                {
                    return Math.Ceiling(MaterialBeschaffungsJobs.Sum(x => x.Stueckzahl * x.ZuschnittLaenge * decimal.Parse("1.1") / 1000));
                }
                else
                {
                    return MaterialBeschaffungsJobs.Sum(x => x.Stueckzahl);
                }
            }
        }

        public decimal Maximalbestand { get; set; }

        public string Einheit { get; set; }

        public DateTime ChangedDate { get; set; }

        public IList<MaterialBeschaffungsJobDTO> MaterialBeschaffungsJobs { get; set; } = new List<MaterialBeschaffungsJobDTO>();
    }
}
