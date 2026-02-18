/**
 * Factory function to create an IDAS instance
 * @function IDASFactory
 * @param {Object} settings - Configuration settings
 * @param {RESTClient} settings.restClient - REST client instance
 * @param {string} settings.mandantGuid - Mandant GUID for backwards compatibility
 * @returns {IDAS} An IDAS client instance
 * @throws {string} If settings are invalid
 * @example
 * const idas = IDASFactory({
 *   restClient: client,
 *   mandantGuid: 'guid-here'
 * });
 */
import { isInvalid, currentToken} from "./authUtils";
import { RESTClient } from "./RESTClient";
import { jwtDecode } from "jwt-decode";

export function IDASFactory(settings)
{
    if (!isInvalid(settings))
    {
        return new IDAS(settings);
    }

    throw ("Invalid settings: call initIDAS() first to obtain a valid settings!");
}

/**
 * IDAS API client for interacting with IDAS backend services.
 * Provides methods for authentication, mandant management, user management,
 * and process handling.
 * @class
 * @param {Object} settings - Configuration settings
 * @param {RESTClient} settings.restClient - REST client instance
 * @param {string} settings.mandantGuid - Mandant GUID
 * @property {RESTClient} restClient - The HTTP client instance
 * @property {string} mandantGuid - The mandant GUID
 * @property {Object} settings - Configuration settings
 */
class IDAS
{
    restClient = undefined;
    mandantGuid = undefined;

    /**
     * Creates an IDAS instance
     * @param {Object} settings - Configuration settings
     */
    constructor(settings)
    {
        this.settings = settings;
        this.mandantGuid = settings.mandantGuid; // for backwards compatiblity only
        this.restClient = new RESTClient(settings);
    }

    /**
     * Authentication methods for managing JWT tokens and user permissions
     * @namespace
     */
    auth = {
        _self: this,

        /**
         * Gets the current JWT authentication token
         * @returns {string} The current JWT token
         */
        getCurrentAuthToken()
        {
            return currentToken;
        },

        /**
         * Gets all rights from the current JWT token
         * @returns {string[]} Array of right codes
         */
        getRights()
        {
            if (!currentToken)
            {
                return [];
            }

            const decoded = jwtDecode(currentToken);
            if (!decoded.rights)
            {
                return [];
            }

            return Array.isArray(decoded.rights) ? decoded.rights : [decoded.rights];
        },

        /**
         * Gets all roles from the current JWT token
         * @returns {string[]} Array of role codes
         */
        getRoles()
        {
            if (!currentToken)
            {
                return [];
            }

            const decoded = jwtDecode(currentToken);
            if (!decoded.role)
            {
                return [];
            }

            return Array.isArray(decoded.role) ? decoded.role : [decoded.role];
        },

        /**
         * Checks if the user has a specific right
         * @param {string} code - The right code to check
         * @returns {boolean} True if the user has the right
         */
        hasRight(code)
        {
            return this.getRights().some(r => r === code);
        },

        /**
         * Checks if the user has a specific role
         * @param {string} code - The role code to check
         * @returns {boolean} True if the user has the role
         */
        hasRole(code)
        {
            return this.getRoles().some(r => r === code);
        },

        /**
         * Gets the username from the current JWT token
         * @returns {string|undefined} The username or undefined if not authenticated
         */
        getUsername()
        {
            if (!currentToken)
            {
                return undefined;
            }

            const decoded = jwtDecode(currentToken);
            return decoded.id;
        },
    };

    /**
     * Mandant (tenant) management methods
     * @namespace
     */
    mandanten = {
        _self: this,

        /**
         * Gets all mandanten
         * @async
         * @returns {Promise<Object[]>} Array of mandant objects
         */
        async getAll()
        {
            return await this._self.restClient.get("/Mandanten");
        },

        /**
         * Gets a specific mandant by GUID
         * @async
         * @param {string} guid - The mandant GUID
         * @returns {Promise<Object>} The mandant object
         */
        async get(guid)
        {
            return await this._self.restClient.get(`/Mandanten/${guid}`);
        },

        /**
         * Saves a mandant
         * @async
         * @param {Object} m - The mandant object to save
         * @returns {Promise<void>}
         */
        async save(m)
        {
            await this._self.restClient.put("/Mandanten", m);
        },
    };

    /**
     * User (Benutzer) management methods
     * @namespace
     */
    benutzer = {
        _self: this,

        /**
         * Gets all users for a mandant
         * @async
         * @param {string} mandantGuid - The mandant GUID
         * @returns {Promise<Object[]>} Array of user objects
         */
        async getAll(mandantGuid)
        {
            return await this._self.restClient.get(`/Benutzer?mandantGuid=${mandantGuid}`);
        },

        /**
         * Gets a specific user by GUID
         * @async
         * @param {string} guid - The user GUID
         * @returns {Promise<Object>} The user object
         */
        async get(guid)
        {
            return await this._self.restClient.get(`/Benutzer/${guid}`);
        },

        /**
         * Saves a user
         * @async
         * @param {Object} m - The user object to save
         * @returns {Promise<void>}
         */
        async save(m)
        {
            await this._self.restClient.put("/Benutzer", m);
        },
    };

    /**
     * Role (Rollen) management methods
     * @namespace
     */
    rollen = {
        _self: this,

        /**
         * Gets all roles
         * @async
         * @returns {Promise<Object[]>} Array of role objects
         */
        async getAll()
        {
            return await this._self.restClient.get("/Rollen");
        },

        /**
         * Saves a role
         * @async
         * @param {Object} m - The role object to save
         * @returns {Promise<void>}
         */
        async save(m)
        {
            await this._self.restClient.put("/Rollen", m);
        },
    };

    /**
     * Process (Vorgang) management methods
     * @namespace
     */
    vorgaenge = {
        _self: this,

        /**
         * Gets a process by its number and year
         * @async
         * @param {string} vorgangsNummer - The process number
         * @param {string|number} jahr - The year
         * @returns {Promise<Object>} The process object
         */
        async getByVorgangsnummer(vorgangsNummer, jahr)
        {
            return await this._self.restClient.get(`/Vorgaenge/GetByVorgangsnummer?vorgangsNummer=${vorgangsNummer}&jahr=${jahr}`);
        },

        /**
         * Gets a process by its GUID
         * @async
         * @param {string} guid - The process GUID
         * @returns {Promise<Object>} The process object
         */
        async getByGuid(guid)
        {
            return await this._self.restClient.get(`/Vorgaenge/${guid}`);
        },
    };

    /**
     * Position management methods
     * @namespace
     */
    positionen = {
        _self: this,

        /**
         * Gets positions by pcode
         * @async
         * @param {string} pcode - The position code
         * @returns {Promise<Object[]>} Array of position objects
         */
        async getByPcode(pcode)
        {
            return await this._self.restClient.get(`/BelegPositionen/GetByPcode?pcode=${pcode}`);
        },

        /**
         * Gets a position by its GUID
         * @async
         * @param {string} guid - The position GUID
         * @returns {Promise<Object>} The position object
         */
        async get(guid)
        {
            return await this._self.restClient.get(`/BelegPositionen/${guid}`);
        },
    };
}
