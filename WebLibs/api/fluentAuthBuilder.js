import { jwtDecode } from "jwt-decode";
import { isTokenValid, getRefreshToken } from "./fluentApi";

/**
 * @typedef {Object} FluentAuth
 * @property {string} authUrl - The authentication URL.
 * @property {string} appToken - The application token.
 * @property {string} token - The JWT token.
 * @property {string} refreshToken - The refresh token.
 * @property {function(string) : FluentAuth} useAppToken - Sets the application token and returns the FluentApi object.
 * @property {function(string) : FluentAuth} useBaseUrl - Sets the base URL for authentication and returns the FluentApi object.
 * @property {function(string|null) : FluentAuth} useToken - Sets the JWT token and returns the FluentApi object.
 * @property {function(string|null) : FluentAuth} useRefreshToken - Sets the refresh token and returns the FluentApi object.
 * @property {Function} authenticate - Authenticates the user with username and password, or refreshes the token.
 * @property {Function} tryRefreshToken - Attempts to refresh the authentication token using the refresh token.
 * @property {Function} redirectToLogin - Redirects to the login page.
 * @property {Function} init - Initializes the authentication object.
 */

/**
 * Builds an authentication object
 *
 * @export
 * @returns {FluentAuth}
 */
export function authBuilder() {
    return {
        authUrl: "",
        appToken: "",
        token: "",
        refreshToken: "",

        /**
         * app token to use for authentication
         *
         * @param {string} [appToken=""]
         * @returns {FluentAuth}
         */
        useAppToken(appToken = "") {
            this.appToken = appToken; return this;
        },

        /**
         * base URL for authentication
         *
         * @param {string} [authUrl=""]
         * @returns {FluentAuth}
         */
        useBaseUrl(authUrl = "") {
            this.authUrl = authUrl; return this;
        },

        /**
         * token to use for authentication
         *
         * @param {string} [jwtToken=""]
         * @returns {FluentAuth}
         */
        useToken(jwtToken = "") {
            this.token = jwtToken; return this;
        },

        /**
         * sets the refresh token to use
         * @param {string} a refresh token (UUID v4 format)
         * @returns {FluentAuth}
         */
        useRefreshToken(storedRefreshToken = "") {
            this.refreshToken = storedRefreshToken; return this;
        },

        /**
         * Authenticates the user with username and password, or refreshes the token.
         *
         * @param {string} username
         * @param {string} password
         * @returns
         */
        async authenticate(username = "", password = "") {
            console.log("authenticating:", this.token ? `token set, exp: ${jwtDecode(this.token).exp - (Date.now() / 1000)}` : "no token,", this.refreshToken, this.appToken);

            if (this.token && isTokenValid(this.token))
                return this.token;

            if (this.token && !this.refreshToken)
                this.refreshToken = getRefreshToken(this.token);

            if (this.refreshToken) {
                try {
                    const temptoken = await this.tryRefreshToken(this.refreshToken);
                    if (temptoken) {
                        this.token = temptoken;
                        this.refreshToken = getRefreshToken(temptoken);
                    }
                } catch {
                    // if refresh failed, we'll return the current token
                    // - should still be valid for a while
                }
                return this.token;
            }

            if (username && password) {
                const payload = { "Email": username, "Password": password, "AppToken": this.appToken };
                const res = await fetch(`${this.authUrl}/LoginJwt`,
                    { method: "POST", body: JSON.stringify(payload), headers: { "Content-Type": "application/json" } });
                const temptoken = await res.json();
                if (temptoken) {
                    this.token = temptoken;
                    return this.token;
                }
            }

            throw new Error("not authenticated");
        },

        /**
         * try to refresh the token using the refresh token
         *
         * @async
         * @private
         * @param {string} [refreshToken=""]
         * @returns {unknown}
         */
        async tryRefreshToken(refreshToken = "") {
            const payload = { "Token": refreshToken };
            const res = await fetch(`${this.authUrl}/LoginJwt/Refresh`,
                {
                    method: "PUT",
                    body: JSON.stringify(payload),
                    headers: { "Content-Type": "application/json" },
                });
            return res.ok ? await res.json() : null;
        },

        async init()
        {
            if (!this.token && this.refreshToken)
            {
                this.token = await this.tryRefreshToken(this.refreshToken);
            }
    
            if (this.token)
            {
                const decoded = jwtDecode(this.token);
                this.refreshToken = ("refreshToken" in decoded) ? decoded["refreshToken"] : null;
                localStorage.setItem("idas-refresh-token", this.refreshToken);
            }

            if (!isTokenValid(this.token))
            {
                this.redirectToLogin();
            }

            globalThis.idasTokens = { token: this.token, refreshToken: this.refreshToken, appToken: this.appToken };
            //await idasApi(appToken).get("/Version"); // Warm up authentication
        },
        
        /**
         * Redirect to the login page
         *
         * @param {string} [authPath=""]
         * @private
         */
        redirectToLogin(authPath = "") {
            if (!window) {
                return;
            }

            const authEndpoint = (new URL(window.location.href).origin) + authPath;
            let authUrlCallback = `${authEndpoint}?r=%target%&j=%jwt%&m=%mandant%`;
            authUrlCallback = authUrlCallback.replace("%target%", encodeURIComponent(window.location.href));

            const url = new URL(this.authUrl);
            url.pathname = "/Session";
            url.search = `?a=${this.appToken}&r=${encodeURIComponent(authUrlCallback)}`;
            let loginUrl = url.toString();

            window.location.href = loginUrl;
        }
    };
}
