import { restClient } from "./fluentRestClient";
import { createVorgangApi } from "./business/vorgangApi";
import { createKontaktApi } from "./business/kontaktApi";
import { createBelegPositionenApi } from "./business/belegPositionenApi";
import { createMaterialApi } from "./business/materialApi";
import { createSerienApi } from "./business/serienApi";
import { createBenutzerApi } from "./business/benutzerApi";
import { createArtikelApi } from "./business/artikelApi";
import { createBelegApi } from "./business/belegApi";
import { createProduktionApi } from "./business/produktionApi";
import { createFakturaApi } from "./business/fakturaApi";
import { createSettingsApi } from "./business/settingsApi";
import { createUiApi } from "./business/uiApi";
import { createUtilityApi } from "./business/utilityApi";

/**
 * @typedef {import("./business/vorgangApi").VorgangApi} VorgangApi
 * @typedef {import("./business/kontaktApi").KontaktApi} KontaktApi
 * @typedef {import("./business/belegPositionenApi").BelegPositionenApi} BelegPositionenApi
 * @typedef {import("./business/materialApi").MaterialApi} MaterialApi
 * @typedef {import("./business/serienApi").SerienApi} SerienApi
 * @typedef {import("./business/benutzerApi").BenutzerApi} BenutzerApi
 * @typedef {import("./business/artikelApi").ArtikelApi} ArtikelApi
 * @typedef {import("./business/belegApi").BelegApi} BelegApi
 * @typedef {import("./business/produktionApi").ProduktionApi} ProduktionApi
 * @typedef {import("./business/fakturaApi").FakturaApi} FakturaApi
 * @typedef {import("./business/settingsApi").SettingsApi} SettingsApi
 * @typedef {import("./business/uiApi").UiApi} UiApi
 * @typedef {import("./business/utilityApi").UtilityApi} UtilityApi
 */

/**
 * @typedef {Object} FluentApi
 * @property {string} baseUrl - The base URL for API requests.
 * @property {import("./fluentAuthManager").FluentAuthManager} authManager - The authentication manager.
 * @property {string} serviceName - The name of the service using this API.
 * @property {function(string) : FluentApi} useBaseUrl - Sets the base URL for API requests and returns the FluentApi object.
 * @property {function(fluentAuthManager) : FluentApi} useAuthManager - Sets the auth manager and returns the FluentApi object.
 * @property {function(string) : FluentApi} useServiceName - Sets the service name and returns the FluentApi object.
 * @property {function(string, boolean) : Promise<object|Array<any>>} get - Async function to perform GET requests.
 * @property {function(string, object|null, boolean) : Promise<object|Array<any>>} put - Async function to perform PUT requests with a payload.
 * @property {function(string, object|null, boolean) : Promise<object|Array<any>>} post - Async function to perform POST requests with a payload.
 * @property {function(string, boolean) : Promise<object|Array<any>>} delete - Async function to perform DELETE requests.
 * @property {VorgangApi} vorgang - Vorgang (Auftrag) business routines
 * @property {KontaktApi} kontakt - Kontakt (Kunden/Lieferanten) business routines
 * @property {BelegPositionenApi} belegPositionen - BelegPositionen business routines
 * @property {MaterialApi} material - Material business routines
 * @property {SerienApi} serien - Serien/AV business routines
 * @property {BenutzerApi} benutzer - Benutzer/Rollen business routines
 * @property {ArtikelApi} artikel - Artikel/Stammdaten business routines
 * @property {BelegApi} beleg - Beleg/Status/Historie business routines
 * @property {ProduktionApi} produktion - Produktion business routines
 * @property {FakturaApi} faktura - Faktura/Rechnungen business routines
 * @property {SettingsApi} settings - Settings/Contracts business routines
 * @property {UiApi} ui - UI/Scripts/Filter business routines
 * @property {UtilityApi} utility - Utility/File/Mail/Print business routines
 */

/**
 * Builds a client to communicate with the IDAS or local API using fluent syntax.
 *
 * @return {FluentApi} A configured API client instance.
 */
export function createApi() {
    return {
        authManager: {},
        baseUrl: "",
        serviceName: "unknownService",

        /**
         * Sets the base URL for API requests.
         *
         * @param {string} [url=""]
         * @return {FluentApi}
         */
        useBaseUrl(url = "") {
            this.baseUrl = url;
            return this;
        },

        /**
         * Sets the authentication manager.
         *
         * @param {FluentAuthManager} authManager
         * @return {FluentApi}
         */
        useAuthManager(authManager) {
            this.authManager = authManager;
            return this;
        },

        /**
         * Sets the service name for this API client.
         *
         * @param {string} name - The name of the service using this API.
         * @return {FluentApi}
         */
        useServiceName(name) {
            this.serviceName = name ?? this.serviceName;
            return this;
        },

        /**
          * Sends a GET request, ensuring authentication if needed.
          *
          * @async
          * @param {string} [url=""]
          * @param {boolean} [auth=true]
          * @returns {Promise<Object>}
          */
        async get(url = "", auth = true) {
            await this.preCheck(auth);
            return await this.createRestClient().get(url);
        },

        /**
          * Sends a PUT request with a payload, ensuring authentication if needed.
          *
          * @async
          * @param {string} [url=""]
          * @param {Object} [payload={}]
          * @param {boolean} [auth=true]
          * @returns {Promise<Object>}
          */
        async put(url = "", payload = {}, auth = true) {
            await this.preCheck(auth);
            return await this.createRestClient().put(url, payload);
        },

        /**
          * Sends a POST request with a payload, ensuring authentication if needed.
          *
          * @async
          * @param {string} [url=""]
          * @param {Object} [payload={}]
          * @param {boolean} [auth=true]
          * @returns {Promise<Object>}
          */
        async post(url = "", payload = {}, auth = true) {
            await this.preCheck(auth);
            return await this.createRestClient().post(url, payload);
        },

        /**
         * Sends a DELETE request, ensuring authentication if needed.
         *
         * @async
         * @param {string} [url=""]
         * @param {boolean} [auth=true]
         * @returns {Promise<Object>}
         */
        async delete(url = "", auth = true) {
            await this.preCheck(auth);
            return await this.createRestClient().delete(url);
        },

        /**
         * Creates the REST client instance with the current configuration.
         *
         * @private
         * @returns {import("./fluentRestClient").FluentRESTClient}
         */
        createRestClient() {
            return restClient()
                .useBaseUrl(this.baseUrl)
                .useToken(this.authManager?.token)
                .useUserAgent(`gandalan/weblibs-${this.serviceName}`);
        },

        /**
         * Ensures the user is authenticated before making a request.
         *
         * @private
         * @async
         * @param {boolean} [auth=true]
         * @returns {void}
         */
        async preCheck(auth = true) {
            if (auth && this.authManager) {
                await this.authManager.ensureAuthenticated();
            }
        },

        // Lazy-loaded business routine APIs
        /** @type {VorgangApi} */
        get vorgang() {
            if (!this._vorgangApi) {
                this._vorgangApi = createVorgangApi(this);
            }
            return this._vorgangApi;
        },

        /** @type {KontaktApi} */
        get kontakt() {
            if (!this._kontaktApi) {
                this._kontaktApi = createKontaktApi(this);
            }
            return this._kontaktApi;
        },

        /** @type {BelegPositionenApi} */
        get belegPositionen() {
            if (!this._belegPositionenApi) {
                this._belegPositionenApi = createBelegPositionenApi(this);
            }
            return this._belegPositionenApi;
        },

        /** @type {MaterialApi} */
        get material() {
            if (!this._materialApi) {
                this._materialApi = createMaterialApi(this);
            }
            return this._materialApi;
        },

        /** @type {SerienApi} */
        get serien() {
            if (!this._serienApi) {
                this._serienApi = createSerienApi(this);
            }
            return this._serienApi;
        },

        /** @type {BenutzerApi} */
        get benutzer() {
            if (!this._benutzerApi) {
                this._benutzerApi = createBenutzerApi(this);
            }
            return this._benutzerApi;
        },

        /** @type {ArtikelApi} */
        get artikel() {
            if (!this._artikelApi) {
                this._artikelApi = createArtikelApi(this);
            }
            return this._artikelApi;
        },

        /** @type {BelegApi} */
        get beleg() {
            if (!this._belegApi) {
                this._belegApi = createBelegApi(this);
            }
            return this._belegApi;
        },

        /** @type {ProduktionApi} */
        get produktion() {
            if (!this._produktionApi) {
                this._produktionApi = createProduktionApi(this);
            }
            return this._produktionApi;
        },

        /** @type {FakturaApi} */
        get faktura() {
            if (!this._fakturaApi) {
                this._fakturaApi = createFakturaApi(this);
            }
            return this._fakturaApi;
        },

        /** @type {SettingsApi} */
        get settings() {
            if (!this._settingsApi) {
                this._settingsApi = createSettingsApi(this);
            }
            return this._settingsApi;
        },

        /** @type {UiApi} */
        get ui() {
            if (!this._uiApi) {
                this._uiApi = createUiApi(this);
            }
            return this._uiApi;
        },

        /** @type {UtilityApi} */
        get utility() {
            if (!this._utilityApi) {
                this._utilityApi = createUtilityApi(this);
            }
            return this._utilityApi;
        }
    };
}

/**
 * Sets up a client for API requests.
 *
 * - Requests will be sent to the url provided.
 * - Example usage:
 *   const api = fluentApi("https://jsonplaceholder.typicode.com/todos/", null, "myService");
 *   api.get("1"); // Sends a GET request to https://jsonplaceholder.typicode.com/todos/1.
 *
 * @export
 * @param {string} url - The base URL for API requests.
 * @param {import("./fluentAuthManager").FluentAuthManager} authManager - The authentication manager instance.
 * @param {string} serviceName - The name of the service using this API.
 * @return {FluentApi} Configured API instance for local use.
 */
export function fluentApi(url, authManager, serviceName) {
    return createApi()
        .useAuthManager(authManager)
        .useBaseUrl(url)
        .useServiceName(serviceName);
}
