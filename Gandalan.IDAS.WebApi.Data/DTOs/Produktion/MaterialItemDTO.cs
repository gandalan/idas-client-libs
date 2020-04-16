using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// Die MaterialItems sind die, die später als Job bei den Providern bestellt werden. Diese werden aus dem MaterialBedarfDTO generiert und können vom Benutzer angepasst werden.
    /// Diese Items werden zur Nachvollziehbarkeit des Statuses und verbindung vom Job zur Position in der Datenbank persisitiert.
    /// </summary>
    public class MaterialItemDTO
    {
        /// <summary>
        /// Eindeutige ID dieses Items
        /// </summary>
        public Guid MaterialItemGuid { get; set; }
        /// <summary>
        /// Eindeutige ID des erstelten Jobs
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
        public decimal ZuschnittLaenge { get; set; }
        /// <summary>
        /// Zuschnittwinkel des Artikels, falls erforderlich
        /// </summary>
        public string ZuschnittWinkel { get; set; }
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
        /// FarbeKuerzel (Neher-Kürzel oder Sonderfarbton)
        /// </summary>
        public string FarbKuerzel { get; set; }
    }
}
