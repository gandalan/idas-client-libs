/** @typedef {import('./ui.js').PropertyValueCollection} PropertyValueCollection */

/**
 * @typedef {Object} KontaktDTO
 * @property {string} KontaktGuid - Eindeutige GUID
 * @property {string} Nachname - Nachname (für Endkunden)
 * @property {string} Vorname - Vorname(n) (für Endkunden)
 * @property {string} Firmenname - Firmierung (für jur. Personen)
 * @property {string} KundenNummer - Kundennummer (alphanummerisch)
 * @property {Date|null} Erstkontakt - Datum des ersten Kontakts
 * @property {Date|null} LetzterKontakt - Datum des letzten Kontakts
 * @property {boolean} IstEndkunde - Endkunde oder Firmenkunde
 * @property {string} Kommentar - allg. Informationen
 * @property {boolean} IstKunde - Status Kontakt oder Interessent
 * @property {boolean} IstGesperrt - Gesperrt/Wird nicht beliefert
 * @property {boolean} IstArchiviert - Archiviert, wird nicht mehr angezeigt, restliche Abhängigkeiten bleiben unberührt
 * @property {boolean} IstSelbstabholer - Holt Ware normalerweise ab
 * @property {boolean} IstVorkasse - Kunde muss in Vorkasse gehen.
 * @property {boolean} IstUmsatzsteuerPflichtig
 * @property {boolean} InnergemeinschaftOhneMwSt - Wenn der Kontakt ein Innergemeinschaftlicher Kontakt ist, kann durch dieses Flag die MwSt. Berechnung abgeschaltet werden.
 * @property {Array<PersonDTO>} Personen - Zugeordnete Personen
 * @property {Array<ZusatzanschriftDTO>} Zusatzanschriften - Zugeordnete Standard-Adressen
 * @property {boolean} IstDummyKunde
 * @property {number} ArtikelRabattVorgabe
 * @property {number} ElementRabattVorgabe
 * @property {string} UmsatzSteuerId
 * @property {string} Branche
 * @property {string} Nummernkreis - Kunden-Nummernkreis, z.B. 600, 0000, 000
 * @property {string[]} Liefertage - Liefertage, Montag bis Freitag
 * @property {boolean} ShowSonderetikett
 * @property {string} Sonderetikett
 * @property {string} Briefanrede
 * @property {string} Titel
 * @property {string} Anrede - Namensanrede, z.B. "Herr"/"Frau"/"Firma"
 * @property {string} AdressZusatz1 - Adresszusatz, z.B. "c/o" (belegbezogen)
 * @property {string} AdressZusatz2 - Adresszusatz, z.B. "c/o" (belegbezogen)
 * @property {string} Strasse - Postalische Straße
 * @property {string} Hausnummer - Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)"
 * @property {string} Postfach - Postfach (ersetzt Straße/Hausnummer in der Ausgabe)
 * @property {string} Postleitzahl - Postalische Postleitzahl bezogen auf die Straßen- oder Postfachadresse
 * @property {string} Ort - Postalische Ortsangabe
 * @property {string} Ortsteil - Nicht-postalische Angabe zum Ortsteil
 * @property {string} Land - Land als Textkürzel
 * @property {boolean} IstInland
 * @property {string} Mailadresse - E-Mail-Adresse
 * @property {string} Landesvorwahl - Telefon: Ländervorwahl (kanonisch [+49] oder landesspezifisch [0049])
 * @property {string} Vorwahl - Ortskennzahl mit führender "0" in Deutschland
 * @property {string} Telefonnummer - Anschlussrufnummer
 * @property {string} Durchwahl - Durchwahlzusatz
 * @property {string} Webadresse - Internet-/Web-URL mit Protokoll-Präfix (https://...)
 * @property {number|null} Transportkosten - Transportkosten für den Kunden
 * @property {boolean} AbweichendeTransportkosten - Transportkosten für den Kunden
 * @property {Record<string, PropertyValueCollection>} ApplicationSpecificProperties - Intern
 * @property {Record<string, PropertyValueCollection>} AdditionalProperties - Intern
 * @property {string} KontaktMandantGuid
 * @property {boolean} KontaktMandantIstAktiv
 * @property {number} Version
 * @property {Date} ChangedDate
 * @property {number} NettoTage - Zahleneintrag für Tage
 * @property {number} Skonto - Zahleneintrag für Tage sowie Skonto in %
 * @property {string} SchlussTextAngebotAB - Freitextfeld bei Vorkasse Kunden "Hinweis auf Zahlung" (Angebot + AB)
 * @property {string} SchlussTextRechnung - Freitextfeld bei Vorkasse Kunden "Hinweis auf Zahlung" (Rechnung)
 * @property {string} Zahlungsbedingung - Freitextfeld für die Zahlungsbedingung
 * @property {boolean} HatWinterrabatt - Kunde hat Winterrabatt ja/nein
 * @property {boolean} KeineAutofreigabe
 * @property {boolean} ErbtAuswahlOhneSprosse
 * @property {boolean} DigitalerRechnungsversand
 * @property {boolean} IstSammelrechnungsKunde
 * @property {boolean} IstInaktiv - Inaktiv Kennzeichen
 * @property {string} AnzeigeName - Erzeugt einen Text aus den Namensfeldern für die Anzeige in Überschriften, Anschriftenfeldern usw.
 * @property {string} ProduktionZusatzInfo
 * @property {boolean} ProduktionZusatzInfoPrintZusatzEtikett
 * @property {boolean} ProduktionZusatzInfoPrintOnReport
 * @property {string} FremdfertigungMandantGuid
 */

/**
 * @typedef {Object} ZusatzanschriftDTO
 * @property {string} ZusatzanschriftGuid
 * @property {string} Titel - Akad. Titel/Adelstitel
 * @property {string} Anrede - Namensanrede, z.B. "Herr"/"Frau"/"Firma"
 * @property {string} Nachname - Für natürliche Personen: Nachname
 * @property {string} Vorname - Für natürliche Personen: Vorname(n)
 * @property {string} Firmenname - Für juristische Personen/Körperschaften: exakte Firmierung mit Zusatz der Gesellschaftsform, z.B. "Fensterbau Maier GmbH & Co. KG"
 * @property {string} AdressZusatz1 - Adresszusatz, z.B. "c/o" (belegbezogen)
 * @property {string} AdressZusatz2 - Adresszusatz, z.B. "c/o" (belegbezogen)
 * @property {string} Strasse - Postalische Straße
 * @property {string} Hausnummer - Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)"
 * @property {string} Postfach - Postfach (ersetzt Straße/Hausnummer in der Ausgabe)
 * @property {string} Postleitzahl - Postalische Postleitzahl bezogen auf die Straßen- oder Postfachadresse
 * @property {string} Ort - Postalische Ortsangabe
 * @property {string} Ortsteil - Nicht-postalische Angabe zum Ortsteil
 * @property {string} Land - Land als Textkürzel
 * @property {boolean} IstInland - Bezogen auf den Versender die Angabe, ob die hier ausgefertigte Adresse eine Inlandsadresse ist
 * @property {string} Mailadresse - E-Mail-Adresse
 * @property {string} Verwendungszweck - Verwendungszweck für diesen Adressdatensatz, mögliche Werte: Allgemein = 0, Angebot = 1, Rechnung = 3, Versand = 4, Bestellschein = 5, Newsletter = 6, Postversand = 7, Speditionsversand = 8, DigitalerDownload = 9, EmailDownload = 10, Firmensitz = 11
 * @property {number} Prioritaet - Priorisierung der Adresse
 * @property {Record<string, PropertyValueCollection>} ApplicationSpecificProperties - Intern
 * @property {Record<string, PropertyValueCollection>} AdditionalProperties - Intern
 * @property {boolean} IstInaktiv - Inaktiv Kennzeichen
 */

/**
 * @typedef {Object} BeleganschriftDTO
 * @property {string} AdressGuid
 * @property {string} Art - Art der Adresse - "Anschrift", "Email", "Telefon" (nur relevant bei Adressen aus IBOS)
 * @property {string} Titel - Akad. Titel/Adelstitel
 * @property {string} Anrede - Namensanrede, z.B. "Herr"/"Frau"/"Firma"
 * @property {string} Nachname - Für natürliche Personen: Nachname
 * @property {string} Vorname - Für natürliche Personen: Vorname(n)
 * @property {string} Firmenname - Für juristische Personen/Körperschaften: exakte Firmierung mit Zusatz der Gesellschaftsform, z.B. "Fensterbau Maier GmbH & Co. KG"
 * @property {string} Zusatz - Zusätzliche Information zur Firma
 * @property {string} AdressZusatz1 - Adresszusatz, z.B. "c/o" (belegbezogen)
 * @property {string} AdressZusatz2 - Adresszusatz, z.B. "c/o" (belegbezogen)
 * @property {string} Strasse - Postalische Straße
 * @property {string} Hausnummer - Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)"
 * @property {string} Postfach - Postfach (ersetzt Straße/Hausnummer in der Ausgabe)
 * @property {string} Postleitzahl - Postalische Postleitzahl bezogen auf die Straßen- oder Postfachadresse
 * @property {string} Ort - Postalische Ortsangabe
 * @property {string} Ortsteil - Nicht-postalische Angabe zum Ortsteil
 * @property {string} Land - Land als Textkürzel
 * @property {boolean} IstInland - Bezogen auf den Versender die Angabe, ob die hier ausgefertigte Adresse eine Inlandsadresse ist
 * @property {string} Mailadresse - E-Mail-Adresse
 * @property {string} Landesvorwahl - Telefon: Ländervorwahl (kanonisch [+49] oder landesspezifisch [0049])
 * @property {string} Vorwahl - Ortskennzahl mit führender "0" in Deutschland
 * @property {string} Telefonnummer - Anschlussrufnummer
 * @property {string} Durchwahl - Durchwahlzusatz
 * @property {string} Webadresse - Internet-/Web-URL mit Protokoll-Präfix (https://...)
 * @property {string} Verwendungszweck - Ursprunglicher interner Verwendungszweck für diesen Adressdatensatz (nur für Adresse aus IBOS, z.B. "Rechnung", "AB"...)
 * @property {number} Prioritaet - Priorisierung der Adresse
 * @property {Record<string, PropertyValueCollection>} ApplicationSpecificProperties - Intern
 * @property {Record<string, PropertyValueCollection>} AdditionalProperties - Intern
 * @property {string} AnzeigeName - Erzeugt einen Text aus den Namensfeldern für die Anzeige in Überschriften, Anschriftenfeldern usw.
 */

/**
 * @typedef {Object} KontaktListItemDTO
 * @property {string} KontaktGuid
 * @property {string} KontaktMandantGuid
 * @property {string} FremdfertigungMandantGuid
 * @property {boolean} KontaktMandantIstAktiv - Der KontaktMandant hat die App-Verwendung aktiv
 * @property {string} Nachname - Nachname (für Endkunden)
 * @property {string} Vorname - Vorname(n) (für Endkunden)
 * @property {string} Firmenname - Firmierung (für jur. Personen)
 * @property {string} KundenNummer - Kundennummer (alphanummerisch)
 * @property {string} Strasse - Strasse
 * @property {string} Hausnummer - Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)"
 * @property {string} Land - Land
 * @property {string} Plz - Postleitzahl
 * @property {string} Ort - Stadt / Ort
 * @property {string} Ortsteil - Ortsteil
 * @property {string} Telefon - Telefon (Zentrale)
 * @property {string} Email - E-Mail (Zentrale)
 * @property {boolean} IstEndkunde - Endkunde oder Firmenkunde
 * @property {boolean} IstKunde
 * @property {boolean} IstGesperrt - Kunde gesperrt?
 * @property {boolean} IstArchiviert - Archivierte Kontakte werden nicht angezeigt
 * @property {string} URL
 * @property {Date} ChangedDate
 * @property {Record<string, PropertyValueCollection>} ApplicationSpecificProperties
 * @property {Record<string, PropertyValueCollection>} AdditionalProperties
 */

/**
 * @typedef {Object} PersonDTO
 * @property {string} PersonGuid - Eindeutige GUID
 * @property {string} Nachname - Nachname der Person
 * @property {string} Vorname - Vorname/Rufname der Person
 * @property {string} WeitereVornamen - evtl. weitere Vornamen
 * @property {Date|null} Geburtstag - Geburtstag
 * @property {string} Briefanrede
 * @property {string} Anrede
 * @property {string} Mailadresse
 * @property {string} Telefonnummer
 * @property {string} MobileTelefonnummer
 * @property {Record<string, PropertyValueCollection>} ApplicationSpecificProperties
 * @property {Record<string, PropertyValueCollection>} AdditionalProperties
 * @property {boolean} IstInaktiv - Inaktiv Kennzeichen
 */

/**
 * @typedef {Object} AdresseDTO
 * @property {string} AdressGuid
 * @property {string} Titel - Akad. Titel/Adelstitel
 * @property {string} Anrede - Namensanrede, z.B. "Herr"/"Frau"/"Firma"
 * @property {string} Nachname - Für natürliche Personen: Nachname
 * @property {string} Vorname - Für natürliche Personen: Vorname(n)
 * @property {string} Firmenname - Für juristische Personen/Körperschaften: exakte Firmierung mit Zusatz der Gesellschaftsform, z.B. "Fensterbau Maier GmbH & Co. KG"
 * @property {string} AdressZusatz1 - Adresszusatz, z.B. "c/o" (belegbezogen)
 * @property {string} AdressZusatz2 - Adresszusatz, z.B. "c/o" (belegbezogen)
 * @property {string} Strasse - Postalische Straße
 * @property {string} Hausnummer - Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)"
 * @property {string} Postfach - Postfach (ersetzt Straße/Hausnummer in der Ausgabe)
 * @property {string} Postleitzahl - Postalische Postleitzahl bezogen auf die Straßen- oder Postfachadresse
 * @property {string} Ort - Postalische Ortsangabe
 * @property {string} Ortsteil - Nicht-postalische Angabe zum Ortsteil
 * @property {string} Land - Land als Textkürzel
 * @property {boolean} IstInland - Bezogen auf den Versender die Angabe, ob die hier ausgefertigte Adresse eine Inlandsadresse ist
 * @property {string} Mailadresse - E-Mail-Adresse
 * @property {string} Landesvorwahl - Telefon: Ländervorwahl (kanonisch [+49] oder landesspezifisch [0049])
 * @property {string} Vorwahl - Ortskennzahl mit führender "0" in Deutschland
 * @property {string} Telefonnummer - Anschlussrufnummer
 * @property {string} Durchwahl - Durchwahlzusatz
 * @property {string} Webadresse - Internet-/Web-URL mit Protokoll-Präfix (https://...)
 * @property {string} Verwendungszweck - Ursprunglicher interner Verwendungszweck für diesen Adressdatensatz (nur für Adresse aus IBOS, z.B. "Rechnung", "AB"...)
 * @property {Record<string, PropertyValueCollection>} ApplicationSpecificProperties - Intern
 * @property {Record<string, PropertyValueCollection>} AdditionalProperties
 */

/**
 * @typedef {Object} AppActivationStatusDTO
 * @property {string} KundeGuid
 * @property {string} KundenMandantGuid
 * @property {boolean} KundenMandantIstAktiv
 */

export {};
