/**
 * @fileoverview JSDoc type definitions for Farben (Color) DTOs from Gandalan.IDAS.WebApi.Client
 * Auto-generated from C# DTO files in Gandalan.IDAS.WebApi.Client/DTOs/Farben/
 */

/**
 * @typedef {Object} FarbeDTO
 * @property {string} FarbItemGuid - Eindeutige GUID der Farbe
 * @property {string} Bezeichnung - Bezeichnung der Farbe
 * @property {string} BildDateiname - Dateiname des Farbbildes
 * @property {string} FarbCode - Farbcode
 * @property {string} Farbe - Farbwert
 * @property {string} ChangedDate - ISO date string
 * @property {number} Version - Versionsnummer
 * @property {string | null} GueltigAb - ISO date string
 * @property {string | null} GueltigBis - ISO date string
 */

/**
 * @typedef {Object} FarbGruppeDTO
 * @property {string} Bezeichnung - Bezeichnung der Farbgruppe
 * @property {string} AnzeigeName - Anzeigename der Farbgruppe
 * @property {string} FarbItemGroupGuid - Eindeutige GUID der Farbgruppe
 * @property {string | null} GueltigAb - ISO date string
 * @property {string | null} GueltigBis - ISO date string
 * @property {number} Version - Versionsnummer
 * @property {string} ChangedDate - ISO date string
 * @property {number} Reihenfolge - Reihenfolge der Anzeige
 * @property {boolean} IstGesperrt - Gibt an, ob die Farbgruppe gesperrt ist
 * @property {string[]} FarbItemGuids - GUIDs der zugeordneten Farben
 * @property {string[]} OberflaecheGuids - GUIDs der zugeordneten Oberflächen
 */

/**
 * @typedef {Object} FarbKuerzelDTO
 * @property {string} FarbKuerzelGuid - Eindeutige GUID des Farbkürzels
 * @property {string} Kuerzel - Das Farbkürzel
 * @property {string} Beschreibung - Beschreibung des Farbkürzels
 * @property {string} FarbBezeichnung - Bezeichnung der Farbe
 * @property {boolean} IstTrendfarbe - Gibt an, ob es sich um eine Trendfarbe handelt
 * @property {string} FarbItemGuid - GUID der zugeordneten Farbe
 * @property {string} OberflaecheGuid - GUID der zugeordneten Oberfläche
 * @property {string | null} GueltigAb - ISO date string
 * @property {string | null} GueltigBis - ISO date string
 * @property {number} Version - Versionsnummer
 * @property {string} ChangedDate - ISO date string
 */

/**
 * @typedef {Object} FarbKuerzelGruppeDTO
 * @property {string} FarbKuerzelGruppeGuid - Eindeutige GUID der Farbkürzelgruppe
 * @property {string[]} Kuerzel - Liste der Farbkürzel
 * @property {string} Bezeichnung - Bezeichnung der Gruppe
 * @property {string | null} GueltigAb - ISO date string
 * @property {string | null} GueltigBis - ISO date string
 * @property {number} Version - Versionsnummer
 * @property {string} ChangedDate - ISO date string
 */

/**
 * @typedef {Object} FarbgruppeSettingsDTO
 * @property {string} FarbgruppenGuid - GUID der Farbgruppe
 * @property {boolean} GruppeAktiv - Gibt an, ob die Gruppe aktiv ist
 * @property {boolean} PreisAufAnfrage - Gibt an, ob der Preis auf Anfrage ist
 * @property {number} AufpreisElement - Aufpreis für Elemente
 * @property {number} AufpreisFarbe - Aufpreis für Farbe
 * @property {number} ProzentAufpreisElement - Prozentualer Aufpreis für Elemente
 * @property {number} AufpreisMaximal - Maximaler Aufpreis
 * @property {boolean} AufpreisMaximalAktiv - Gibt an, ob der maximale Aufpreis aktiv ist
 */

/**
 * @typedef {Object} FarbgruppenaufpreiseDTO
 * @property {string} FarbgruppenaufpreiseGuid - Eindeutige GUID
 * @property {boolean} NeherModellAktiv - Neher Modell aktiv
 * @property {boolean} EigenesModellAktiv - Eigenes Modell aktiv
 * @property {boolean} IstAdminDTO - Ist Admin DTO
 * @property {FarbgruppeSettingsDTO[]} FarbgruppenSettings - Liste der Farbgruppeneinstellungen
 * @property {number} Version - Versionsnummer
 * @property {string} ChangedDate - ISO date string
 */

/**
 * @typedef {Object} ProduzentenFarbGruppeDTO
 * @property {string} ProduzentenFarbGruppeGuid - Eindeutige GUID
 * @property {string} Name - Name der Produzentenfarbgruppe
 * @property {string[]} Oberflaechen - GUIDs der Oberflächen
 * @property {string[]} Farben - GUIDs der Farben
 * @property {number} Version - Versionsnummer
 * @property {string} ChangedDate - ISO date string
 */

export {};
