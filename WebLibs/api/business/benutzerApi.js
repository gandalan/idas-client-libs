/**
 * @typedef {Object} FluentApi
 * @property {(endpoint: string) => { get: () => Promise<any>, post: (data: any) => Promise<any>, put: (data: any) => Promise<any> }} endpoint
 */

/**
 * @typedef {import('../dtos/index.js').BenutzerDTO} BenutzerDTO
 * @typedef {import('../dtos/index.js').PasswortAendernDTO} PasswortAendernDTO
 * @typedef {import('../dtos/index.js').RolleDTO} RolleDTO
 */

/**
 * Creates a Benutzer API client
 * @param {FluentApi} fluentApi - The fluent API instance
 * @returns {Object} Benutzer API methods
 */
export function createBenutzerApi(fluentApi) {
    return {
        /**
         * Get list of users for a mandant
         * @param {string} mandant - Mandant GUID
         * @param {boolean} [mitRollenUndRechten=true] - Include roles and rights
         * @returns {Promise<BenutzerDTO[]>} List of users
         */
        getBenutzerListe: async (mandant, mitRollenUndRechten = true) => {
            return await fluentApi.get(`BenutzerListe?id=${mandant}&mitRollenUndRechten=${mitRollenUndRechten}`);
        },

        /**
         * Get a single user by GUID
         * @param {string} benutzer - User GUID
         * @param {boolean} [mitRollenUndRechten=true] - Include roles and rights
         * @returns {Promise<BenutzerDTO>} User data
         */
        getBenutzer: async (benutzer, mitRollenUndRechten = true) => {
            return await fluentApi.get(`Benutzer?id=${benutzer}&mitRollenUndRechten=${mitRollenUndRechten}`);
        },

        /**
         * Save multiple users
         * @param {BenutzerDTO[]} list - List of users to save
         * @returns {Promise<void>}
         */
        saveBenutzerList: async (list) => {
            await Promise.all(list.map(benutzer => 
                fluentApi.put('Benutzer', benutzer)
            ));
        },

        /**
         * Save a single user
         * @param {BenutzerDTO} benutzer - User data to save
         * @returns {Promise<any>} Response
         */
        saveBenutzer: async (benutzer) => {
            return await fluentApi.put('Benutzer', benutzer);
        },

        /**
         * Request password reset for a user
         * @param {string} benutzerName - User email/name
         * @returns {Promise<any>} Response
         */
        passwortReset: async (benutzerName) => {
            const encodedName = encodeURIComponent(benutzerName);
            return await fluentApi.get(`PasswortReset?email=${encodedName}`);
        },

        /**
         * Change password
         * @param {PasswortAendernDTO} passwortAendernData - Password change data
         * @returns {Promise<any>} Response
         */
        passwortAendern: async (passwortAendernData) => {
            return await fluentApi.post('PasswortAendern', passwortAendernData);
        },

        /**
         * Trigger SIC sync web job
         * @returns {Promise<any>} Response
         */
        sicSyncWebJob: async () => {
            return await fluentApi.post('Benutzer/SICSyncWebJob', null);
        },

        /**
         * Get all roles
         * @returns {Promise<RolleDTO[]>} List of all roles
         */
        getRollenAll: async () => {
            return await fluentApi.get('Rollen');
        }
    };
}
