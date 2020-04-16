using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// Jobinformation zur Materialbeschaffung
    /// </summary>
    public class MaterialBeschaffungsJobDTO
    {
        /// <summary>
        /// Eindeutige ID des Jobs
        /// </summary>
        public Guid MaterialBeschaffungsJobGuid { get; set; }
        /// <summary>
        /// Besitzer (IMaterialBeschaffungService-Name) des Vorgangs
        /// </summary>
        public string Besitzer { get; set; }
        /// <summary>
        /// Original-BelegPositionGuid
        /// </summary>
        public Guid BelegPositionGuid { get; set; }
        /// <summary>
        /// Original-BelegsGuid
        /// </summary>
        public Guid BelegGuid { get; set; }
        /// <summary>
        /// PCode (Produktionscode) für das zugehörige Fertigelement
        /// </summary>
        public string PCode { get; set; }
        /// <summary>
        /// Original-VorgangGuid
        /// </summary>
        public Guid VorgangGuid { get; set; }
        /// <summary>
        /// Erstellzeitstempel des Jobs
        /// </summary>
        public DateTime Erstellt { get; set; }
        /// <summary>
        /// Anwender, der den Job erstellt hat
        /// </summary>
        public string Ersteller { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public MaterialBeschaffungsJobStatiDTO AktuellerStatus { get; set; }
        /// <summary>
        /// Neher-Katalognummer (ohne Farbangabe!)
        /// </summary>
        public string KatalogNummer { get; set; }
        /// <summary>
        /// Info zum Original-Vorgangs
        /// </summary>
        public string VorgangNummer { get; set; }
        /// <summary>
        /// Info zur Original-Kommission
        /// </summary>
        public string Kommission { get; set; }
        /// <summary>
        /// Bezeichnung des Artikels
        /// </summary>
        public string Bezeichnung { get; set; }
        /// <summary>
        /// Kennzeichen des Artikels in der Original-Materialliste
        /// </summary>
        public Guid Kennzeichen { get; set; }
        /// <summary>
        /// Internetr Name des Artikels in der Original-Materialliste
        /// </summary>
        public string InternerName { get; set; }
        /// <summary>
        /// Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt 
        /// sich aus mit Laufmeter!)
        /// </summary>
        public decimal Stueckzahl { get; set; }
        /// <summary>
        /// Zuschnittlänge des Artikels, falls erforderlich
        /// </summary>
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
        /// <summary>
        /// Historie des Jobs
        /// </summary>
        public List<MaterialBeschaffungsJobHistorieDTO> Historie { get; set; } = new List<MaterialBeschaffungsJobHistorieDTO>();
    }
}
