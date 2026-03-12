/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/produktion.js').LieferzusageDTO} LieferzusageDTO
 * @typedef {import('../dtos/produktion.js').GesamtLieferzusageDTO} GesamtLieferzusageDTO
 */

/**
 * Lieferung API - Delivery promises and commitments
 * @param {FluentApi} fluentApi
 */
export function createLieferungApi(fluentApi) {
    return {
        // LieferzusageWebRoutinen
        /**
         * Get all delivery promises for serie
         * @param {string} serieGuid
         * @param {string} [lieferant]
         * @returns {Promise<LieferzusageDTO[]>}
         */
        getAllLieferzusagen: (serieGuid, lieferant = "") =>
            fluentApi.get(`Lieferzusage/?serieGuid=${serieGuid}&lieferant=${lieferant}`),

        /**
         * Get delivery promises count
         * @param {string} serieGuid
         * @param {string} [lieferant]
         * @returns {Promise<number>}
         */
        getLieferzusagenCount: (serieGuid, lieferant = "") =>
            fluentApi.get(`Lieferzusage/GetCount/${serieGuid}/${lieferant}`),

        /**
         * Submit material delivery promise
         * @param {LieferzusageDTO} lieferzusage
         * @returns {Promise<string>}
         */
        materialZusagen: (lieferzusage) =>
            fluentApi.post("Lieferzusage", lieferzusage),

        /**
         * Submit multiple material delivery promises
         * @param {LieferzusageDTO[]} lieferzusagen
         * @returns {Promise<string>}
         */
        materialZusagenListe: (lieferzusagen) =>
            fluentApi.post("Lieferzusage/PutLieferzusagenListe", lieferzusagen),

        /**
         * Reset delivery promise
         * @param {string} lieferzusageGuid
         * @returns {Promise<void>}
         */
        resetLieferzusage: (lieferzusageGuid) =>
            fluentApi.delete(`Lieferzusage?zusageGuid=${lieferzusageGuid}`),

        /**
         * Reset multiple delivery promises
         * @param {string[]} lieferzusagenGuids
         * @returns {Promise<string>}
         */
        resetLieferzusagen: (lieferzusagenGuids) =>
            fluentApi.delete("Lieferzusage/DeleteLieferzusagen", lieferzusagenGuids),

        /**
         * Reset delivery promises by serie
         * @param {string} serieGuid
         * @param {string} [lieferant]
         * @returns {Promise<void>}
         */
        resetLieferzusagenBySerie: (serieGuid, lieferant = "") =>
            fluentApi.delete(`Lieferzusage/DeleteLieferzusagenBySerie/?serieGuid=${serieGuid}&lieferant=${lieferant}`),

        // GesamtLieferzusagenWebRoutinen
        gesamt: {
            /**
             * Get total delivery promises
             * @param {Date} [stichTag]
             * @returns {Promise<GesamtLieferzusageDTO[]>}
             */
            getAll: (stichTag) =>
                fluentApi.get(`GesamtLieferzusagen?stichTag=${stichTag?.toISOString() || ""}`),

            /**
             * Save total delivery promise
             * @param {GesamtLieferzusageDTO} dto
             * @returns {Promise<void>}
             */
            save: (dto) => fluentApi.put("GesamtLieferzusagen", dto),

            /**
             * Save multiple total delivery promises
             * @param {GesamtLieferzusageDTO[]} dtoSet
             * @returns {Promise<string>}
             */
            saveListe: (dtoSet) =>
                fluentApi.put("GesamtLieferzusagen/PutGesamtLieferzusagenListe", dtoSet),

            /**
             * Book serie delivery promises
             * @param {string} serieGuid
             * @returns {Promise<void>}
             */
            serieBuchen: (serieGuid) =>
                fluentApi.post(`GesamtLieferzusagen/SerieBuchen?serieGuid=${serieGuid}`, null),

            /**
             * Delete total delivery promise
             * @param {string} gesamtLieferzusageGuid
             * @returns {Promise<void>}
             */
            delete: (gesamtLieferzusageGuid) =>
                fluentApi.delete(`GesamtLieferzusage?gesamtLieferzusageGuid=${gesamtLieferzusageGuid}`),

            /**
             * Delete multiple total delivery promises
             * @param {string[]} gesamtLieferzusagenGuids
             * @returns {Promise<string>}
             */
            deleteListe: (gesamtLieferzusagenGuids) =>
                fluentApi.delete("GesamtLieferzusage/DeleteGesamtLieferzusagen", gesamtLieferzusagenGuids),
        },
    };
}

/**
 * @typedef {ReturnType<typeof createLieferungApi>} LieferungApi
 */
