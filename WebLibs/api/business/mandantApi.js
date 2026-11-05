/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/mandanten.js').MandantDTO} MandantDTO
 * @typedef {import('../dtos/index.js').BenutzerDTO} BenutzerDTO
 * @typedef {import('../dtos/index.js').AppActivationStatusDTO} AppActivationStatusDTO
 */

/**
 * Mandant API - Mandant/tenant management
 * @param {FluentApi} fluentApi
 */
export function createMandantApi(fluentApi) {
    return {
        // MandantenWebRoutinen
        /**
         * Sync mandanten list
         * @param {MandantDTO[]} list
         * @returns {Promise<MandantDTO[]>}
         */
        abgleichen: (list) =>
            Promise.all(list.map(m => fluentApi.put("Mandanten", m))),

        /**
         * Create mandant
         * @param {MandantDTO} mandant
         * @returns {Promise<MandantDTO>}
         */
        anlegen: (mandant) => fluentApi.put("Mandanten", mandant),

        // MandantenAdminWebRoutinen
        admin: {
            /**
             * Add admin rights
             * @param {string} email
             * @returns {Promise<void>}
             */
            addAdminRechte: (email) =>
                fluentApi.post(`MandantenAdmin/SetAdminRechte?email=${encodeURIComponent(email)}`, null),
        },

        // AppWebRoutinen
        app: {
            /**
             * Get mandant status by customer
             * @param {string} kundeGuid
             * @returns {Promise<AppActivationStatusDTO>}
             */
            getStatusByKunde: (kundeGuid) => fluentApi.get(`AppMandant/${kundeGuid}`),

            /**
             * Set mandant status by customer
             * @param {AppActivationStatusDTO} data
             * @returns {Promise<AppActivationStatusDTO>}
             */
            setStatusByKunde: (data) => fluentApi.put("AppMandant", data),

            /**
             * Get mandanten
             * @returns {Promise<MandantDTO[]>}
             */
            getAll: () => fluentApi.get("AppMandant/"),

            /**
             * Get users by customer
             * @param {string} kundeGuid
             * @returns {Promise<BenutzerDTO[]>}
             */
            getBenutzerByKunde: (kundeGuid) => fluentApi.get(`AppBenutzer/${kundeGuid}`),

            /**
             * Create or update user by customer
             * @param {string} kundeGuid
             * @param {BenutzerDTO} data
             * @param {boolean} [pwSenden=false]
             * @param {string} [passwort]
             * @returns {Promise<BenutzerDTO>}
             */
            createOrUpdateBenutzer: (kundeGuid, data, pwSenden = false, passwort = "") =>
                fluentApi.post(`AppBenutzer`, {
                    BenutzerData:  data,
                    KundeGuid: kundeGuid,
                    Passwort: passwort,
                    PasswortSenden: pwSenden
                }),

            /**
             * Delete user by customer
             * @param {string} kundeGuid
             * @param {BenutzerDTO} data
             * @returns {Promise<void>}
             */
            deleteBenutzer: (kundeGuid, data) =>
                fluentApi.delete(`AppBenutzer/?kundeGuid=${kundeGuid}&benutzerGuid=${data.BenutzerGuid}`),

            /**
             * Activate mandant
             * @param {string} adminEmail
             * @returns {Promise<void>}
             */
            aktiviere: (adminEmail) =>
                fluentApi.post("ProduzentAktivieren", { adminEmail }),
        },
    };
}

/**
 * @typedef {ReturnType<typeof createMandantApi>} MandantApi
 */
