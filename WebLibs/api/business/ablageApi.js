/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/produktion.js').AblageDTO} AblageDTO
 * @typedef {import('../dtos/produktion.js').AblageFachDTO} AblageFachDTO
 * @typedef {import('../dtos/produktion.js').FachzuordnungResultDTO} FachzuordnungResultDTO
 */

/**
 * Ablage API - Storage and bin management
 * @param {FluentApi} fluentApi
 */
export function createAblageApi(fluentApi) {
    return {
        // AblageWebRoutinen
        /**
         * Get storage by GUID
         * @param {string} guid
         * @returns {Promise<AblageDTO>}
         */
        get: (guid) => fluentApi.get(`Ablage/?id=${guid}`),

        /**
         * Get all storage locations
         * @param {Date} [changedSince]
         * @param {boolean} [includeDetails=true]
         * @returns {Promise<AblageDTO[]>}
         */
        getAll: (changedSince, includeDetails = true) => {
            if (changedSince) {
                return fluentApi.get(`Ablage?changedSince=${changedSince.toISOString()}&includeDetails=${includeDetails}`);
            }
            return fluentApi.get(`Ablage?includeDetails=${includeDetails}`);
        },

        /**
         * Save storage
         * @param {AblageDTO} dto
         * @returns {Promise<void>}
         */
        save: (dto) => fluentApi.put("Ablage/", dto),

        /**
         * Delete storage
         * @param {string} guid
         * @returns {Promise<void>}
         */
        delete: (guid) => fluentApi.delete(`Ablage/?id=${guid}`),

        /**
         * Distribute serie to bins
         * @param {string} serieGuid
         * @returns {Promise<FachzuordnungResultDTO>}
         */
        serienFachverteilung: (serieGuid) =>
            fluentApi.put(`Ablage/SerienFachverteilung/${serieGuid}`, null),

        /**
         * Distribute AV positions to bins
         * @param {string[]} avGuids
         * @returns {Promise<FachzuordnungResultDTO>}
         */
        fachverteilung: (avGuids) =>
            fluentApi.put("Ablage/Fachverteilung", avGuids),

        // AblageFachWebRoutinen
        fach: {
            /**
             * Get bin by GUID
             * @param {string} guid
             * @returns {Promise<AblageFachDTO>}
             */
            get: (guid) => fluentApi.get(`AblageFach/?id=${guid}`),

            /**
             * Get all bins
             * @param {Date} [changedSince]
             * @param {boolean} [includeDetails=true]
             * @returns {Promise<AblageFachDTO[]>}
             */
            getAll: (changedSince, includeDetails = true) => {
                if (changedSince) {
                    return fluentApi.get(`AblageFach?changedSince=${changedSince.toISOString()}&includeDetails=${includeDetails}`);
                }
                return fluentApi.get(`AblageFach?includeDetails=${includeDetails}`);
            },

            /**
             * Save bin
             * @param {AblageFachDTO} dto
             * @returns {Promise<void>}
             */
            save: (dto) => fluentApi.put("AblageFach/", dto),

            /**
             * Delete bin
             * @param {string} guid
             * @returns {Promise<void>}
             */
            delete: (guid) => fluentApi.delete(`AblageFach/?id=${guid}`),
        },
    };
}

/**
 * @typedef {ReturnType<typeof createAblageApi>} AblageApi
 */
