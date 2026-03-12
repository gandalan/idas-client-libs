/**
 * @fileoverview JSDoc type definitions for Mandanten (Tenant) DTOs from Gandalan.IDAS.WebApi.Client
 * Auto-generated from C# DTO files in Gandalan.IDAS.WebApi.Client/DTOs/Mandanten/
 */

/**
 * FreigabeLevel enum values
 * @typedef {0|1|2|3|4} FreigabeLevel
 * 0: Unbekannt
 * 1: Gesperrt
 * 2: Lesen
 * 3: LesenSchreiben
 * 4: LesenSchreibenLoeschen
 */

/**
 * FreigabeArt enum values
 * @typedef {0|1|2} FreigabeArt
 * 0: Unbekannt
 * 1: ProgrammModul
 * 2: Variante
 */

/**
 * @typedef {Object} MandantDTO
 * @property {string} Name - Name des Mandanten
 * @property {string} Beschreibung - Beschreibung des Mandanten
 * @property {string} ErstellDatum - ISO date string
 * @property {string} AenderungsDatum - ISO date string
 * @property {string} AdminEmail - E-Mail des Administrators
 * @property {string} MandantGuid - Eindeutige GUID des Mandanten
 * @property {number} SIC_CMS_Producer_Id - SIC CMS Producer ID
 * @property {string} DongleNummer - Dongle-Nummer
 * @property {string} ProduzentMandantGuid - GUID des Produzentenmandanten
 * @property {string} KundenNummerBeimProduzenten - Kundennummer beim Produzenten
 * @property {boolean} IstAktiv - Gibt an, ob der Mandant aktiv ist
 * @property {boolean} IstHaendler - Gibt an, ob es sich um einen Händler handelt
 * @property {boolean} IstProduzent - Gibt an, ob es sich um einen Produzenten handelt
 * @property {boolean} ErbtAuswahlOhneSprosse - Erbt Auswahl ohne Sprosse
 * @property {boolean} StammdatenbearbeitungGesperrt - Stammdatenbearbeitung gesperrt
 * @property {string} NeherKundennummer - Neher Kundennummer
 */

/**
 * @typedef {Object} MandantFreigabeDTO
 * @property {string} Code - Freigabecode
 * @property {string} GueltigAb - ISO date string
 * @property {FreigabeLevel} Level - Freigabelevel
 * @property {FreigabeArt} Art - Freigabeart
 * @property {string} ZusatzDaten - Zusätzliche Daten
 */

/**
 * @typedef {Object} ProduzentAktivierenDTO
 * @property {string} FreischaltCode - Freischaltcode
 * @property {string} AdminEmail - E-Mail des Administrators
 * @property {number} DongleNummer - Dongle-Nummer
 */

export {};
