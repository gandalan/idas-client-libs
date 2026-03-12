/**
 * @fileoverview JSDoc type definitions for Artikel DTOs from Gandalan.IDAS.WebApi.Client
 * Auto-generated from C# DTO files in Gandalan.IDAS.WebApi.Client/DTOs/Artikel/
 */

/**
 * @typedef {Object} KatalogArtikelIndiDatenDTO
 * @property {string} KatalogArtikelIndiDatenGuid - UUID
 * @property {string} KatalogArtikelGuid - UUID
 * @property {boolean} IsPassiv
 * @property {boolean} IsInventurPflichtig
 * @property {boolean} IsLagerartikel
 * @property {boolean} BestellMengeAufVERunden
 * @property {string} KundenArtikelNummer
 * @property {Array<IndiFarbDatenDTO>} FarbDaten
 * @property {boolean} Freigabe_IBOS
 * @property {boolean} Freigabe_BestellFix
 * @property {boolean} Freigabe_ARTOS
 * @property {number} InventurBewertung
 * @property {string} ChangedDate - ISO date string
 * @property {string} SerializedOptions
 */

/**
 * @typedef {Object} IndiFarbDatenDTO
 * @property {string} IndiFarbDatenGuid - UUID
 * @property {boolean} IsPassiv
 * @property {string} FarbKuerzel
 * @property {boolean} BestellMengeAufVERunden
 * @property {number} SonderPreis
 * @property {boolean} IsInventurpflichtig
 * @property {boolean} Lagerfuehrung
 * @property {boolean} Freigabe_IBOS
 * @property {boolean} Freigabe_BestellFix
 * @property {boolean} Freigabe_ARTOS
 */

/**
 * @typedef {Object} MaterialBearbeitungsMethodeDTO
 * @property {string} MaterialBearbeitungsMethodeGuid - UUID
 * @property {string} Bezeichnung
 * @property {number} Version
 * @property {string} ChangedDate - ISO date string
 */

export {};
