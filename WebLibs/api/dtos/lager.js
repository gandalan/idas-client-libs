/**
 * @fileoverview JSDoc type definitions for Lager (Warehouse) DTOs from Gandalan.IDAS.WebApi.Client
 * Auto-generated from C# DTO files in Gandalan.IDAS.WebApi.Client/DTOs/Produktion/
 */

/**
 * @typedef {Object} LagerbestandDTO
 * @property {string} LagerbestandGuid - Eindeutige GUID des Lagerbestands
 * @property {string} KatalogArtikelGuid - GUID des Katalogartikels
 * @property {string} KatalogNummer - Katalognummer
 * @property {string} FarbGuid - GUID der Farbe (veraltet, verwende FarbKuerzelGuid)
 * @property {string} FarbKuerzelGuid - GUID des Farbkürzels
 * @property {string} FarbKuerzel - Farbkürzel
 * @property {number} Lagerbestand - Aktueller Lagerbestand
 * @property {number} Bestellbestand - Bestellbestand
 * @property {number} Mindestbestand - Mindestbestand
 * @property {number} Reserviert - Reservierte Menge
 * @property {number} Maximalbestand - Maximalbestand
 * @property {number} EisernerBestand - Eiserner Bestand
 * @property {string} Einheit - Einheit (z.B. Stk, lfm)
 * @property {string} Lagerplatz - Lagerplatz
 * @property {string} Charge - Chargennummer
 * @property {boolean} IstAktiv - Gibt an, ob der Lagerbestand aktiv ist
 * @property {string} Seriennummer - Seriennummer
 * @property {string} ChangedDate - ISO date string
 * @property {string} WindowsUser - Windows-Benutzer
 */

/**
 * @typedef {Object} LagerbuchungDTO
 * @property {string} KatalogArtikelGuid - GUID des Katalogartikels
 * @property {string} FarbGuid - GUID der Farbe (veraltet, verwende FarbKuerzelGuid)
 * @property {string} FarbKuerzelGuid - GUID des Farbkürzels
 * @property {string} LagerbestandGuid - GUID des Lagerbestands
 * @property {number} Betrag - Buchungsbetrag
 * @property {boolean} IstReservierung - Gibt an, ob es sich um eine Reservierung handelt
 * @property {string} Einheit - Einheit
 * @property {string} Hinweis - Hinweistext
 * @property {string} ArtosUser - Artos-Benutzer
 * @property {string} WindowsUser - Windows-Benutzer
 * @property {string} ChangedDate - ISO date string
 * @property {number} BestandAlt - Alter Bestand
 * @property {number} BestandNeu - Neuer Bestand
 */

/**
 * @typedef {Object} LagerReservierungDTO
 * @property {string} LagerReservierungGuid - Eindeutige GUID der Lagerreservierung
 * @property {string | null} MaterialbedarfGuid - GUID des Materialbedarfs
 * @property {string | null} LieferzusageGuid - GUID der Lieferzusage
 * @property {string | null} GesamtLieferzusageGuid - GUID der Gesamtlieferzusage
 * @property {string} Artikelnummer - Artikelnummer
 * @property {string} FarbKuerzel - Farbkürzel
 * @property {string} FarbCode - Farbcode
 * @property {string} Oberflaeche - Oberfläche
 * @property {string} Bezug - Bezug (z.B. Vorgangsnummer)
 * @property {number} Menge - Reservierte Menge
 * @property {string} Einheit - Einheit
 * @property {string} ErstellDatum - ISO date string
 * @property {string} WindowsUser - Windows-Benutzer
 * @property {string} ArtosUser - Artos-Benutzer
 * @property {string} ChangedDate - ISO date string
 * @property {number} Version - Versionsnummer
 */

export {};
