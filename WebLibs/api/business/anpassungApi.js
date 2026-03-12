/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {Object & { AnpassungGuid?: string, anpassungGuid?: string }} AnpassungDTO
 * @typedef {Object & { AnpassungVorlageGuid?: string, anpassungVorlageGuid?: string }} AnpassungVorlageDTO
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

        /**
         * Delete adjustment
         * @param {string} anpassungGuid
         * @returns {Promise<void>}
         */
        delete: (anpassungGuid) => fluentApi.delete(`Anpassungen/${anpassungGuid}`),

        /**
         * Run adjustment web job
         * @returns {Promise<void>}
         */
        runWebJob: () => fluentApi.post("Anpassungen/WebJob", ""),

        // AnpassungVorlagenWebRoutinen
        vorlage: {
            /**
             * Get all adjustment templates
             * @returns {Promise<AnpassungVorlageDTO[]>}
             */
            getAll: () => fluentApi.get("AnpassungVorlagen"),

            /**
             * Get adjustment template by GUID
             * @param {string} guid
             * @returns {Promise<AnpassungVorlageDTO>}
             */
            get: (guid) => fluentApi.get(`AnpassungVorlagen/${guid}`),

            /**
             * Save adjustment template
             * @param {AnpassungVorlageDTO} dto
             * @returns {Promise<void>}
             */
            save: (dto) => fluentApi.put(`AnpassungVorlagen/${dto.AnpassungVorlageGuid ?? dto.anpassungVorlageGuid ?? ""}`, dto),

            /**
             * Delete adjustment template
             * @param {string} guid
             * @returns {Promise<void>}
             */
            delete: (guid) => fluentApi.delete(`AnpassungVorlagen/${guid}`),
        },
    };
}

/**
 * @typedef {ReturnType<typeof createAnpassungApi>} AnpassungApi
 */
