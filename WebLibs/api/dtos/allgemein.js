/**
 * @fileoverview JSDoc type definitions for Allgemein (General/Common) DTOs from Gandalan.IDAS.WebApi.Client
 * Auto-generated from C# DTO files in Gandalan.IDAS.WebApi.Client/DTOs/Contracts/, DTOs/Templates/, DTOs/Update/, DTOs/WebJob/
 */

/**
 * @typedef {Object} ContractDTO
 * @property {string} ContractGuid - Eindeutige GUID des Vertrags
 * @property {string} Owner - GUID des Eigentümers
 * @property {string} Partner - GUID des Partners
 * @property {string} Context - Kontext des Vertrags
 * @property {string} Value - Wert des Vertrags
 * @property {number} Version - Versionsnummer
 * @property {string} ChangedDate - ISO date string
 * @property {string} OwnerName - Name des Eigentümers
 * @property {string} PartnerName - Name des Partners
 * @property {boolean} IsEditable - Gibt an, ob der Vertrag bearbeitbar ist
 * @property {boolean} Inherit - Gibt an, ob der Vertrag vererbt wird
 */

/**
 * @typedef {Object} TemplateDTO
 * @property {string} TemplateGuid - Eindeutige GUID des Templates
 * @property {string} Titel - Titel des Templates
 * @property {string} Beschreibung - Beschreibung des Templates
 * @property {string} Typ - Typ des Templates
 * @property {string} JsonDaten - Serialisierte Daten als JSON
 * @property {string} ChangedDate - ISO date string
 * @property {string} Benutzer - Benutzer, der das Template erstellt hat
 */

/**
 * @typedef {Object} ChangeDTO
 * @property {string} ChangedGuid - GUID des geänderten Objekts
 * @property {string} ChangedWhen - ISO date string
 * @property {string} ChangeType - Typ der Änderung
 * @property {string} ChangeOperation - Art der Änderung (Insert, Update, Delete)
 * @property {number | null} MandantId - Mandanten-ID
 * @property {string | null} MandantGuid - Mandanten-GUID
 * @property {string} Data - JSON-Daten der Änderung
 */

/**
 * @typedef {Object} ChangeInfoDTO
 * @property {string} Kontakte - ISO date string
 * @property {string} Vorgaenge - ISO date string
 * @property {string} Serien - ISO date string
 * @property {string} BelegPositionenAV - ISO date string
 * @property {string} Settings - ISO date string
 * @property {string} Lagerbestand - ISO date string
 * @property {string} BelegPositionen - ISO date string
 * @property {string} ProduktionsStati - ISO date string
 * @property {string} TagInfos - ISO date string
 */

/**
 * @typedef {Object} UpdateInfoDTO
 * @property {string} KatalogArtikel - ISO date string
 * @property {string} ProduktFamilien - ISO date string
 * @property {string} ProduktGruppen - ISO date string
 * @property {string} Varianten - ISO date string
 * @property {string} UI - ISO date string
 * @property {string} WerteListen - ISO date string
 * @property {string} Farben - ISO date string
 * @property {string} Scripts - ISO date string
 * @property {string} FarbKuerzel - ISO date string
 * @property {string} Oberflaechen - ISO date string
 * @property {string} FarbGruppen - ISO date string
 */

/**
 * @typedef {Object} DevOpsStatusDTO
 * @property {string} Env - Umgebung
 * @property {string} DbInfo - Datenbankinformation
 * @property {string} CurrentMigration - Aktuelle Migration
 * @property {string[]} PendingMigrations - Ausstehende Migrationen
 */

/**
 * @typedef {Object} WebJobHistorieDTO
 * @property {string} WebJobHistorieGuid - Eindeutige GUID
 * @property {string} WebJobName - Name des WebJobs
 * @property {string} Timestamp - ISO date string
 * @property {string} Status - Status des WebJobs
 * @property {string} Text - Zusätzlicher Text
 */

/**
 * @typedef {Object} CreateServiceTokenRequestDTO
 * @property {string} AppTokenGuid - GUID des App-Tokens
 */

/**
 * @typedef {Object} ApiVersionDTO
 * @property {string} Version - API-Version
 * @property {string} Environment - Umgebung
 * @property {string} BuildTime - Build-Zeitpunkt
 * @property {string} ReleaseTime - Veröffentlichungszeitpunkt (veraltet, verwende BuildTime)
 */

/**
 * @typedef {Object} ExtendedStatusCodeDTO
 * @property {Error | null} Exception - Exception-Information
 * @property {string} Info - Statusinformation
 */

export {};
