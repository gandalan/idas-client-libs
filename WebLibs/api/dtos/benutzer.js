/**
 * @fileoverview JSDoc type definitions for Benutzer (User) DTOs from Gandalan.IDAS.WebApi.Client
 * Auto-generated from C# DTO files in Gandalan.IDAS.WebApi.Client/DTOs/Benutzer/
 */

/** @typedef {import('./settings.js').MandantDTO} MandantDTO */

/**
 * @typedef {Object} BerechtigungDTO
 * @property {string} Code
 * @property {string} ErklaerungsText
 * @property {string} Level
 */

/**
 * @typedef {Object} RolleDTO
 * @property {BerechtigungDTO[]} Berechtigungen
 * @property {string} Name
 * @property {string} Beschreibung
 * @property {string} RolleGuid
 */

/**
 * @typedef {Object} BenutzerDTO
 * @property {RolleDTO[]} Rollen
 * @property {string} BenutzerGuid
 * @property {string} Benutzername
 * @property {string} Vorname
 * @property {string} Nachname
 * @property {string | null} MandantGuid
 * @property {string} Passwort
 * @property {string} PasswortBCrypt
 * @property {boolean | null} MasterKatalog
 * @property {boolean | null} HauptKatalog
 * @property {number | null} NewsletterId
 * @property {boolean} IstAktiv
 * @property {string[]} GesperrteVarianten
 * @property {string} ChangedDate - ISO date string
 * @property {string} EmailAdresse
 * @property {string} TelefonNummer
 * @property {string} Art
 * @property {boolean} IstSicSynchronized
 * @property {string} LastSicMessage
 */

/**
 * @typedef {Object} LoginDTO
 * @property {string} Email
 * @property {string} Password
 * @property {string} Mandant
 * @property {string} AppToken
 */

/**
 * @typedef {Object} LoginAttemptDTO
 * @property {string} UserGuid
 * @property {number} FailCount
 * @property {string | null} RequestTime - ISO date string
 */

/**
 * @typedef {Object} LoginAttemptResultDTO
 * @property {number} FailCount
 * @property {string | null} LastFailedLogin - ISO date string
 */

/**
 * @typedef {Object} PasswortAendernDTO
 * @property {string} Benutzername
 * @property {string} AltesPasswort
 * @property {string} NeuesPasswort
 */

/**
 * @typedef {Object} RefreshTokenDTO
 * @property {string} Token
 * @property {string} Expires - ISO date string
 * @property {string} UserTokenGuid
 * @property {UserAuthTokenDTO | null} UserToken
 * @property {string} AppToken
 */

/**
 * @typedef {Object} UserAuthTokenDTO
 * @property {string} AppToken
 * @property {string} Expires - ISO date string
 * @property {string} Token
 * @property {BenutzerDTO | null} Benutzer
 * @property {string} MandantGuid
 * @property {MandantDTO | null} Mandant
 */

/**
 * @typedef {Object} ZustimmungsInfoDTO
 * @property {string} Dokument
 * @property {string} Version
 * @property {string} Zeitstempel - ISO date string
 * @property {string} Plattform
 */

export {};
