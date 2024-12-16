/**
 * Gets idas refresh token from the URL if it exists and removes it from the URL.
 *
 * @returns {string|null} The refresh token or null if it does not exist.
 */
export function popRefreshTokenFromUrl() {
    const url = new URL(window.location.href);
    const refreshToken = url.searchParams.get("t");
    if (refreshToken) {
        url.searchParams.delete("t");
        window.history.replaceState({}, document.title, url);
        return refreshToken;
    }

    return null;
}
