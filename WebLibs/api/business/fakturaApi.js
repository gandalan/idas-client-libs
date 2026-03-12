/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/faktura.js').SetFakturaDTO} SetFakturaDTO
 */

/**
 * Faktura API - Faktura kennzeichen (status flags) management
 * Corresponds to FakturaWebRoutinen in C#
 * @param {FluentApi} fluentApi
 */
export function createFakturaApi(fluentApi) {
    return {
    /**
     * Get vorgang identifier
     * @param {string} vorgangGuid
     * @returns {Promise<string>}
     */
        getVorgangKennzeichen: (vorgangGuid) =>
            fluentApi.get(`Faktura/GetVorgangKennzeichen?vorgangGuid=${vorgangGuid}`),

        /**
     * Get beleg identifier
     * @param {string} belegGuid
     * @returns {Promise<string>}
     */
        getBelegKennzeichen: (belegGuid) =>
            fluentApi.get(`Faktura/GetBelegKennzeichen?belegGuid=${belegGuid}`),

        /**
     * Get beleg position identifier
     * @param {string} belegPositionGuid
     * @returns {Promise<string>}
     */
        getBelegPositionKennzeichen: (belegPositionGuid) =>
            fluentApi.get(`Faktura/GetBelegPositionKennzeichen?belegPositionGuid=${belegPositionGuid}`),

        /**
     * Get beleg position AV identifier
     * @param {string} belegPositionAvGuid
     * @returns {Promise<string>}
     */
        getBelegPositionAvKennzeichen: (belegPositionAvGuid) =>
            fluentApi.get(`Faktura/GetBelegPositionAVKennzeichen?belegPositionAvGuid=${belegPositionAvGuid}`),

        /**
     * Set vorgang identifier
     * @param {SetFakturaDTO} dto
     * @returns {Promise<string>}
     */
        setVorgangKennzeichen: (dto) =>
            fluentApi.post("Faktura/SetVorgangKennzeichen", dto),

        /**
     * Set beleg identifier
     * @param {SetFakturaDTO} dto
     * @returns {Promise<string>}
     */
        setBelegKennzeichen: (dto) =>
            fluentApi.post("Faktura/SetBelegKennzeichen", dto),

        /**
     * Set beleg position identifier
     * @param {SetFakturaDTO} dto
     * @returns {Promise<string>}
     */
        setBelegPositionKennzeichen: (dto) =>
            fluentApi.post("Faktura/SetBelegPositionKennzeichen", dto),

        /**
     * Set beleg position AV identifier
     * @param {SetFakturaDTO} dto
     * @returns {Promise<string>}
     */
        setBelegPositionAvKennzeichen: (dto) =>
            fluentApi.post("Faktura/SetBelegPositionAVKennzeichen", dto),

        /**
     * Set automatic invoicing in delivery notes
     * @returns {Promise<void>}
     */
        setFakturaInAbAuto: () =>
            fluentApi.post("Faktura/SetFakturaInABAuto", null),
    };
}

/**
 * @typedef {ReturnType<typeof createFakturaApi>} FakturaApi
 */
