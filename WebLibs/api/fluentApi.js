import { jwtDecode } from "jwt-decode";
import { restClient } from "./fluentRestClient";
import { authBuilder } from "./fluentAuthBuilder";

/**
 * @typedef {Object} EnvironmentConfig
 * @property {string} name - The environment name.
 * @property {string} version - The version number.
 * @property {string} cms - The CMS URL.
 * @property {string} idas - The IDAS API URL.
 * @property {string} store - The store API URL.
 * @property {string} docs - The documentation URL.
 * @property {string} notify - The notification service URL.
 * @property {string} feedback - The feedback service URL.
 * @property {string} helpcenter - The help center URL.
 * @property {string} reports - The reports service URL.
 * @property {string} webhookService - The webhook service URL.
 */

/**
 * buffer for environment data
 * @private
 * @type {Object.<string, EnvironmentConfig>}
 */
const envs = {};

/**
 * configure the time before token expiry to renew
 * @type {number}
 */
const JWT_SAFE_RENEWAL = 30; // seconds before token expiry to renew

/**
 * fetches the environment data from the hub
 * @export
 * @async
 * @param {string} [env="", env="dev", env="staging", env="produktiv"]
 * @returns {Promise<EnvironmentConfig>}
 */
export async function fetchEnv(env = "") {
    if (!(env in envs)) {
        const hubUrl = `https://connect.idas-cloudservices.net/api/Endpoints?env=${env}`;
        console.log("fetching env", hubUrl);
        const r = await fetch(hubUrl);
        const data = await r.json();
        envs[env] = data;
    }
    return envs[env];
}

/** 
 * @typedef {Object} JwtTokenExt
 * @property {string} id
 * @property {string} refreshToken
*/

/**
 * decode the JWT token and return the refresh token
 * @export
 * @param {string} token
 * @returns {string}
 */
export function getRefreshToken(token) {
    const decoded = /** @type {JwtTokenExt} */(jwtDecode(token));
    return decoded.refreshToken;
}

/**
 * check if the token is still valid
 * - checks the expiry date and the JWT_SAFE_RENEWAL buffer
 * 
 *  @export
 * @param {string} token
 * @returns {boolean}
 */
export function isTokenValid(token) 
{
    try
    {
        const decoded = jwtDecode(token);
        if (!decoded || !decoded.exp) 
            throw new Error("Invalid token");
        return (decoded.exp - JWT_SAFE_RENEWAL > Date.now() / 1000);
    }
    catch {
        return false;
    }
}

/**
 * @typedef {Object} FluentApi
 * @property {string} baseUrl - The base URL for API requests.
 * @property {string} authUrl - The authentication URL.
 * @property {string} env - The environment setting.
 * @property {string} appToken - The application token.
 * @property {string} storageEntry - The storage entry.
 * @property {string} token - The JWT token for authorization.
 * @property {string} refreshToken - The refresh token.
 * @property {function(string) : FluentApi} useEnvironment - Sets the environment and returns the FluentApi object.
 * @property {function(string) : FluentApi} useAppToken - Sets the application token and returns the FluentApi object.
 * @property {function(string) : FluentApi} useBaseUrl - Sets the base URL for API requests and returns the FluentApi object.
 * @property {function(string) : FluentApi} useAuthUrl - Sets the authentication URL and returns the FluentApi object.
 * @property {function(string) : FluentApi} useToken - Sets the JWT token for authorization and returns the FluentApi object.
 * @property {function(string) : FluentApi} useRefreshToken - Sets the refresh token and returns the FluentApi object.
 * @property {function() : FluentApi} useGlobalAuth - Uses global authentication tokens and returns the FluentApi object.
 * @property {function(string) : object|Array<any>} get - Async function to perform GET requests.
 * @property {function(string, object) : object|Array<any>} put - Async function to perform PUT requests with a payload.
 * @property {function(string, object) : object|Array<any>} post - Async function to perform POST requests with a payload.
 * @property {function(string) : object|Array<any>} delete - Async function to perform DELETE requests.
 * @property {Function} ensureAuthenticated - Ensures the user is authenticated before making a request.
 * @property {Function} ensureBaseUrlIsSet - Ensures the base URL is set before making a request.
 * @property {Function} redirectToLogin - Redirects to the login page.
 */

/**
 * Builds a client to communicate with the IDAS api in a fluent syntax
 * 
 * @return {FluentApi}
 */
export function createApi() {
    return {
        baseUrl: "",
        authUrl: "",
        env: "",
        appToken: "",
        storageEntry: "",
        token: "",
        refreshToken: "",

        /**
         * set the environment to use
         * 
         * @param {string} env 
         * @return {FluentApi}
         */
        useEnvironment(env = "") {
            this.env = env; return this;
        },

        /**
         * set the app token to use
         *
         * @param {string} [newApptoken=""]
         * @return {FluentApi}
         */
        useAppToken(newApptoken = "") {
            this.appToken = newApptoken; return this;
        },

        /**
         * set the base URL for API requests
         *
         * @param {string} [url=""]
         * @return {FluentApi}
         */
        useBaseUrl(url = "") {
            this.baseUrl = url; return this;
        },

        /**
         * set the authentication URL
         *
         * @param {string} [url=""]
         * @return {FluentApi}
         */
        useAuthUrl(url = "") {
            this.authUrl = url; return this;
        },

        /**
         * set the JWT token for authorization
         *
         * @param {string} [jwtToken=""]
         * @return {FluentApi}
         */
        useToken(jwtToken = "") {
            this.token = jwtToken; return this;
        },

        /**
         * set the refresh token
         *
         * @param {string} [storedRefreshToken=""]
         * @return {FluentApi}
         */
        useRefreshToken(storedRefreshToken = "") {
            this.refreshToken = storedRefreshToken; return this;
        },
        
        /**
         * tell the client to use the global authentication tokens
         *
         * @return {FluentApi}
         */
        useGlobalAuth() {
            // eslint-disable-next-line no-undef 
            this.token = globalThis.idasTokens.token; 
            // eslint-disable-next-line no-undef
            this.refreshToken = globalThis.idasTokens.refreshToken; 
            // eslint-disable-next-line no-undef
            this.appToken = globalThis.idasTokens.appToken;
            return this;
        },
        
        /**
         * GET request, ensure authenticated if needed
         *
         * @async
         * @param {string} [url=""]
         * @param {boolean} [auth=true]
         * @returns {Promise<Object>}
         */
        async get(url = "", auth = true) {
            if (auth) 
                await this.ensureAuthenticated();
            return restClient().useBaseUrl(this.baseUrl).useToken(this.token).get(url);
        },

        /**
         * PUT request, ensure authenticated if needed
         *
         * @async
         * @param {string} [url=""]
         * @param {Object} [payload={}]
         * @param {boolean} [auth=true]
         * @returns {Promise<Object>}
         */
        async put(url = "", payload = {}, auth = true) {
            if (auth) 
                await this.ensureAuthenticated();
            return restClient().useBaseUrl(this.baseUrl).useToken(this.token).put(url, payload);
        },

        /**
         * POST request, ensure authenticated if needed
         *
         * @async
         * @param {string} [url=""]
         * @param {Object} [payload={}]
         * @param {boolean} [auth=true]
         * @returns {Promise<Object>}
         */
        async post(url = "", payload = {}, auth = true) {
            if (auth) 
                await this.ensureAuthenticated();
            return restClient().useBaseUrl(this.baseUrl).useToken(this.token).post(url, payload);
        },
        
        /**
         * DELETE request, ensure authenticated if needed
         *
         * @async
         * @param {string} [url=""]
         * @param {boolean} [auth=true]
         * @returns {Promise<Object>}
         */
        async delete(url = "", auth = true) {
            if (auth) 
                await this.ensureAuthenticated();
            return restClient().useBaseUrl(this.baseUrl).useToken(this.token).delete(url);
        },

        /**
         * Ensure the user is authenticated before making a request
         *
         * @async
         * @private
         */
        async ensureAuthenticated() {
            if (this.token && isTokenValid(this.token))
                return;

            await this.ensureBaseUrlIsSet();

            try {
                const temptoken = await authBuilder()
                    .useAppToken(this.appToken)
                    .useBaseUrl(this.authUrl)
                    .useToken(this.token)
                    .useRefreshToken(this.refreshToken)
                    .authenticate() || "";

                if (!temptoken) {
                    throw new Error("not authenticated");
                }

                this.token = temptoken;
                this.refreshToken = getRefreshToken(temptoken);
                // eslint-disable-next-line no-undef
                globalThis.idasTokens.token = this.token;
                // eslint-disable-next-line no-undef
                globalThis.idasTokens.refreshToken = this.refreshToken;
                localStorage.setItem("idas-refresh-token", this.refreshToken);
            } catch (e) {
                //this.redirectToLogin();
                console.error("not authenticated", e);
            }
        },
        
        /**
         * Ensure the base URL is set before making a request. If not set, 
         * retrieve the environment data and set the base URL.
         *
         * @async
         * @private
         */
        async ensureBaseUrlIsSet() {
            if (this.env && (!this.baseUrl || !this.authUrl)) {
                const envInfo = await fetchEnv(this.env);
                this.baseUrl = this.baseUrl || envInfo.idas;
                this.authUrl = this.authUrl || envInfo.idas;
                console.log("envInfo", envInfo);
            }

            if (!this.baseUrl) {
                throw new Error("apiBaseurl not set");
            }

            if (!this.authUrl) {
                throw new Error("authUrl not set");
            }
        }
    };
}

/**
 * Default setup for IDAS
 *
 * @export
 * @param {string} [appToken=""]
 * @return {FluentApi}
 */
export function idasApi(appToken = "") {
    return createApi()
        .useGlobalAuth()
        .useAppToken(appToken)
        .useEnvironment("dev");
}

/**
 * Default setup for local API
 *
 * @export
 * @return {FluentApi}
 */
export function localApi() {
    return createApi()
        .useGlobalAuth()
        .useBaseUrl("/api")
        .useEnvironment("dev");
}
