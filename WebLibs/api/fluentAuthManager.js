import { jwtDecode } from "jwt-decode";
import validator from "validator";
import { popRefreshTokenFromUrl } from "./fluentAuthUtils";

/**
 * @typedef {Object} FluentAuthManager
 * @property {string} appToken - The application token.
 * @property {string} authUrl - The authentication URL.
 * @property {string} token - The JWT token for authorization.
 * @property {string} refreshToken - The refresh token.
 * @property {object} userInfo - The user information.
 * @property {function(string) : FluentAuthManager} useAppToken - Sets the application token and returns the FluentApi object.
 * @property {function(string) : FluentAuthManager} useBaseUrl - Sets the base URL for authentication and returns the FluentApi object.
 * @property {function(string|null) : FluentAuthManager} useToken - Sets the JWT token and returns the FluentApi object. Only intended for usage with Service Tokens.
 * @property {function(string|null) : FluentAuthManager} useRefreshToken - Sets the refresh token and returns the FluentApi object.
 * @property {function} ensureAuthenticated - Ensures the user is authenticated before making a request.
 * @property {function() : string} authenticate - Authenticates the user with username and password, or refreshes the token.
 * @property {function():Promise<FluentAuthManager|null>} init - Returns promise for authManager. Returns null if not authenticated.
 * @property {function(string,string) : string} login - Logs in with the provided credentials.
 * @property {function} tryRefreshToken - Attempts to refresh the authentication token using the refresh token.
 * @property {function} updateUserSession - Updates the user session with the new token.
 * @property {function} redirectToLogin - Redirects to the login page.
 * @property {function(string) : boolean} hasRight - Checks if the user has the specific right.
 * @property {function(string) : boolean} hasRole - Checks if the user has the specific role.
 */

/**
 * Creates a new FluentAuthManager
*
 * @export
 * @returns {FluentAuthManager}
 */
export function createAuthManager() {
    return {
        appToken: "",
        authUrl: "",
        token: "",
        refreshToken: "",
        userInfo: {},

        /**
         * app token to use for authentication
         *
         * @param {string} [appToken=""]
         * @returns {FluentAuthManager}
         */
        useAppToken(appToken = "") {
            if (!validator.isUUID(appToken)) {
                console.error("AppToken is not valid GUID");
                return null;
            }
            this.appToken = appToken;
            return this;
        },

        /**
         * set the authentication URL
         *
         * @param {string} [url=""]
         * @return {FluentAuthManager}
         */
        useBaseUrl(url = "") {
            this.authUrl = url;
            return this;
        },

        /**
         * set the JWT token for authorization
         *
         * @param {string} [jwtToken=""]
         * @return {FluentAuthManager}
         */
        useToken(jwtToken = "") {
            this.token = jwtToken;
            return this;
        },

        /**
         * set the refresh token
         *
         * @param {string} [storedRefreshToken=""]
         * @return {FluentAuthManager}
         */
        useRefreshToken(storedRefreshToken = "") {
            this.refreshToken = storedRefreshToken;
            return this;
        },

        /**
         * Ensure the user is authenticated before making a request
         *
         * @async
         * @private
         */
        async ensureAuthenticated() {
            if (this.token && isTokenValid(this.token)) {
                return;
            }

            try {
                await this.authenticate();
            } catch (e) {
                // no redirect to login, because we're in a request
                console.error("not authenticated", e);
            }
        },

        /**
         * Authenticates the user with the JWT token or refreshes the token with
         * the refreshToken set before.
         *
         * @throws {Error} if JWT token and refreshToken are not set or both are invalid
         * @return {string} the JWT token
         */
        async authenticate() { // benutzt bei existierendem JWT oder RefreshToken, wenn keins vorhanden ERROR
            console.log("authenticating:", this.token ? `token set, exp: ${jwtDecode(this.token).exp - (Date.now() / 1000)}` : "no token,", this.refreshToken, this.appToken);

            if (this.token && isTokenValid(this.token)) {
                return;
            }

            if (this.token && !this.refreshToken) {
                this.refreshToken = getRefreshToken(this.token);
            }

            if (!this.refreshToken) {
                throw new Error("not authenticated");
            }

            try {
                const temptoken = await this.tryRefreshToken(this.refreshToken);
                this.updateUserSession(temptoken);
            } catch {
                // if refresh failed
                // - current token should still be valid for a while
                // - or user has invalid (refresh) token and needs to login/refresh manually
            }
        },

        /**
         * Initializes the authentication object. Before calling, set the token and refresh token if available.
         * If the token is not set, the refresh token will be used to try to refresh the token.
         * If the token is not valid, the user will be redirected to the login page.
         * If tokens are valid, they will be stored in this instance of the FluentAuthManager.
         *
         * Side effect if refreshToken is not set: tries to get the refreshToken from the URL or localStorage.
         *
         * @async
         * @return {Promise<FluentAuthManager> | null} the FluentAuthManager or null if not authenticated
         */
        async init() {
            if (!this.refreshToken) {
                this.refreshToken = popRefreshTokenFromUrl() || localStorage.getItem("idas-refresh-token");
            }

            if (!this.token && this.refreshToken) {
                this.token = await this.tryRefreshToken(this.refreshToken);
            }

            if (this.token && isTokenValid(this.token)) {
                this.updateUserSession(this.token);
                return this;
            }

            if (!isTokenValid(this.token)) {
                this.redirectToLogin();
                throw "Redirect to login...";
            }

            return this;
        },

        /**
         * Login with credentials and return the JWT token
         * @param {string} username
         * @param {string} password
         * @return {string} the JWT token
         */
        async login(username = "", password = "") {
            if (username && password) {
                const payload = { "Email": username, "Password": password, "AppToken": this.appToken };
                const res = await fetch(`${this.authUrl}/LoginJwt`,
                    { method: "POST", body: JSON.stringify(payload), headers: { "Content-Type": "application/json" } });
                this.updateUserSession((await res.json()));
                return;
            }

            throw new Error("not authenticated");
        },

        /**
         * try to refresh the JWT token by using the refreshToken
         * @async
         * @private
         * @param {string} [refreshToken=""]
         * @returns {unknown}
         */
        async tryRefreshToken(refreshToken = "") {
            const payload = { "Token": refreshToken };
            const res = await fetch(`${this.authUrl}LoginJwt/Refresh`,
                {
                    method: "PUT",
                    body: JSON.stringify(payload),
                    headers: { "Content-Type": "application/json" },
                });
            return res.ok ? await res.json() : null;
        },

        /**
         * check if the user has the specific right
         * @param {string} code
         * @returns {boolean}
         */
        hasRight(code) {
            return (this.userInfo?.rights || []).includes(code);
        },

        /**
         * check if the user has the specific role
         * @param {string} code
         * @returns {boolean}
         */
        hasRole(code) {
            return (this.userInfo?.role || []).includes(code);
        },

        /**
         * update the user session with the new token
         * @private
         * @param {string} token
         * @returns {void}
         */
        updateUserSession(token) {
            if (token) {
                this.token = token;
                this.refreshToken = getRefreshToken(token);
                this.userInfo = jwtDecode(this.token);
                localStorage.setItem("idas-refresh-token", this.refreshToken);
            }
        },

        /**
         * Redirect to the login page
         * @private
         */
        redirectToLogin() {
            if (!window) {
                return;
            }

            const redirectAfterAuth = new URL(window.location.href).origin;
            let redirectUrl = `${redirectAfterAuth}?t=%token%`;
            const url = new URL(this.authUrl);
            url.pathname = "/Session";
            url.search = `?a=${this.appToken}&r=${encodeURIComponent(redirectUrl)}`;
            let loginUrl = url.toString();
            window.location.href = loginUrl;
        }
    };
}

/**
 * configure the time before token expiry to renew
 * @type {number}
 */
const JWT_SAFE_RENEWAL = 30; // seconds before token expiry to renew

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
 * @export
 * @param {string} token
 * @returns {boolean}
 */
export function isTokenValid(token) {
    try {
        const decoded = jwtDecode(token);
        if (!decoded || !decoded.exp) {
            throw new Error("Invalid token");
        }

        return (decoded.exp - JWT_SAFE_RENEWAL > Date.now() / 1000);
    }
    catch {
        return false;
    }
}

/**
 * create a new FluentAuthManager with the provided tokens
 * @export
 * @param {string} appToken
 * @param {string} authBaseUrl
 * @returns {FluentAuthManager}
 */
export function fluentIdasAuthManager(appToken, authBaseUrl) {
    return createAuthManager()
        .useAppToken(appToken)
        .useBaseUrl(authBaseUrl)
}
