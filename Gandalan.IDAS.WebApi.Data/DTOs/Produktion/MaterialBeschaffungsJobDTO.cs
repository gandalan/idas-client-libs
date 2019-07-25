using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class MaterialBeschaffungsJobDTO
    {
        public Guid MaterialBeschaffungsJobGuid { get; set; }
        public Guid BelegPositionGuid { get; set; }
        public DateTime Erstellt { get; set; }
        public string Ersteller { get; set; }

        public MaterialBeschaffungsJobStatiDTO AktuellerStatus { get; set; }

        public string KatalogNummer { get; set; }
        public string Bezeichnung { get; set; }
        public Guid Kennzeichen { get; set; }
        public string InternerName { get; set; }

        /// <summary>
        /// Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt 
        /// sich aus mit Laufmeter!)
        /// </summary>
        public decimal Stueckzahl { get; set; }
        public decimal Laenge { get; set; }

        /// <summary>
        /// Handelsbezeichnung, zB "verkehrsweiss"
        /// </summary>
        public string FarbBezeichnung { get; set; } 
        /// <summary>
        /// Skalenfarbcode, z.B. "RAL 9016"
        /// </summary>
        public string FarbCode { get; set; }
        /// <summary>
        /// Bezeichnung der Oberfläche, z.B. "matt"
        /// </summary>
        public string OberflaechenBezeichnung { get; set; }
        /// <summary>
        /// Wenn bekannt/vorhanden, die Pulvernummer beim Beschichter
        /// </summary>
        public string PulverNummer { get; set; }
        
        public List<MaterialBeschaffungsJobHistorieDTO> Historie { get; set; } = new List<MaterialBeschaffungsJobHistorieDTO>();
    }
}
