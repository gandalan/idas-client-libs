import { jwtDecode } from "jwt-decode";
import validator from "validator";
import { popRefreshTokenFromUrl } from "./fluentAuthUtils";
import { AUTH_EXPIRED_EVENT, AUTH_REFRESHED_EVENT, dispatchAuthEvent } from "./authEvents";

/**
 * Decoded JWT claims used by this auth manager.
 *
 * @typedef {Object} JwtUserInfo
 * @property {string|string[]} [rights]
 * @property {string|string[]} [role]
 */

/**
 * @typedef {Object} FluentAuthManager
 * @property {string} appToken - The application token.
 * @property {string} authUrl - The authentication URL.
 * @property {string} token - The JWT token for authorization (accessor, shared by every proxy/wrapper of this instance).
 * @property {string} refreshToken - The refresh token (accessor, shared by every proxy/wrapper of this instance).
 * @property {JwtUserInfo} userInfo - Decoded JWT claims for role/right checks (accessor, shared by every proxy/wrapper of this instance).
 * @property {(appToken?: string) => FluentAuthManager|null} useAppToken - Sets the application token and returns the FluentApi object.
 * @property {(url?: string) => FluentAuthManager} useBaseUrl - Sets the base URL for authentication and returns the FluentApi object.
 * @property {(jwtToken?: string|null) => FluentAuthManager} useToken - Sets the JWT token and returns the FluentApi object. Only intended for usage with Service Tokens.
 * @property {(storedRefreshToken?: string|null) => FluentAuthManager} useRefreshToken - Sets the refresh token and returns the FluentApi object.
 * @property {() => Promise<void>} ensureAuthenticated - Ensures the user is authenticated before making a request.
 * @property {() => Promise<void>} authenticate - Authenticates the user with username and password, or refreshes the token.
 * @property {(force?: boolean) => Promise<void>} _doAuthenticate - Performs the actual token refresh (single-flight worker behind authenticate).
 * @property {Promise<void>|null} _authenticatePromise - In-flight authentication promise shared by concurrent callers (read-only).
 * @property {() => Promise<FluentAuthManager>} init - Returns promise for authManager.
 * @property {(username?: string, password?: string) => Promise<void>} login - Logs in with the provided credentials.
 * @property {(refreshToken?: string) => Promise<string|null>} tryRefreshToken - Attempts to refresh the authentication token using the refresh token.
 * @property {(token: string|null) => void} updateUserSession - Updates the user session with the new token.
 * @property {() => void} redirectToLogin - Redirects to the login page.
 * @property {(code: string) => boolean} hasRight - Checks if the user has the specific right.
 * @property {(code: string) => boolean} hasRole - Checks if the user has the specific role.
 * @property {(force?: boolean, notifyExpired?: boolean) => Promise<void>} [_runRefresh] - Single-flight entry for (forced) refreshes; each caller decides about AUTH_EXPIRED_EVENT itself.
 * @property {(force: boolean) => Promise<void>} [_refreshLocked] - Refresh step executed while holding the cross-tab lock.
 * @property {() => string|null} [_currentRefreshToken] - Picks the refresh token to send (own or newer one from localStorage).
 * @property {(refreshToken: string) => Promise<{token: string|null, status: number}>} [_requestRefresh] - Calls LoginJwt/Refresh and reports the HTTP status.
 * @property {(reason: string, rejectedRefreshToken?: string|null) => void} [_expire] - Ends the session for good (clears tokens, stops the timer).
 * @property {(reason: string) => void} [_notifyExpired] - Dispatches AUTH_EXPIRED_EVENT once per expiry.
 * @property {(delay?: number) => void} [_scheduleProactiveRefresh] - (Re)starts the proactive refresh timer for the current JWT.
 * @property {() => void} [_stopProactiveRefresh] - Stops the proactive refresh timer.
 * @property {() => void} [_proactiveRefresh] - Timer callback: refreshes ahead of expiry if the document is visible.
 * @property {() => void} [_installBrowserListeners] - Registers storage/visibilitychange listeners once.
 */

/**
 * Creates a new FluentAuthManager
 *
 * All session state (tokens, user info, refresh timer, single-flight
 * promise, expiry flag, …) lives in this closure and not as plain data
 * properties on the returned object. `token`, `refreshToken` and `userInfo`
 * are accessors onto that state. This way every wrapper of the instance —
 * in particular a deep reactive proxy such as Svelte 5 `$state`, whose
 * set trap would otherwise keep writes to data properties inside the proxy —
 * shares one session: one refresh chain, one timer, one listener set and one
 * AUTH_EXPIRED_EVENT per expiry.
 *
 * @export
 * @returns {FluentAuthManager}
 */
export function createAuthManager() {
    const session = {
        token: "",
        refreshToken: "",
        /** @type {JwtUserInfo} */
        userInfo: {},
    };

    const internal = {
        /** @type {Promise<void>|null} */
        authenticatePromise: null,
        /** AUTH_EXPIRED_EVENT was dispatched and no login/refresh succeeded since */
        expired: false,
        /** a login/refresh succeeded at least once */
        sessionStarted: false,
        /** identity (user + mandant) of the current session, null if unknown */
        identity: /** @type {string|null} */ (null),
        /** refresh tokens the server rejected; never sent again */
        rejectedRefreshTokens: /** @type {Set<string>} */ (new Set()),
        /** last value of localStorage["idas-refresh-token"] written or adopted */
        storedRefreshTokenSeen: /** @type {string|null} */ (null),
        /** @type {ReturnType<typeof setTimeout>|null} */
        refreshTimer: null,
        /** JWT the proactive timer was scheduled for */
        scheduledToken: "",
        /** wall-clock time (ms) from which the proactive refresh is due, 0 = none */
        refreshDueAt: 0,
        /** wall-clock time (ms) of the last proactive refresh attempt */
        lastProactiveRefreshAt: 0,
        refreshDueWhileHidden: false,
        browserListenersInstalled: false,
    };

    /** @type {FluentAuthManager} */
    const self = {
        appToken: "",
        authUrl: "",

        get token() { return session.token; },
        set token(value) { session.token = value; },
        get refreshToken() { return session.refreshToken; },
        set refreshToken(value) { session.refreshToken = value; },
        get userInfo() { return session.userInfo; },
        set userInfo(value) { session.userInfo = value; },
        get _authenticatePromise() { return internal.authenticatePromise; },

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
            session.token = jwtToken;
            return this;
        },

        /**
         * set the refresh token
         *
         * @param {string} [storedRefreshToken=""]
         * @return {FluentAuthManager}
         */
        useRefreshToken(storedRefreshToken = "") {
            session.refreshToken = storedRefreshToken;
            return this;
        },

        /**
         * Ensure the user is authenticated before making a request
         *
         * @async
         * @private
         */
        async ensureAuthenticated() {
            if (session.token && isTokenValid(session.token)) {
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
         * Single-flight: concurrent callers (e.g. parallel requests firing after
         * the token expired) share one refresh instead of racing each other with
         * the same refresh token — with token rotation only the first refresh
         * would succeed and all others would end up with a 401. Across tabs and
         * auth manager instances the refresh is additionally serialized with the
         * Web Locks API (see _doAuthenticate).
         *
         * @throws {Error} if JWT token and refreshToken are not set or both are invalid
         * @return {Promise<void>}
         */
        async authenticate() { // benutzt bei existierendem JWT oder RefreshToken, wenn keins vorhanden ERROR
            if (session.token && isTokenValid(session.token)) {
                return;
            }

            return this._runRefresh();
        },

        /**
         * Single-flight entry point for refreshes (regular and proactive).
         * The shared refresh never dispatches AUTH_EXPIRED_EVENT itself; every
         * caller decides on its own after the shared promise settled, so a
         * caller that does not want the event (init) cannot suppress it for a
         * parallel request.
         *
         * @private
         * @param {boolean} [force=false] - refresh even if the JWT is still valid (proactive refresh)
         * @param {boolean} [notifyExpired=true] - dispatch AUTH_EXPIRED_EVENT if the session ended
         * @return {Promise<void>}
         */
        _runRefresh(force = false, notifyExpired = true) {
            internal.authenticatePromise ??= this._doAuthenticate(force)
                .finally(() => { internal.authenticatePromise = null; });

            return internal.authenticatePromise.catch((e) => {
                if (notifyExpired && e?.sessionEnded) {
                    this._notifyExpired(e.code);
                }
                throw e;
            });
        },

        /**
         * Performs the actual authentication/refresh. Never call directly —
         * always go through authenticate(), which ensures only one refresh
         * runs at a time.
         *
         * - Serialized across tabs via `navigator.locks` ("idas-refresh") where
         *   available, otherwise only the in-instance single-flight applies.
         * - Once the session expired for good, no further refresh request is
         *   sent — unless localStorage holds a refresh token that was not
         *   rejected yet (e.g. login in another tab).
         *
         * @private
         * @param {boolean} [force=false] - refresh even if the JWT is still valid
         * @throws {Error} if JWT token and refreshToken are not set or both are invalid;
         *   `code` names the reason, `sessionEnded` is true if a running session ended
         * @return {Promise<void>}
         */
        async _doAuthenticate(force = false) {
            if (!force && session.token && isTokenValid(session.token)) {
                return;
            }

            console.log("authenticating:", session.token ? `token set, exp: ${Math.round(((getTokenExpiresAt(session.token) ?? 0) - Date.now()) / 1000)}s` : "no token", session.refreshToken ? "refresh token set" : "no refresh token");

            if (session.token && !session.refreshToken) {
                session.refreshToken = tryGetRefreshToken(session.token) ?? "";
            }

            if (!this._currentRefreshToken()) {
                const sessionEnded = Boolean(session.token) || internal.sessionStarted;
                if (sessionEnded) {
                    this._expire("no-refresh-token");
                }
                throw authError("no-refresh-token", sessionEnded);
            }

            await withRefreshLock(() => this._refreshLocked(force));
        },

        /**
         * Refresh step running inside the cross-tab lock. Re-reads
         * localStorage first: if another tab/instance rotated the refresh
         * token meanwhile, its token is used instead of our (consumed) one.
         * A rejected refresh (any 4xx except 408/429) is retried exactly once
         * if localStorage then holds a different token; otherwise the session
         * expires. Other failures (network, timeout, 408/429, 5xx) keep the
         * refresh token for a later try.
         *
         * A token obtained with a refresh token taken over from localStorage
         * may belong to another user or mandant (login in another tab). It is
         * only adopted if the identity matches the running session; otherwise
         * the session ends with "identity-changed" (the new refresh token is
         * left in localStorage for the tab it belongs to).
         *
         * @private
         * @param {boolean} force
         * @return {Promise<void>}
         */
        async _refreshLocked(force) {
            if (!force && session.token && isTokenValid(session.token)) {
                return;
            }

            let candidate = this._currentRefreshToken();
            let lastRejected = null;
            for (let attempt = 0; candidate && attempt < 2; attempt++) {
                const { token, status } = await this._requestRefresh(candidate);
                if (token) {
                    if (internal.identity && getIdentity(token) !== internal.identity) {
                        const newRefreshToken = tryGetRefreshToken(token);
                        if (newRefreshToken) {
                            writeStoredRefreshToken(newRefreshToken);
                            internal.storedRefreshTokenSeen = newRefreshToken;
                        }
                        this._expire("identity-changed");
                        throw authError("identity-changed", true);
                    }

                    this.updateUserSession(token);
                    return;
                }

                if (!isRejectionStatus(status)) {
                    throw authError("refresh-failed", false, `token refresh failed: ${status}`, status);
                }

                internal.rejectedRefreshTokens.add(candidate);
                lastRejected = candidate;
                // another tab/instance may have rotated the token in the meantime
                const stored = readStoredRefreshToken();
                candidate = stored && !internal.rejectedRefreshTokens.has(stored) ? stored : null;
            }

            // a rejected refresh token is dead for good, even without a prior session
            const sessionEnded = Boolean(lastRejected) || Boolean(session.token) || internal.sessionStarted;
            this._expire("refresh-rejected", lastRejected);
            throw authError("refresh-rejected", sessionEnded);
        },

        /**
         * Picks the refresh token to send: a token in localStorage that changed
         * since this instance last wrote/adopted it (rotated by another tab or
         * instance, or a new login) wins over the own one. Rejected tokens are
         * never returned.
         *
         * @private
         * @return {string|null}
         */
        _currentRefreshToken() {
            const rejected = internal.rejectedRefreshTokens;
            const stored = readStoredRefreshToken();
            if (stored && stored !== session.refreshToken && stored !== internal.storedRefreshTokenSeen && !rejected.has(stored)) {
                session.refreshToken = stored;
                internal.storedRefreshTokenSeen = stored;
            }

            return session.refreshToken && !rejected.has(session.refreshToken) ? session.refreshToken : null;
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
         * @throws {Error} network/server errors of the refresh (no redirect, the session may still be valid)
         * @return {Promise<FluentAuthManager>} the FluentAuthManager
         */
        async init() {
            internal.storedRefreshTokenSeen = readStoredRefreshToken();
            if (!session.refreshToken) {
                session.refreshToken = popRefreshTokenFromUrl() || internal.storedRefreshTokenSeen;
            }

            let refreshed = false;
            if (!session.token && session.refreshToken) {
                try {
                    // no AUTH_EXPIRED_EVENT from this call: init redirects to login itself
                    await this._runRefresh(false, false);
                    refreshed = true;
                } catch (e) {
                    // only a rejected/missing token leads to the login page;
                    // network errors and 5xx must not log the user out
                    if (!e?.code || !SESSION_END_CODES.includes(e.code)) {
                        throw e;
                    }
                }
            }

            if (session.token && isTokenValid(session.token)) {
                if (!refreshed) {
                    this.updateUserSession(session.token);
                }
                return this;
            }

            if (!isTokenValid(session.token)) {
                this.redirectToLogin();
                throw "Redirect to login...";
            }

            return this;
        },

        /**
         * Login with credentials and return the JWT token
         * @param {string} username
         * @param {string} password
         * @return {Promise<void>}
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
         * @returns {Promise<string|null>}
         */
        async tryRefreshToken(refreshToken = "") {
            return (await this._requestRefresh(refreshToken)).token;
        },

        /**
         * Calls LoginJwt/Refresh. Throws on network errors, otherwise returns
         * the new JWT (or null) together with the HTTP status.
         *
         * @async
         * @private
         * @param {string} refreshToken
         * @returns {Promise<{token: string|null, status: number}>}
         */
        async _requestRefresh(refreshToken) {
            const payload = { "Token": refreshToken };
            const res = await fetch(`${this.authUrl}LoginJwt/Refresh`,
                {
                    method: "PUT",
                    body: JSON.stringify(payload),
                    headers: { "Content-Type": "application/json" },
                    // never hold the cross-tab refresh lock forever
                    ...(typeof AbortSignal !== "undefined" && typeof AbortSignal.timeout === "function" && { signal: AbortSignal.timeout(REFRESH_REQUEST_TIMEOUT_MS) }),
                });
            return { token: res.ok ? await res.json() : null, status: res.status };
        },

        /**
         * check if the user has the specific right
         * @param {string} code
         * @returns {boolean}
         */
        hasRight(code) {
            return (session.userInfo?.rights || []).includes(code);
        },

        /**
         * check if the user has the specific role
         * @param {string} code
         * @returns {boolean}
         */
        hasRole(code) {
            return (session.userInfo?.role || []).includes(code);
        },

        /**
         * update the user session with the new token
         * - stores the refresh token in localStorage
         * - remembers the session identity (user + mandant)
         * - (re)starts the proactive refresh timer
         * - dispatches AUTH_REFRESHED_EVENT
         * @private
         * @param {string} token
         * @returns {void}
         */
        updateUserSession(token) {
            if (token) {
                session.token = token;
                session.refreshToken = getRefreshToken(token);
                session.userInfo = jwtDecode(token);
                writeStoredRefreshToken(session.refreshToken);
                internal.storedRefreshTokenSeen = session.refreshToken;
                internal.identity = getIdentity(token);
                internal.expired = false;
                internal.sessionStarted = true;
                internal.rejectedRefreshTokens.clear();
                this._installBrowserListeners();
                this._scheduleProactiveRefresh();
                dispatchAuthEvent(AUTH_REFRESHED_EVENT, { expiresAt: getTokenExpiresAt(token) ?? 0 });
            }
        },

        /**
         * End the session for good: clear tokens and stop the proactive timer.
         * A rejected refresh token is also removed from localStorage (if it is
         * still the stored one), so other tabs/instances and the next page
         * load do not send it again. AUTH_EXPIRED_EVENT is dispatched by the
         * callers via _notifyExpired.
         * @private
         * @param {string} reason
         * @param {string|null} [rejectedRefreshToken=null]
         * @returns {void}
         */
        _expire(reason, rejectedRefreshToken = null) {
            this._stopProactiveRefresh();
            session.token = "";
            session.refreshToken = "";
            if (rejectedRefreshToken && readStoredRefreshToken() === rejectedRefreshToken) {
                removeStoredRefreshToken();
                internal.storedRefreshTokenSeen = null;
            }
            console.warn("session ended:", reason);
        },

        /**
         * Dispatch AUTH_EXPIRED_EVENT once per expiry (until the next
         * successful login/refresh).
         * @private
         * @param {string} reason
         * @returns {void}
         */
        _notifyExpired(reason) {
            if (internal.expired) {
                return;
            }

            internal.expired = true;
            console.warn("session expired:", reason);
            dispatchAuthEvent(AUTH_EXPIRED_EVENT, { reason });
        },

        /**
         * (Re)start the proactive refresh timer. The due time is derived from
         * the token lifetime (`exp - iat`) measured from receipt, not from the
         * wall clock, so a skewed client clock or a very short-lived JWT can
         * never lead to back-to-back refreshes:
         * `delay = max(lifetime - PROACTIVE_RENEWAL, lifetime / 2, MIN_PROACTIVE_DELAY)`.
         * Only one timer per instance (shared by all its wrappers); disabled
         * outside the browser.
         * @private
         * @param {number} [delay] - explicit delay (ms), used to resume a capped/deferred timer
         * @returns {void}
         */
        _scheduleProactiveRefresh(delay) {
            if (internal.refreshTimer) {
                clearTimeout(internal.refreshTimer);
                internal.refreshTimer = null;
            }
            if (!hasBrowserContext() || !session.token) {
                internal.refreshDueAt = 0;
                return;
            }

            if (delay === undefined || internal.scheduledToken !== session.token) {
                const lifetime = getTokenLifetime(session.token);
                if (!lifetime) {
                    internal.refreshDueAt = 0;
                    return;
                }

                internal.scheduledToken = session.token;
                internal.refreshDueAt = Date.now() + Math.max(lifetime - PROACTIVE_RENEWAL * 1000, lifetime / 2, MIN_PROACTIVE_DELAY_MS);
                delay = internal.refreshDueAt - Date.now();
            }

            internal.refreshTimer = setTimeout(() => {
                internal.refreshTimer = null;
                self._proactiveRefresh();
            }, Math.min(Math.max(0, delay), MAX_TIMEOUT_MS));
        },

        /**
         * stop the proactive refresh timer
         * @private
         * @returns {void}
         */
        _stopProactiveRefresh() {
            if (internal.refreshTimer) {
                clearTimeout(internal.refreshTimer);
                internal.refreshTimer = null;
            }
            internal.refreshDueAt = 0;
            internal.scheduledToken = "";
            internal.refreshDueWhileHidden = false;
        },

        /**
         * Timer callback: refresh ahead of expiry, but only while the document
         * is visible. A hidden document defers to the next visibilitychange.
         * Does nothing after logout (tokens cleared) or expiry. Two proactive
         * refreshes are at least MIN_PROACTIVE_INTERVAL_MS apart.
         * @private
         * @returns {void}
         */
        _proactiveRefresh() {
            if (!hasBrowserContext() || !session.token || !session.refreshToken || internal.expired) {
                return;
            }

            if (internal.scheduledToken !== session.token) {
                // token replaced meanwhile (e.g. useToken): schedule for the new one
                self._scheduleProactiveRefresh();
                return;
            }

            const now = Date.now();
            if (internal.refreshDueAt > now) {
                // not due yet (capped timeout)
                self._scheduleProactiveRefresh(internal.refreshDueAt - now);
                return;
            }

            const pause = internal.lastProactiveRefreshAt + MIN_PROACTIVE_INTERVAL_MS - now;
            if (pause > 0) {
                self._scheduleProactiveRefresh(pause);
                return;
            }

            if (document.visibilityState !== "visible") {
                internal.refreshDueWhileHidden = true;
                return;
            }

            internal.refreshDueWhileHidden = false;
            internal.lastProactiveRefreshAt = now;
            self._runRefresh(true).catch((e) => console.error("proactive token refresh failed", e));
        },

        /**
         * Register (once per instance, shared by all its wrappers) the browser listeners:
         * - `storage`: adopt a refresh token rotated by another tab (the JWT
         *   is renewed with it on the next request / proactive refresh; a
         *   different identity is detected there)
         * - `visibilitychange`: run a proactive refresh that was due while hidden
         * @private
         * @returns {void}
         */
        _installBrowserListeners() {
            if (internal.browserListenersInstalled || !hasBrowserContext()) {
                return;
            }

            internal.browserListenersInstalled = true;
            window.addEventListener("storage", (e) => {
                if (e.key !== REFRESH_TOKEN_STORAGE_KEY || !e.newValue || e.newValue === session.refreshToken || internal.rejectedRefreshTokens.has(e.newValue)) {
                    return;
                }

                session.refreshToken = e.newValue;
                internal.storedRefreshTokenSeen = e.newValue;
            });
            document.addEventListener("visibilitychange", () => {
                if (document.visibilityState !== "visible") {
                    return;
                }

                const due = internal.refreshDueAt > 0 && internal.refreshDueAt <= Date.now();
                if (internal.refreshDueWhileHidden || due) {
                    self._proactiveRefresh();
                }
            });
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

    return self;
}

/**
 * configure the time before token expiry to renew
 * @type {number}
 */
const JWT_SAFE_RENEWAL = 30; // seconds before token expiry to renew

/**
 * seconds before token expiry the proactive refresh timer fires
 * @type {number}
 */
const PROACTIVE_RENEWAL = 60;

/**
 * lower bound (ms) for the proactive refresh delay after receiving a JWT
 * @type {number}
 */
const MIN_PROACTIVE_DELAY_MS = 30000;

/**
 * minimum pause (ms) between two proactive refreshes
 * @type {number}
 */
const MIN_PROACTIVE_INTERVAL_MS = 30000;

/**
 * error codes that mean the refresh token is gone or unusable for this
 * session (init redirects to login only for these)
 * @type {string[]}
 */
const SESSION_END_CODES = ["refresh-rejected", "no-refresh-token", "identity-changed"];

/**
 * maximum setTimeout delay (larger values overflow and fire immediately)
 * @type {number}
 */
const MAX_TIMEOUT_MS = 2147483647;

/**
 * timeout for the refresh request, so the cross-tab lock is never held forever
 * @type {number}
 */
const REFRESH_REQUEST_TIMEOUT_MS = 30000;

/**
 * localStorage key shared by all tabs and auth manager instances
 * @type {string}
 */
const REFRESH_TOKEN_STORAGE_KEY = "idas-refresh-token";

/**
 * Web Locks name used to serialize refreshes across tabs
 * @type {string}
 */
const REFRESH_LOCK_NAME = "idas-refresh";

/**
 * @returns {boolean} true if running in a browser document
 */
function hasBrowserContext() {
    return typeof window !== "undefined" && typeof document !== "undefined";
}

/**
 * @returns {string|null} the refresh token in localStorage, null if unavailable
 */
function readStoredRefreshToken() {
    try {
        return typeof localStorage !== "undefined" ? localStorage.getItem(REFRESH_TOKEN_STORAGE_KEY) : null;
    } catch {
        return null;
    }
}

/**
 * @param {string} refreshToken
 * @returns {void}
 */
function writeStoredRefreshToken(refreshToken) {
    try {
        if (typeof localStorage !== "undefined" && refreshToken) {
            localStorage.setItem(REFRESH_TOKEN_STORAGE_KEY, refreshToken);
        }
    } catch {
        // storage blocked – the in-memory token still works for this instance
    }
}

/**
 * @returns {void}
 */
function removeStoredRefreshToken() {
    try {
        if (typeof localStorage !== "undefined") {
            localStorage.removeItem(REFRESH_TOKEN_STORAGE_KEY);
        }
    } catch {
        // storage blocked – nothing to clean up
    }
}

/**
 * A refresh response that definitely rejects the refresh token: any 4xx
 * except 408 (Request Timeout) and 429 (Too Many Requests), which are
 * transient. IDAS answers a consumed/unknown token with 403.
 * @param {number} status
 * @returns {boolean}
 */
function isRejectionStatus(status) {
    return status >= 400 && status < 500 && status !== 408 && status !== 429;
}

/**
 * @param {string} code - machine readable reason
 * @param {boolean} sessionEnded - true if a running session ended (AUTH_EXPIRED_EVENT is due)
 * @param {string} [message="not authenticated"]
 * @param {number} [status]
 * @returns {Error & {code: string, sessionEnded: boolean, status?: number}}
 */
function authError(code, sessionEnded, message = "not authenticated", status = undefined) {
    const error = /** @type {Error & {code: string, sessionEnded: boolean, status?: number}} */ (new Error(message));
    error.code = code;
    error.sessionEnded = sessionEnded;
    if (status !== undefined) {
        error.status = status;
    }
    return error;
}

/**
 * Identity of a session (user + mandant) from the JWT claims, used to detect
 * that a refresh token taken over from localStorage belongs to someone else.
 * @param {string} token
 * @returns {string|null} null if the claims carry no identity
 */
function getIdentity(token) {
    try {
        const decoded = /** @type {Record<string, any>} */ (jwtDecode(token));
        const user = decoded?.benutzerGuid ?? decoded?.id ?? decoded?.sub ?? null;
        const mandant = decoded?.mandantGuid ?? null;
        return user || mandant ? JSON.stringify([user, mandant]) : null;
    } catch {
        return null;
    }
}

/**
 * Lifetime of a JWT in ms: `exp - iat`, independent of the client clock.
 * Without `iat` the remaining time by the client clock is used.
 * @param {string} token
 * @returns {number|null} null if not decodable
 */
function getTokenLifetime(token) {
    try {
        const decoded = jwtDecode(token);
        if (!decoded?.exp) {
            return null;
        }
        return decoded.iat ? (decoded.exp - decoded.iat) * 1000 : decoded.exp * 1000 - Date.now();
    } catch {
        return null;
    }
}

/**
 * Run the callback while holding the cross-tab refresh lock
 * (`navigator.locks`); without Web Locks the callback runs directly.
 * @template T
 * @param {() => Promise<T>} callback
 * @returns {Promise<T>}
 */
function withRefreshLock(callback) {
    const locks = typeof navigator !== "undefined" ? navigator.locks : undefined;
    if (locks && typeof locks.request === "function") {
        return locks.request(REFRESH_LOCK_NAME, () => callback());
    }

    return callback();
}

/**
 * @param {string} token
 * @returns {number|null} JWT expiry (`exp`) in milliseconds, null if not decodable
 */
function getTokenExpiresAt(token) {
    try {
        const decoded = jwtDecode(token);
        return decoded?.exp ? decoded.exp * 1000 : null;
    } catch {
        return null;
    }
}

/**
 * @param {string} token
 * @returns {string|null} the refresh token claim, null if not decodable
 */
function tryGetRefreshToken(token) {
    try {
        return getRefreshToken(token) || null;
    } catch {
        return null;
    }
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
