/**
 * @fileoverview JSDoc type definitions for Faktura (Invoicing) DTOs from Gandalan.IDAS.WebApi.Client
 * Auto-generated from C# DTO files in Gandalan.IDAS.WebApi.Client/DTOs/Rechnung/ and DTOs/Faktura/
 */

/** @typedef {import('./kunden.js').BeleganschriftDTO} BeleganschriftDTO */
/** @typedef {import('./kunden.js').KontaktDTO} KontaktDTO */
/** @typedef {import('./belege.js').BelegDruckDTO} BelegDruckDTO */

/**
 * Lieferungstyp enum values
 * @typedef {0|1|2} Lieferungstyp
 * 0: Inland
 * 1: EU_Ausland
 * 2: Welt
 */

/**
 * @typedef {Object} SetFakturaDTO
 * @property {string[]} GuidList - Liste der GUIDs
 * @property {string} Kennzeichen - Erlaubte Werte: "Freigegeben", "Abgerechnet"
 */

/**
 * @typedef {Object} BelegeInfoDTO
 * @property {string} VorgangGuid
 * @property {string} BelegGuid
 * @property {string} KontaktGuid
 * @property {string[]} BelegPositionGuids
 * @property {string} Belegart
 * @property {number} Vorgangsnummer
 * @property {number} BelegNummer
 * @property {string} BelegDatum - ISO date string
 * @property {number} PosAnzahl
 * @property {number} GesamtBetrag
 * @property {string} Kundennummer
 * @property {string} Kundenname
 * @property {string} Lieferadresse
 * @property {boolean} IstSammelrechnungsKunde
 * @property {boolean} InnergemeinschaftlichOhneMwSt
 * @property {number | null} SammelrechnungsNummer
 * @property {string | null} LastPrintDate - ISO date string
 * @property {string | null} LastExportDate - ISO date string
 * @property {number} MwSt
 * @property {Lieferungstyp} Lieferungstyp
 * @property {boolean} HatRechnungUndRechNrIstVorgangNr
 */

/**
 * @typedef {Object} SammelrechnungPositionenDTO
 * @property {string} SammelrechnungPositionGuid
 * @property {number} LaufendeNummer
 * @property {number} RechnungNummer
 * @property {string} RechnungDatum - ISO date string
 * @property {string} RechnungKommision
 * @property {number} RechnungBetrag
 * @property {string} VorgangsDatum - ISO date string
 * @property {SammelrechnungSaldenDTO[]} Salden
 */

/**
 * @typedef {Object} SammelrechnungSaldenDTO
 * @property {string} SammelrechnungSaldenGuid
 * @property {number} Reihenfolge
 * @property {string} Text
 * @property {number} Betrag
 * @property {number} Rabatt
 * @property {string} Name
 */

/**
 * @typedef {Object} SammelrechnungDTO
 * @property {string} SammelrechnungGuid
 * @property {number} SammelrechnungsNummer
 * @property {string} ErstellDatum - ISO date string
 * @property {string | null} LastPrintDate - ISO date string
 * @property {string | null} LastExportDate - ISO date string
 * @property {string} Ansprechpartner
 * @property {string} Telefonnummer
 * @property {string} Liefertermin
 * @property {string} ZahlungsBedingungen
 * @property {string} Kopfzeile
 * @property {string} Fusszeile
 * @property {string} Schlusstext
 * @property {string} PageTitle
 * @property {string} PageSubtitle1
 * @property {string} PageSubtitle2
 * @property {KontaktDTO} Kontakt
 * @property {BeleganschriftDTO} RechnungsAdresse
 * @property {SammelrechnungPositionenDTO[]} Positionen
 * @property {SammelrechnungSaldenDTO[]} Salden
 * @property {BelegDruckDTO[]} EinzelrechnungDTOs
 */

/**
 * @typedef {Object} SammelrechnungListItemDTO
 * @property {string} SammelrechnungGuid
 * @property {number} SammelrechnungNummer
 * @property {string} Kundenname
 * @property {string} Kundennummer
 * @property {string} ErstellDatum - ISO date string
 * @property {string | null} LastPrintDate - ISO date string
 * @property {string | null} LastExportDate - ISO date string
 * @property {number} AnzahlPositionen
 * @property {number} GesamtBetrag
 * @property {string} KundenGuid
 * @property {number} MwSt
 * @property {Lieferungstyp} Lieferungstyp
 */

/**
 * @typedef {Object} CreateSammelrechnungDTO
 * @property {string[]} BelegGuids
 * @property {string} KontaktGuid
 * @property {string} Ansprechpartner
 * @property {string} Liefertermin
 * @property {string} Schlusstext
 * @property {string} ZahlungsBedingungen
 * @property {BeleganschriftDTO} RechnungsAdresse
 */

/**
 * @typedef {Object} AddRechnungSammelrechnungDTO
 * @property {string} BelegGuid
 * @property {string} SammelrechnungGuid
 */

export {};
