/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').LoginDTO} LoginDTO
 * @typedef {import('../dtos/index.js').CreateServiceTokenRequestDTO} CreateServiceTokenRequestDTO
 */

/**
 * Auth API - Authentication and token management
 * @param {FluentApi} fluentApi
 */
export function createAuthApi(fluentApi) {
    return {
        // LoginJwtRoutinen
        /**
         * Authenticate
         * @param {LoginDTO} dto
         * @returns {Promise<string>}
         */
        authenticate: (dto) => fluentApi.post("LoginJwt/Authenticate", dto),

        /**
         * Authenticate for function
         * @param {string} email
         * @returns {Promise<string>}
         */
        authenticateForFunction: (email) =>
            fluentApi.post(`LoginJwt/AuthenticateForFunction/?email=${encodeURIComponent(email)}`, null),

        /**
         * Refresh token
         * @param {string} token
         * @returns {Promise<string>}
         */
        refreshToken: (token) => fluentApi.put("LoginJwt/Refresh", token),

        /**
         * Create service token
         * @param {CreateServiceTokenRequestDTO} [dto]
         * @returns {Promise<string>}
         */
        createServiceToken: (dto) => fluentApi.post("LoginJwt/CreateServiceToken", dto),

        // AuthTokenWebRoutinen
        /**
         * Remove expired tokens
         * @returns {Promise<void>}
         */
        removeExpiredTokens: () =>
            fluentApi.post("AuthToken/RemoveExpiredTokens", null),

        /**
         * Get external app auth token
         * @param {string} fremdApp
         * @returns {Promise<import('../dtos/index.js').UserAuthTokenDTO>}
         */
        getFremdAppAuthToken: (fremdApp) =>
            fluentApi.get(`AuthToken/GetFremdAppAuthToken?fremdApp=${fremdApp}`),
    };
}

/**
 * @typedef {ReturnType<typeof createAuthApi>} AuthApi
 */
