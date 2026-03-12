/**
 * @fileoverview BelegPositionen API - Business API for BelegPositionen operations
 * Converted from C# BelegPositionenWebRoutinen.cs
 */

/** @typedef {import('../dtos/belege.js').BelegPositionDTO} BelegPositionDTO */
/** @typedef {import('../dtos/belege.js').VorgangDTO} VorgangDTO */
/** @typedef {import('../fluentApi.js').FluentApi} FluentApi */

/**
 * @typedef {Object} BelegPositionenApi
 * @property {(gesperrtStatus: boolean, positionen: string[]) => Promise<string[]>} setBelegPositionGesperrtStatus - Set locked status for beleg positions
 * @property {(belegPositionGuid: string, mandantId: number) => Promise<VorgangDTO>} getVorgangForFunction - Get vorgang for function by beleg position GUID and mandant ID
 * @property {(belegPositionGuidList: string[]) => Promise<BelegPositionDTO[]>} getBelegPositionenFromGuidList - Get beleg positions from a list of GUIDs
 */

/**
 * @param {FluentApi} fluentApi
 * @returns {BelegPositionenApi}
 */
export function createBelegPositionenApi(fluentApi) {
    return {
    /**
     * Set the locked status for a list of beleg positions
     * @param {boolean} gesperrtStatus - The locked status to set
     * @param {string[]} positionen - Array of beleg position GUIDs
     * @returns {Promise<string[]>} - Array of updated position GUIDs
     */
        async setBelegPositionGesperrtStatus(gesperrtStatus, positionen) {
            return await fluentApi.put(`BelegPositionGesperrtStatus/SetStatus/${gesperrtStatus}`, positionen);
        },

        /**
     * Get vorgang for function by beleg position GUID and mandant ID
     * @param {string} belegPositionGuid - The GUID of the beleg position
     * @param {number} mandantId - The mandant ID
     * @returns {Promise<VorgangDTO>} - The vorgang DTO
     */
        async getVorgangForFunction(belegPositionGuid, mandantId) {
            return await fluentApi.get(`BelegPositionen/GetVorgangForFunction?belegPositionGuid=${belegPositionGuid}&mandantId=${mandantId}`);
        },

        /**
     * Get beleg positions from a list of GUIDs
     * @param {string[]} belegPositionGuidList - Array of beleg position GUIDs
     * @returns {Promise<BelegPositionDTO[]>} - Array of beleg position DTOs
     */
        async getBelegPositionenFromGuidList(belegPositionGuidList) {
            return await fluentApi.post("BelegPositionen/GetByGuidList", belegPositionGuidList);
        }
    };
}
