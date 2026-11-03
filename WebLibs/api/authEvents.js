/**
 * Auth lifecycle events dispatched by the FluentAuthManager on `globalThis`
 * (the `window` in a browser; no-op elsewhere).
 *
 * Listen with the plain string names, e.g.
 * `window.addEventListener("idas-auth-expired", (e) => ...)`.
 * The events never carry tokens.
 */

/**
 * Dispatched after every successful token refresh or login.
 * `event.detail` is an {@link AuthRefreshedEventDetail}.
 * @type {"idas-auth-refreshed"}
 */
export const AUTH_REFRESHED_EVENT = "idas-auth-refreshed";

/**
 * Dispatched once when the session can definitely no longer be renewed
 * (refresh rejected with a 4xx other than 408/429, also after re-reading
 * localStorage; no refresh token; or a token from localStorage belongs to
 * another user/mandant), exactly once per document and expiry — shared by all
 * wrappers/proxies of an auth manager. Not dispatched again until a successful
 * login or refresh happened. `event.detail` is an {@link AuthExpiredEventDetail}.
 * @type {"idas-auth-expired"}
 */
export const AUTH_EXPIRED_EVENT = "idas-auth-expired";

/**
 * @typedef {Object} AuthRefreshedEventDetail
 * @property {number} expiresAt - Expiry of the new JWT (`exp` claim) in milliseconds since epoch.
 */

/**
 * @typedef {Object} AuthExpiredEventDetail
 * @property {string} reason - Why the session ended, "refresh-rejected", "no-refresh-token" or "identity-changed".
 */

/**
 * Dispatches an auth event on `globalThis` if it can receive DOM events.
 * Errors in listeners never propagate into the auth flow.
 *
 * @private
 * @param {string} name - Event name, one of the constants above.
 * @param {AuthRefreshedEventDetail|AuthExpiredEventDetail} detail
 * @returns {void}
 */
export function dispatchAuthEvent(name, detail) {
    const target = typeof window !== "undefined" ? window : null;
    if (!target || typeof target.dispatchEvent !== "function" || typeof CustomEvent !== "function") {
        return;
    }

    try {
        target.dispatchEvent(new CustomEvent(name, { detail }));
    } catch (e) {
        console.error(`dispatching ${name} failed`, e);
    }
}
