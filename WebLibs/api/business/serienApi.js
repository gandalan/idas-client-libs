/**
 * Serien API - Combined API for Serien (Series) operations
 * Combines functionality from SerienWebRoutinen
 *
 * @module api/business/serienApi
 */

/**
 * @typedef {import('../dtos/produktion.js').SerieDTO} SerieDTO
 * @typedef {import('../dtos/index.js').SerieAuslastungDTO} SerieAuslastungDTO
 * @typedef {import('../dtos/index.js').VirtualSerieWithAuslastungDTO} VirtualSerieWithAuslastungDTO
 * @typedef {import('../dtos/index.js').BelegPositionAVDTO} BelegPositionAVDTO
 * @typedef {import('../dtos/index.js').PositionSerieItemDTO} PositionSerieItemDTO
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 */

/**
 * Creates a Serien API instance with methods for managing series and AV positions
 *
 * @param {FluentApi} fluentApi - The fluent API client instance
 * @returns {SerienApi} The configured Serien API instance
 */
export function createSerienApi(fluentApi) {
    return {
        fluentApi,

        // ============================================================================
        // Serie Operations (from SerienWebRoutinen)
        // ============================================================================

        /**
         * Releases elements from a series
         * @param {string} fromSerie - GUID of the series to release elements from
         * @returns {Promise<void>}
         */
        async releaseElemente(fromSerie) {
            await this.fluentApi.get(`Serie/ReleaseElemente?fromSerie=${fromSerie}`);
        },

        /**
         * Moves elements from one series to another
         * @param {string} fromSerie - GUID of the source series
         * @param {string} toSerie - GUID of the target series
         * @returns {Promise<string>}
         */
        async moveElemente(fromSerie, toSerie) {
            return await this.fluentApi.get(`Serie/MoveElemente?fromSerie=${fromSerie}&toSerie=${toSerie}`);
        },

        /**
         * Redistributes elements within a series
         * @param {string} fromSerie - GUID of the series to redistribute elements in
         * @returns {Promise<string>}
         */
        async redistributeElemente(fromSerie) {
            return await this.fluentApi.get(`Serie/RedistributeElemente?fromSerie=${fromSerie}`);
        },

        /**
         * Gets all series
         * @returns {Promise<SerieDTO[]>}
         */
        async getAllSerien() {
            return await this.fluentApi.get("Serie");
        },

        /**
         * Gets all series changed since a specific date
         * @param {Date} changedSince - Date to filter changes since
         * @returns {Promise<SerieDTO[]>}
         */
        async getAllSerienChangedSince(changedSince) {
            return await this.fluentApi.get(`Serie/?changedSince=${changedSince.toISOString()}`);
        },

        /**
         * Gets a specific series by GUID
         * @param {string} guid - GUID of the series
         * @returns {Promise<SerieDTO>}
         */
        async getSerie(guid) {
            return await this.fluentApi.get(`Serie/${guid}`);
        },

        /**
         * Saves a series
         * @param {SerieDTO} serie - The series to save
         * @returns {Promise<void>}
         */
        async saveSerie(serie) {
            await this.fluentApi.put("Serie", serie);
        },

        /**
         * Deletes a series by GUID
         * @param {string} guid - GUID of the series to delete
         * @returns {Promise<void>}
         */
        async deleteSerie(guid) {
            await this.fluentApi.delete(`Serie/${guid}`);
        },

        /**
         * Gets capacity utilization for a series
         * @param {string} serie - GUID of the series
         * @returns {Promise<SerieAuslastungDTO[]>}
         */
        async getAuslastung(serie) {
            return await this.fluentApi.get(`Auslastung/${serie}`);
        },

        /**
         * Gets total capacity utilization across all series
         * @param {boolean} [includeAbgelaufene=false] - Whether to include expired series
         * @returns {Promise<Record<string, SerieAuslastungDTO[]>>}
         */
        async getGesamtAuslastung(includeAbgelaufene = false) {
            return await this.fluentApi.get(`Auslastung/?includeAbgelaufene=${includeAbgelaufene}`);
        },

        /**
         * Gets series capacities for a date range
         * @param {Date} [startDate] - Start date of the range
         * @param {Date} [endDate] - End date of the range
         * @param {boolean} [includeStaendige=false] - Whether to include permanent series
         * @returns {Promise<Record<string, SerieAuslastungDTO[]>>}
         */
        async getSerienKapazitaeten(startDate = null, endDate = null, includeStaendige = false) {
            const startParam = startDate ? startDate.toISOString() : "";
            const endParam = endDate ? endDate.toISOString() : "";
            return await this.fluentApi.get(`SerieKapazitaet/?startDate=${startParam}&endDate=${endParam}&includeStaendige=${includeStaendige}`);
        },

        /**
         * Gets capacity utilization for virtual series within a date range
         * @param {Date} [startDate] - Start date of the range
         * @param {Date} [endDate] - End date of the range
         * @returns {Promise<VirtualSerieWithAuslastungDTO[]>}
         */
        async getAuslastungVirtualSerien(startDate = null, endDate = null) {
            const startParam = startDate ? startDate.toISOString() : "";
            const endParam = endDate ? endDate.toISOString() : "";
            return await this.fluentApi.get(`AuslastungVirtual/?startDate=${startParam}&endDate=${endParam}`);
        },

        /**
         * Gets capacity utilization for a range of order numbers
         * @param {number} startVorgangsnummer - Start order number
         * @param {number} endVorgangsnummer - End order number
         * @returns {Promise<SerieAuslastungDTO[]>}
         */
        async getAuslastungVorgang(startVorgangsnummer, endVorgangsnummer) {
            return await this.fluentApi.get(`AuslastungVorgang/?startVorgangsnummer=${startVorgangsnummer}&endVorgangsnummer=${endVorgangsnummer}`);
        },
    };
}

/**
 * @typedef {Object} SerienApi
 * @property {FluentApi} fluentApi
 *
 * // Serie Operations
 * @property {(fromSerie: string) => Promise<void>} releaseElemente
 * @property {(fromSerie: string, toSerie: string) => Promise<string>} moveElemente
 * @property {(fromSerie: string) => Promise<string>} redistributeElemente
 * @property {() => Promise<SerieDTO[]>} getAllSerien
 * @property {(changedSince: Date) => Promise<SerieDTO[]>} getAllSerienChangedSince
 * @property {(guid: string) => Promise<SerieDTO>} getSerie
 * @property {(serie: SerieDTO) => Promise<void>} saveSerie
 * @property {(guid: string) => Promise<void>} deleteSerie
 * @property {(serie: string) => Promise<SerieAuslastungDTO[]>} getAuslastung
 * @property {(includeAbgelaufene?: boolean) => Promise<Record<string, SerieAuslastungDTO[]>>} getGesamtAuslastung
 * @property {(startDate?: Date, endDate?: Date, includeStaendige?: boolean) => Promise<Record<string, SerieAuslastungDTO[]>>} getSerienKapazitaeten
 * @property {(startDate?: Date, endDate?: Date) => Promise<VirtualSerieWithAuslastungDTO[]>} getAuslastungVirtualSerien
 * @property {(startVorgangsnummer: number, endVorgangsnummer: number) => Promise<SerieAuslastungDTO[]>} getAuslastungVorgang
 */
