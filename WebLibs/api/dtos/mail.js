/**
 * @fileoverview JSDoc type definitions for Mail DTOs from Gandalan.IDAS.WebApi.Client
 * Auto-generated from C# DTO files in Gandalan.IDAS.WebApi.Client/Mail/
 */

/**
 * @typedef {Object} MailJobInfo
 * @property {string} JobGuid - UUID
 * @property {Array<string>} ToAddresses
 * @property {Array<string>} CCAddresses
 * @property {string} ReplyToAddress
 * @property {string} Subject
 * @property {string} Content
 * @property {string} BelegGuid - UUID
 */

/**
 * @typedef {Object} JobStatusEntryDTO
 * @property {string} JobGuid - UUID
 * @property {string} Timestamp - ISO date string
 * @property {string} StatusText
 * @property {string} RowKey - UUID (read-only)
 */

/**
 * @typedef {Object} JobStatusResponseDTO
 * @property {string} JobGuid - UUID
 */

export {};
