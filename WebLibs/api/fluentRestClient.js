/**
 * @typedef {Object} FluentRESTClient
 * @property {string} baseUrl - The base URL for API requests.
 * @property {string} token - The JWT token for authorization.
 * @property {function(string) : FluentRESTClient} useBaseUrl - Function to set the base URL and return the FluentApi object.
 * @property {function(string) : FluentRESTClient} useToken - Function to set the JWT token and return the FluentApi object.
 * @property {function(string) : FluentRESTClient} useUserAgent - Function to set the user agent and return the FluentApi object.
 * @property {function(string) : object|Array<any>} get - Async function to perform GET requests.
 * @property {function(string, object) : object|Array<any>} put - Async function to perform PUT requests with a payload.
 * @property {function(string, object|FormData) : object|Array<any>} post - Async function to perform POST requests with a payload.
 * @property {function(string) : object|Array<any>} delete - Async function to perform DELETE requests.
 */

/**
 * Creates a REST client object with fluent API for making HTTP requests.
 * @returns {FluentRESTClient} The REST client object.
 */
export function restClient() {
    return {
        baseUrl: "",
        token: "",
        userAgent: "",

        /**
         * set the base URL for all requests
         *
         * @param {string} url to use as base URL
         * @returns {FluentRESTClient}
         */
        useBaseUrl(url = "") {
            this.baseUrl = url; return this;
        },

        /**
         * set the JWT token for authorization
         *
         * @param {string} [jwtToken=""]
         * @returns {FluentRESTClient}
         */
        useToken(jwtToken = "") {
            this.token = jwtToken; return this;
        },

        /**
         * set the user agent for all requests
         *
         * @param {string} [userAgent=""]
         * @returns {FluentRESTClient}
         */
        useUserAgent(userAgent = "") {
            this.userAgent = userAgent; return this;
        },

        /**
         * GET request to the specified URL
         *
         * @async
         * @param {string} [url=""]
         * @param {boolean} [auth=true]
         * @returns {Promise<any>}
         */
        async get(url = "", auth = true) {
            const finalUrl = `${this.baseUrl}${url}`;
            const headers = this._createHeaders();
            const res = await fetch(finalUrl, { method: "GET", headers });
            if (res.ok) {
                return await this._parseReponse(res);
            }

            throw new Error(`GET ${finalUrl} failed: ${res.status} ${res.statusText}`);
        },

        /**
         * PUT request to the specified URL
         *
         * @async
         * @param {string} [url=""]
         * @param {Object} [payload={}]
         * @returns {Promise<any>}
         */
        async put(url = "", payload = {}) {
            const finalUrl = `${this.baseUrl}${url}`;
            const headers = this._createHeaders("application/json");
            const res = await fetch(finalUrl, { method: "PUT", body: JSON.stringify(payload), headers });
            if (res.ok) {
                return await this._parseReponse(res);
            }

            throw new Error(`PUT ${finalUrl} failed: ${res.status} ${res.statusText}`);
        },

        /**
         * POST request to the specified URL
         *
         * @async
         * @param {string} [url=""]
         * @param {Object|FormData} [payload={}]
         * @returns {Promise<any>}
         */
        async post(url = "", payload = {}) {
            const finalUrl = `${this.baseUrl}${url}`;
            let headers;

            // Determine the body and headers based on the payload type
            let body;
            if (payload instanceof FormData) {
                headers = this._createHeaders();
                body = payload;
            } else {
                headers = this._createHeaders("application/json");
                body = JSON.stringify(payload);
            }

            const res = await fetch(finalUrl, { method: "POST", body, headers });
            if (res.ok) {
                return await this._parseReponse(res);
            }

            throw new Error(`POST ${finalUrl} failed: ${res.status} ${res.statusText}`);
        },

        /**
         * DELETE request to the specified URL
         *
         * @async
         * @param {string} [url=""]
         * @returns {Promise<any>}
         */
        async delete(url = "") {
            const finalUrl = `${this.baseUrl}${url}`;
            const headers = this._createHeaders();
            const res = await fetch(finalUrl, { method: "DELETE", headers });
            if (res.ok) {
                return await this._parseReponse(res);
            }

            throw new Error(`DELETE ${finalUrl} failed: ${res.status} ${res.statusText}`);
        },

        _createHeaders(contentType) {
            return new Headers({
                ...(contentType && { "Content-Type": contentType }),
                ...(this.token && { "Authorization": `Bearer ${this.token}` }),
                ...(this.userAgent && { "User-Agent": this.userAgent }),
                // X-User-Agent: workaround for Chromium bug https://issues.chromium.org/issues/40450316
                ...(this.userAgent && { "X-User-Agent": this.userAgent })

            });
        },

        async _parseReponse(res) {
            // check if repsonse is JSON, then return parsed JSON, otherwise return text
            const contentType = res.headers.get("content-type");
            if (contentType) {
                if (contentType.includes("application/json")) {
                    return await res.json();
                }

                const blobTypes = ["pdf", "zip", "octet-stream"];
                if (contentType.includes("image") ||
                    blobTypes.some(type => contentType.includes(`application/${type}`))) {
                    return await res.blob();
                }
            }

            return await res.text();
        }
    };
}
