using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BearbeitungDTO
    {
        /// <summary>
        /// Eindeutiges Kennzeichen der Bearbeitung (aus GUID)
        /// </summary>
        public string Kennzeichen { get; set; }
        /// <summary>
        /// Ziel der Bearbeitung
        /// </summary>
        public Guid ZielKennzeichen { get; set; }
        /// <summary>
        /// Artikelbezeichnung
        /// </summary>
        public string BearbeitungsName { get; set; }                
        /// <summary>
        /// Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt 
        /// sich aus mit Laufmeter!)
        /// </summary>
        public decimal X { get; set; }
        /// <summary>
        /// Laufmeter des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt 
        /// sich aus mit Stückzahl!)
        /// </summary>
        public decimal Y { get; set; }
        public string ProfilName { get; set; }
        public decimal ProfilLaenge { get; set; }
        public decimal ProfilBreite { get; set; }
        public string KatalogNummer { get; set; }
    }
}
