using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class MaterialbedarfDTO
    {
        /// <summary>
        /// Eindeutiges Kennzeichen des Items (aus GUID)
        /// </summary>
        public Guid Kennzeichen { get; set; }
        public string InternerName { get; set; }
        /// <summary>
        /// Neher-Katalognummer des Artikels
        /// </summary>
        public string KatalogNummer { get; set; }
        /// <summary>
        /// Artikelbezeichnung
        /// </summary>
        public string Bezeichnung { get; set; }
        /// <summary>
        /// Einheit des Artikels (lfm=Laufmeter, Stk=Stück, qm=Quadratmeter)
        /// </summary>
        public string Einheit { get; set; }
        public bool Beipacken { get; set; }
        /// <summary>
        /// Laufmeter des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt 
        /// sich aus mit Stückzahl!)
        /// </summary>
        public decimal Laufmeter { get; set; }
        /// <summary>
        /// FarbBezeichnung (Bezeichnung der Farbe)
        /// </summary>
        public string FarbBezeichnung { get; set; }
        /// <summary>
        /// FarbeKuerzel (Neher-Kürzel oder Sonderfarbton)
        /// </summary>
        public string FarbKuerzel { get; set; }
        /// <summary>
        /// FarbeCode der Farbe
        /// </summary>
        public string FarbCode { get; set; }
        /// <summary>
        /// Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt 
        /// sich aus mit Laufmeter!)
        /// </summary>
        public decimal Stueckzahl { get; set; }
        /// <summary>
        /// Kennzeichen für Zuschnittartikel
        /// </summary>
        public bool IstZuschnitt { get; set; }
        public float ZuschnittLaenge { get; set; }
        public string ZuschnittWinkel { get; set; }
        public string MaterialBezeichnung { get; set; }
        public bool MaterialBearbeitungSaegen { get; set; }
        public bool MaterialBearbeitungFraesen { get; set; }
        public bool MaterialBearbeitungStanzen { get; set; }
        public bool MaterialBearbeitungBeschichten { get; set; }
        public bool MaterialBearbeitungBohren { get; set; }
        public bool MaterialBearbeitungEloxieren { get; set; }
    }
}
