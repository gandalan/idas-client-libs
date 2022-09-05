using System.ComponentModel;
using System.Collections.Generic;
using System;
using Gandalan.IDAS.WebApi.Util;
using System.Text;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BeleganschriftDTO : IDTOWithApplicationSpecificProperties, INotifyPropertyChanged
    {
        public Guid AdressGuid { get; set; }
        /// <summary>
        /// Art der Adresse - "Anschrift", "Email", "Telefon" (nur relevant bei Adressen aus IBOS)
        /// </summary>
        public string Art { get; set; }
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
        /// Zusätzliche Information zur Firma
        /// </summary>
        public string Zusatz { get; set; }        
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
        /// Bezogen auf den Versender die Angabe, ob die hier ausgefertigte Adresse eine Inlandsadresse ist
        /// </summary>
        public bool IstInland { get; set; }
        /// <summary>
        /// E-Mail-Adresse
        /// </summary>
        public string Mailadresse { get; set; }
        /// <summary>
        /// Telefon: Ländervorwahl (kanonisch [+49] oder landesspezifisch [0049])
        /// </summary>
        public string Landesvorwahl { get; set; }
        /// <summary>
        /// Ortskennzahl mit führender "0" in Deutschland
        /// </summary>
        public string Vorwahl { get; set; }
        /// <summary>
        /// Anschlussrufnummer
        /// </summary>
        public string Telefonnummer { get; set; }
        /// <summary>
        /// Durchwahlzusatz
        /// </summary>
        public string Durchwahl { get; set; }
        /// <summary>
        /// Internet-/Web-URL mit Protokoll-Präfix (https://...)
        /// </summary>
        public string Webadresse { get; set; }
        /// <summary>
        /// Ursprunglicher interner Verwendungszweck für diesen Adressdatensatz (nur für Adresse aus IBOS, z.B. "Rechnung", "AB"...)
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

        public BeleganschriftDTO()
        {
            ApplicationSpecificProperties = new Dictionary<string, PropertyValueCollection>();
            Art = "BelegAdresse";
            AdressGuid = Guid.NewGuid();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string GetText()
        {
            return AnzeigeName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(Anrede))
                sb.AppendLine(Anrede);
            if (!string.IsNullOrEmpty(Firmenname))
                sb.AppendLine(Firmenname);
            if (!string.IsNullOrEmpty(Titel) || !string.IsNullOrEmpty(Vorname) || !string.IsNullOrEmpty(Nachname))
                sb.AppendLine($"{Titel} {Vorname} {Nachname}".Trim());
            if (!string.IsNullOrEmpty(AdressZusatz1))
                sb.AppendLine(AdressZusatz1);
            if (!string.IsNullOrEmpty(AdressZusatz2))
                sb.AppendLine(AdressZusatz2);
            if (!string.IsNullOrEmpty(Ortsteil))
                sb.AppendLine("OT " + Ortsteil);
            if (!string.IsNullOrEmpty(Strasse) || !string.IsNullOrEmpty(Hausnummer))
                sb.AppendLine($"{Strasse} {Hausnummer}".Trim());
            if (!string.IsNullOrEmpty(Land) || !string.IsNullOrEmpty(Postleitzahl) || !string.IsNullOrEmpty(Ort))
                sb.AppendLine($"{Land} {Postleitzahl} {Ort}".Trim());

            return sb.ToString();

            //var text = string.IsNullOrEmpty(Firmenname) ? $"{Titel} {Vorname} {Nachname}".Trim() : Firmenname;
            //var zusatz = !string.IsNullOrEmpty(Zusatz) ? $"{Zusatz}\r\n" : "";
            //return $"{Anrede}\r\n{text}\r\n{zusatz}{Strasse} {Hausnummer}\r\n{Postleitzahl} {Ort}\r\n{Land}".Trim();
        }

        /// <summary>
        /// Erzeugt einen Text aus den Namensfeldern für die Anzeige in 
        /// Überschriften, Anschriftenfeldern usw. 
        /// </summary>
        public string AnzeigeName
        {
            get
            {
                return string.IsNullOrEmpty(Firmenname) ? $"{Anrede} {Titel} {Vorname} {Nachname}".Trim() : Firmenname;
            }
        }
    }
}