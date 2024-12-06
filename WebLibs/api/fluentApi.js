import { EnvironmentConfig } from "./envUtils";
import { FluentAuthManager } from "./fluentAuthManager";
import { FluentRestClient, restClient } from "./fluentRestClient";

/**
 * @typedef {Object} FluentApi
 * @property {string} baseUrl - The base URL for API requests.
 * @property {FluentAuthManager} authManager - The authentication manager.
 * @property {function(string) : FluentApi} useBaseUrl - Sets the base URL for API requests and returns the FluentApi object.
 * @property {function(FluentAuthManager) : FluentApi} useAuthManager - Sets the auth manager and returns the FluentApi object.
 * @property {function(string) : object|Array<any>} get - Async function to perform GET requests.
 * @property {function(string, object|null) : object|Array<any>} put - Async function to perform PUT requests with a payload.
 * @property {function(string, object|null) : object|Array<any>} post - Async function to perform POST requests with a payload.
 * @property {function(string) : object|Array<any>} delete - Async function to perform DELETE requests.
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
     * @returns {FluentRestClient}
     */
    createRestClient() {
      return restClient().useBaseUrl(this.baseUrl).useToken(this.authManager?.token);
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
      if (auth) {
        await this.authManager.ensureAuthenticated();
      }
    }
  };
}

/**
 * Default setup for IDAS
 *
 * @export
 * @param {EnvironmentConfig} [env={}]
 * @param {FluentAuthManager} [authManager={}]
 * @return {FluentApi}
 */
export function idasApi(env, authManager) {
  return createApi()
    .useAuthManager(authManager)
    .useBaseUrl(env.idas);
}

/**
 * Sets up a default API configuration for local requests.
 *
 * - Requests will be sent to the "/api/" endpoint of the current domain (e.g., http://example.com/api/).
 * - Example usage:
 *   const api = localApi(authManager);
 *   api.get("users"); // Sends a GET request to http://example.com/api/users.
 *
 * @export
 * @param {FluentAuthManager} authManager - The authentication manager instance.
 * @return {FluentApi} Configured API instance for local use.
 */
export function localApi(authManager) {
  return createApi()
    .useAuthManager(authManager)
    .useBaseUrl("/api/");
}
