using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Gandalan.IDAS.WebApi.Util;

namespace Gandalan.IDAS.WebApi.DTO;

public class KontaktDTO : IDTOWithApplicationSpecificProperties, IDTOWithAdditionalProperties, INotifyPropertyChanged
{
    /// <summary>
    /// Eindeutige GUID
    /// </summary>
    public Guid KontaktGuid { get; set; }

    /// <summary>
    /// Nachname (für Endkunden)
    /// </summary>
    public string Nachname { get; set; }

    /// <summary>
    /// Vorname(n) (für Endkunden)
    /// </summary>
    public string Vorname { get; set; }

    /// <summary>
    /// Firmierung (für jur. Personen)
    /// </summary>
    public string Firmenname { get; set; }

    /// <summary>
    /// Kundennummer (alphanummerisch)
    /// </summary>
    public string KundenNummer { get; set; }

    /// <summary>
    /// Datum des ersten Kontakts
    /// </summary>
    public DateTime? Erstkontakt { get; set; }

    /// <summary>
    /// Datum des letzten Kontakts
    /// </summary>
    public DateTime? LetzterKontakt { get; set; }

    /// <summary>
    /// Endkunde oder Firmenkunde
    /// </summary>
    public bool IstEndkunde { get; set; }

    /// <summary>
    /// allg. Informationen
    /// </summary>
    public string Kommentar { get; set; }

    /// <summary>
    /// Status Kontakt oder Interessent
    /// </summary>
    public bool IstKunde { get; set; }

    /// <summary>
    /// Gesperrt/Wird nicht beliefert
    /// </summary>
    public bool IstGesperrt { get; set; }

    /// <summary>
    /// Archiviert, wird nicht mehr angezeigt, restliche Abhängigkeiten bleiben unberührt
    /// </summary>
    public bool IstArchiviert { get; set; }

    /// <summary>
    /// Holt Ware normalerweise ab
    /// </summary>
    public bool IstSelbstabholer { get; set; }

    /// <summary>
    /// Kunde muss in Vorkasse gehen.
    /// </summary>
    public bool IstVorkasse { get; set; }

    public bool IstUmsatzsteuerPflichtig { get; set; } = true;

    /// <summary>
    /// Wenn der Kontakt ein Innergemeinschaftlicher Kontakt ist, kann durch dieses Flag ide MwSt. Berechnung abgeschaltet werden.
    /// </summary>
    public bool InnergemeinschaftOhneMwSt { get; set; }

    /// <summary>
    /// Zugeordnete Personen
    /// </summary>
    public virtual IList<PersonDTO> Personen { get; set; }

    /// <summary>
    /// Zugeordnete Standard-Adressen
    /// </summary>
    public virtual IList<ZusatzanschriftDTO> Zusatzanschriften { get; set; }

    public bool IstDummyKunde { get; set; }
    public decimal ArtikelRabattVorgabe { get; set; }
    public decimal ElementRabattVorgabe { get; set; }
    public string UmsatzSteuerId { get; set; }
    public string Branche { get; set; }

    // Disposition

    /// <summary>
    /// Kunden-Nummernkreis, z.B. 600, 0000, 000
    /// </summary>
    public string Nummernkreis { get; set; }

    /// <summary>
    /// Liefertage, Montag bis Freitag
    /// </summary>
    public string[] Liefertage { get; set; }

    public bool ShowSonderetikett { get; set; }
    public string Sonderetikett { get; set; }
    public string Briefanrede { get; set; }
    public string Titel { get; set; }

    /// <summary>
    /// Namensanrede, z.B. "Herr"/"Frau"/"Firma"
    /// </summary>
    public string Anrede { get; set; }

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
    /// Transportkosten für den Kunden
    /// </summary>
    public decimal? Transportkosten { get; set; }

    /// <summary>
    /// Transportkosten für den Kunden
    /// </summary>
    public bool AbweichendeTransportkosten { get; set; }

    /// <summary>
    /// Intern
    /// </summary>
    public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }
    public Dictionary<string, PropertyValueCollection> AdditionalProperties { get; set; }

    public Guid KontaktMandantGuid { get; set; }
    public bool KontaktMandantIstAktiv { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }

    /// <summary>
    /// Zahleneintrag für Tage
    /// </summary>
    public int NettoTage { get; set; }

    /// <summary>
    /// Zahleneintrag für Tage sowie Skonto in %
    /// </summary>
    public decimal Skonto { get; set; }

    /// <summary>
    /// Freitextfeld bei Vorkasse Kunden "Hinweis auf Zahlung" (Angebot + AB)
    /// </summary>
    public string SchlussTextAngebotAB { get; set; }

    /// <summary>
    /// Freitextfeld bei Vorkasse Kunden "Hinweis auf Zahlung" (Rechnung)
    /// </summary>
    public string SchlussTextRechnung { get; set; }

    /// <summary>
    /// Freitextfeld für die Zahlungsbedingung
    /// </summary>
    public string Zahlungsbedingung { get; set; }

    /// <summary>
    /// Kunde hat Winterrabatt ja/nein
    /// </summary>
    public bool HatWinterrabatt { get; set; }

    public bool KeineAutofreigabe { get; set; }
    public bool ErbtAuswahlOhneSprosse { get; set; }
    public bool DigitalerRechnungsversand { get; set; }
    public bool IstSammelrechnungsKunde { get; set; }

    /// <summary>
    /// Inaktiv Kennzeichen
    /// </summary>
    public bool IstInaktiv { get; set; }

    /// <summary>
    /// Erzeugt einen Text aus den Namensfeldern für die Anzeige in
    /// Überschriften, Anschriftenfeldern usw.
    /// </summary>
    public string AnzeigeName => string.IsNullOrEmpty(Firmenname)
        ? $"{Anrede} {Titel} {Vorname} {Nachname}".Trim()
        : Firmenname;

    public string ProduktionZusatzInfo { get; set; }
    public bool ProduktionZusatzInfoPrintZusatzEtikett { get; set; }
    public bool ProduktionZusatzInfoPrintOnReport { get; set; }
    public Guid FremdfertigungMandantGuid { get; set; }

    public KontaktDTO()
    {
        Zusatzanschriften = [];
        Personen = [];
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public override string ToString()
    {
        return AnzeigeName;
    }

    public BeleganschriftDTO GetRechnungsadresse()
    {
        var rechnungsAdresse = new BeleganschriftDTO
        {
            AdressGuid = Guid.NewGuid(),
        };
        var rechnungsanschrift = Zusatzanschriften?.FirstOrDefault(z => z.Verwendungszweck == "Rechnung" && !string.IsNullOrWhiteSpace(z.ToString()));
        if (rechnungsanschrift != null)
        {
            rechnungsAdresse.Nachname = rechnungsanschrift.Nachname;
            rechnungsAdresse.Vorname = rechnungsanschrift.Vorname;
            rechnungsAdresse.Firmenname = rechnungsanschrift.Firmenname;
            rechnungsAdresse.Hausnummer = rechnungsanschrift.Hausnummer;
            rechnungsAdresse.Strasse = rechnungsanschrift.Strasse;
            rechnungsAdresse.Titel = rechnungsanschrift.Titel;
            rechnungsAdresse.Anrede = rechnungsanschrift.Anrede;
            rechnungsAdresse.AdressZusatz1 = rechnungsanschrift.AdressZusatz1;
            rechnungsAdresse.AdressZusatz2 = rechnungsanschrift.AdressZusatz2;
            rechnungsAdresse.Ortsteil = rechnungsanschrift.Ortsteil;
            rechnungsAdresse.Postfach = rechnungsanschrift.Postfach;
            rechnungsAdresse.Postleitzahl = rechnungsanschrift.Postleitzahl;
            rechnungsAdresse.Ort = rechnungsanschrift.Ort;
            rechnungsAdresse.Land = rechnungsanschrift.Land;
            rechnungsAdresse.IstInland = rechnungsanschrift.IstInland;
        }
        else
        {
            rechnungsAdresse.Nachname = Nachname;
            rechnungsAdresse.Vorname = Vorname;
            rechnungsAdresse.Firmenname = Firmenname;
            rechnungsAdresse.Hausnummer = Hausnummer;
            rechnungsAdresse.Strasse = Strasse;
            rechnungsAdresse.Titel = Titel;
            rechnungsAdresse.Anrede = Anrede;
            rechnungsAdresse.AdressZusatz1 = AdressZusatz1;
            rechnungsAdresse.AdressZusatz2 = AdressZusatz2;
            rechnungsAdresse.Ortsteil = Ortsteil;
            rechnungsAdresse.Postfach = Postfach;
            rechnungsAdresse.Postleitzahl = Postleitzahl;
            rechnungsAdresse.Ort = Ort;
            rechnungsAdresse.Land = Land;
            rechnungsAdresse.IstInland = IstInland;
        }

        return rechnungsAdresse;
    }
}
