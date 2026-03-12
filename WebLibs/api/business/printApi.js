/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 */

/**
 * Print API - Document printing and generation
 * @param {FluentApi} fluentApi
 */
export function createPrintApi(fluentApi) {
    return {
        // PrintWebRoutinen
        /**
         * Generate PDF for beleg
         * @param {string} belegGuid
         * @returns {Promise<Uint8Array>}
         */
        pdfErzeugen: (belegGuid) =>
            fluentApi.post(`Print/?bguid=${belegGuid}`, []),

        /**
         * Generate XPS for beleg
         * @param {string} belegGuid
         * @returns {Promise<Uint8Array>}
         */
        xpsErzeugen: (belegGuid) =>
            fluentApi.post(`Print/?bguid=${belegGuid}&fileFormat=XPS`, []),

        // PrintV2WebRoutinen
        /**
         * Generate PDF v2
         * @param {string} belegGuid
         * @param {string} email
         * @returns {Promise<Uint8Array>}
         */
        pdfV2: (belegGuid, email) =>
            fluentApi.get(`PrintV2/Pdf?bguid=${belegGuid}&email=${encodeURIComponent(email)}`),

        // BriefbogenWebRoutinen
        /**
         * Load letterhead
         * @returns {Promise<Uint8Array>}
         */
        briefbogenLaden: () => fluentApi.get("Briefbogen"),
    };
}

/**
 * @typedef {ReturnType<typeof createPrintApi>} PrintApi
 */
