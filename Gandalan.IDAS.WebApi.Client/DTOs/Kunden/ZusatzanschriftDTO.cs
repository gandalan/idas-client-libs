using System.ComponentModel;
using System.Collections.Generic;
using System;
using Gandalan.IDAS.WebApi.Util;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ZusatzanschriftDTO : IDTOWithApplicationSpecificProperties, INotifyPropertyChanged
    {
        public Guid ZusatzanschriftGuid { get; set; }
        /// <summary>
        /// Akad. Titel/Adelstitel
        /// </summary>
        public string Titel { get; set; }
        /// <summary>
        /// Namensanrede, z.B. "Herr"/"Frau"/"Firma"
        /// </summary>
        public string Anrede { get; set; }
        /// <summary>
        /// Für natürliche Personen: Nachname
        /// </summary>
        public string Nachname { get; set; }
        /// <summary>
        /// Für natürliche Personen: Vorname(n)
        /// </summary>
        public string Vorname { get; set; }
        /// <summary>
        /// Für juristische Personen/Körperschaften: exakte Firmierung mit Zusatz der Gesellschaftsform, z.B. "Fensterbau Maier GmbH &amp; Co. KG"
        /// </summary>
        public string Firmenname { get; set; }
        /// <summary>
        /// Adresszusatz, z.B. "c/o" (belegbezogen)
        /// </summary>
        public string AdressZusatz1 { get; set; }
        /// <summary>
        /// Adresszusatz, z.B. "c/o" (belegbezogen)
        /// </summary>
        public string AdressZusatz2 { get; set; }
        /// <summary>
        /// Postalische Straße
        /// </summary>
        public string Strasse { get; set; }
        /// <summary>
        /// Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)"
        /// </summary>
        public string Hausnummer { get; set; }
        /// <summary>
        /// Postfach (ersetzt Straße/Hausnummer in der Ausgabe)
        /// </summary>
        public string Postfach { get; set; }
        /// <summary>
        /// Postalische Postleitzahl bezogen auf die Straßen- oder Postfachadresse
        /// </summary>
        public string Postleitzahl { get; set; }
        /// <summary>
        /// Postalische Ortsangabe
        /// </summary>
        public string Ort { get; set; }
        /// <summary>
        /// Nicht-postalische Angabe zum Ortsteil
        /// </summary>
        public string Ortsteil { get; set; }
        /// <summary>
        /// Land als Textkürzel
        /// </summary>
        public string Land { get; set; }
        /// <summary>
        /// E-Mail-Adresse
        /// </summary>
        public string Mailadresse { get; set; }
        /// <summary>
        /// Verwendungszweck für diesen Adressdatensatz , mögliche Werte: Allgemein = 0, Angebot = 1,
        /// Rechnung = 3, Versand = 4, Bestellschein = 5, Newsletter = 6, Postversand = 7, Speditionsversand = 8,
        /// DigitalerDownload = 9, EmailDownload = 10, Firmensitz = 11
        /// </summary>
        public string Verwendungszweck { get; set; }
        /// <summary>
        /// Priorisierung der Adresse
        /// </summary>
        public int Prioritaet { get; set; }
        /// <summary>
        /// Intern
        /// </summary>
        public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }

        public ZusatzanschriftDTO()
        {
            ApplicationSpecificProperties = new Dictionary<string, PropertyValueCollection>();
            ZusatzanschriftGuid = Guid.NewGuid();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string GetText()
        {
            return $"{Firmenname} {Vorname} {Nachname}".Trim();
        }

        public override string ToString()
        {
            return $"{GetText()}\r\n{Strasse} {Hausnummer}\r\n{Postleitzahl} {Ort}\r\n{Land}".Trim();
        }
    }
}