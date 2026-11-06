/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 */

/**
 * @typedef {Object} AnpassungDTO
 * @property {string} AnpassungGuid
 * @property {string} Art
 * @property {boolean} GiltFuerBesitzer
 * @property {boolean} GiltFuerAlleUntermandanten
 * @property {boolean} GiltFuerZielMandant
 * @property {string} ZielMandantGuid
 * @property {string} Content
 * @property {string} WarengruppeGuid
 * @property {string} ArtikelGuid
 * @property {number} Version
 * @property {string} ChangedDate - ISO date string
 */

/**
 * Anpassung API - Customization and adjustment management
 * @param {FluentApi} fluentApi
 */
export function createAnpassungApi(fluentApi) {
    return {
        // AnpassungenWebRoutinen
        /**
         * Get all adjustments
         * @returns {Promise<AnpassungDTO[]>}
         */
        getAll: () => fluentApi.get("Anpassungen"),

        /**
         * Save adjustment
         * @param {AnpassungDTO} dto
         * @returns {Promise<void>}
         */
        save: (dto) => fluentApi.put(`Anpassungen/${dto.AnpassungGuid ?? dto.anpassungGuid ?? ""}`, dto),
    };
}

/**
 * @typedef {ReturnType<typeof createAnpassungApi>} AnpassungApi
 */
