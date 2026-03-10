/**
 * Serien API - Combined API for Serien (Series) and AV (Arbeitsvorbereitung) operations
 * Combines functionality from SerienWebRoutinen and AVWebRoutinen
 *
 * @module api/business/serienApi
 */

/**
 * @typedef {import('../dtos/produktion.js').SerieDTO} SerieDTO
 * @typedef {import('../dtos/produktion.js').SerieAuslastungDTO} SerieAuslastungDTO
 * @typedef {import('../dtos/produktion.js').VirtualSerieWithAuslastungDTO} VirtualSerieWithAuslastungDTO
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

        // ============================================================================
        // AV Position Operations (from AVWebRoutinen)
        // ============================================================================

        /**
         * Gets all AV positions
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async getAllBelegPositionenAV() {
            return await this.fluentApi.get("BelegPositionenAV");
        },

        /**
         * Gets all AV positions changed since a specific date
         * @param {Date} changedSince - Date to filter changes since
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async getAllBelegPositionenAVChangedSince(changedSince) {
            return await this.fluentApi.get(`BelegPositionenAV/?changedSince=${changedSince.toISOString()}`);
        },

        /**
         * Gets all AV positions with optional filtering
         * @param {boolean} [includeOriginalBeleg=true] - Whether to include original order data
         * @param {boolean} [includeProdDaten=true] - Whether to include production data
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async getAllBelegPositionenAVWithOptions(includeOriginalBeleg = true, includeProdDaten = true) {
            return await this.fluentApi.get(`BelegPositionenAV?includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`);
        },

        /**
         * Gets all AV positions changed since a specific date with optional filtering
         * @param {Date} changedSince - Date to filter changes since
         * @param {boolean} [includeOriginalBeleg=true] - Whether to include original order data
         * @param {boolean} [includeProdDaten=true] - Whether to include production data
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async getAllBelegPositionenAVChangedSinceWithOptions(changedSince, includeOriginalBeleg = true, includeProdDaten = true) {
            return await this.fluentApi.get(`BelegPositionenAV/?changedSince=${changedSince.toISOString()}&includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`);
        },

        /**
         * Gets AV positions for a specific series
         * @param {string} serieGuid - GUID of the series
         * @param {boolean} [includeOriginalBeleg=true] - Whether to include original order data
         * @param {boolean} [includeProdDaten=true] - Whether to include production data
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async getSerieBelegPositionenAV(serieGuid, includeOriginalBeleg = true, includeProdDaten = true) {
            return await this.fluentApi.get(`BelegPositionenAV/?serieGuid=${serieGuid}&includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`);
        },

        /**
         * Gets AV positions for a specific order (Vorgang)
         * @param {string} vorgangGuid - GUID of the order
         * @param {boolean} [includeOriginalBeleg=true] - Whether to include original order data
         * @param {boolean} [includeProdDaten=true] - Whether to include production data
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async getVorgangBelegPositionenAV(vorgangGuid, includeOriginalBeleg = true, includeProdDaten = true) {
            return await this.fluentApi.get(`BelegPositionenAV/?vorgangGuid=${vorgangGuid}&includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`);
        },

        /**
         * Gets AV positions for multiple orders
         * @param {string[]} vorgangGuids - Array of order GUIDs
         * @param {boolean} [includeOriginalBeleg=true] - Whether to include original order data
         * @param {boolean} [includeProdDaten=true] - Whether to include production data
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async getVorgaengeBelegPositionenAV(vorgangGuids, includeOriginalBeleg = true, includeProdDaten = true) {
            const vorgangGuidsString = vorgangGuids.map(g => `vorgangGuids=${encodeURIComponent(g)}`).join("&");
            return await this.fluentApi.get(`BelegPositionenAVByVorgangIds/?${vorgangGuidsString}&includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`);
        },

        /**
         * Gets AV positions for a specific order position
         * @param {string} belegpositionGuid - GUID of the order position
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async getBelegPositionenAV(belegpositionGuid) {
            return await this.fluentApi.get(`BelegPositionenAV/${belegpositionGuid}`);
        },

        /**
         * Gets a single AV position by its GUID
         * @param {string} avGuid - GUID of the AV position
         * @returns {Promise<BelegPositionAVDTO>}
         */
        async getBelegPositionAVById(avGuid) {
            return await this.fluentApi.get(`BelegPositionenAVById/${avGuid}`);
        },

        /**
         * Gets AV positions by PCode
         * @param {string} pcode - The PCode to search for
         * @param {boolean} [includeOriginalBeleg=true] - Whether to include original order data
         * @param {boolean} [includeProdDaten=true] - Whether to include production data
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async getBelegPositionAVByPCode(pcode, includeOriginalBeleg = true, includeProdDaten = true) {
            return await this.fluentApi.get(`BelegPositionenAVByPCode/${encodeURIComponent(pcode)}?includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`);
        },

        /**
         * Searches AV positions by PCode with wildcard search
         * @param {string} search - The search string
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async searchBelegPositionAVByPCode(search) {
            return await this.fluentApi.get(`BelegPositionenAVSearchByPCode?search=${encodeURIComponent(search)}`);
        },

        /**
         * Saves a single AV position
         * @param {BelegPositionAVDTO} position - The AV position to save
         * @returns {Promise<void>}
         */
        async saveBelegPositionenAV(position) {
            await this.fluentApi.put("BelegPositionenAV", position);
        },

        /**
         * Saves multiple AV positions
         * @param {BelegPositionAVDTO[]} positionen - Array of AV positions to save
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async saveBelegPositionenAVBulk(positionen) {
            return await this.fluentApi.put("BelegPositionenAVBulk", positionen);
        },

        /**
         * Saves AV positions to a specific series
         * @param {string} serieGuid - GUID of the target series
         * @param {string[]} positionen - Array of AV position GUIDs to add
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        async saveBelegPositionenAVToSerie(serieGuid, positionen) {
            return await this.fluentApi.put(`BelegPositionenAVBulk/AddToSerie/${serieGuid}`, positionen);
        },

        /**
         * Triggers AV calculation for the specified positions
         * @param {string[]} guids - Array of AV position GUIDs to calculate
         * @returns {Promise<void>}
         */
        async belegPositionenAVBerechnen(guids) {
            await this.fluentApi.put("BelegPositionenAVBulk/AVBerechnung", guids);
        },

        /**
         * Deletes a single AV position
         * @param {string} guid - GUID of the AV position to delete
         * @returns {Promise<void>}
         */
        async deleteBelegPositionenAV(guid) {
            await this.fluentApi.delete(`BelegPositionenAV/${guid}`);
        },

        /**
         * Deletes multiple AV positions
         * @param {string[]} guids - Array of AV position GUIDs to delete
         * @returns {Promise<void>}
         */
        async deleteBelegPositionenAVBulk(guids) {
            await this.fluentApi.delete("BelegPositionenAVBulk", guids);
        },

        /**
         * Assigns order positions to series
         * @param {string} belegGuid - GUID of the order
         * @param {PositionSerieItemDTO[]} positionSerieItems - Array of position-to-series assignments
         * @returns {Promise<void>}
         */
        async belegPositionenSerienZuordnen(belegGuid, positionSerieItems) {
            await this.fluentApi.put(`BelegPositionenAVBulk/SerienZuorden/${belegGuid}`, positionSerieItems);
        },
    };
}

/**
 * @typedef {Object} SerienApi
 * @property {FluentApi} fluentApi
 *
 * // Serie Operations
 * @property {function(string): Promise<void>} releaseElemente
 * @property {function(string, string): Promise<string>} moveElemente
 * @property {function(string): Promise<string>} redistributeElemente
 * @property {function(): Promise<SerieDTO[]>} getAllSerien
 * @property {function(Date): Promise<SerieDTO[]>} getAllSerienChangedSince
 * @property {function(string): Promise<SerieDTO>} getSerie
 * @property {function(SerieDTO): Promise<void>} saveSerie
 * @property {function(string): Promise<void>} deleteSerie
 * @property {function(string): Promise<SerieAuslastungDTO[]>} getAuslastung
 * @property {function(boolean): Promise<Record<string, SerieAuslastungDTO[]>>} getGesamtAuslastung
 * @property {function(Date?, Date?, boolean): Promise<Record<string, SerieAuslastungDTO[]>>} getSerienKapazitaeten
 * @property {function(Date?, Date?): Promise<VirtualSerieWithAuslastungDTO[]>} getAuslastungVirtualSerien
 * @property {function(number, number): Promise<SerieAuslastungDTO[]>} getAuslastungVorgang
 *
 * // AV Position Operations
 * @property {function(): Promise<BelegPositionAVDTO[]>} getAllBelegPositionenAV
 * @property {function(Date): Promise<BelegPositionAVDTO[]>} getAllBelegPositionenAVChangedSince
 * @property {function(boolean, boolean): Promise<BelegPositionAVDTO[]>} getAllBelegPositionenAVWithOptions
 * @property {function(Date, boolean, boolean): Promise<BelegPositionAVDTO[]>} getAllBelegPositionenAVChangedSinceWithOptions
 * @property {function(string, boolean, boolean): Promise<BelegPositionAVDTO[]>} getSerieBelegPositionenAV
 * @property {function(string, boolean, boolean): Promise<BelegPositionAVDTO[]>} getVorgangBelegPositionenAV
 * @property {function(string[], boolean, boolean): Promise<BelegPositionAVDTO[]>} getVorgaengeBelegPositionenAV
 * @property {function(string): Promise<BelegPositionAVDTO[]>} getBelegPositionenAV
 * @property {function(string): Promise<BelegPositionAVDTO>} getBelegPositionAVById
 * @property {function(string, boolean, boolean): Promise<BelegPositionAVDTO[]>} getBelegPositionAVByPCode
 * @property {function(string): Promise<BelegPositionAVDTO[]>} searchBelegPositionAVByPCode
 * @property {function(BelegPositionAVDTO): Promise<void>} saveBelegPositionenAV
 * @property {function(BelegPositionAVDTO[]): Promise<BelegPositionAVDTO[]>} saveBelegPositionenAVBulk
 * @property {function(string, string[]): Promise<BelegPositionAVDTO[]>} saveBelegPositionenAVToSerie
 * @property {function(string[]): Promise<void>} belegPositionenAVBerechnen
 * @property {function(string): Promise<void>} deleteBelegPositionenAV
 * @property {function(string[]): Promise<void>} deleteBelegPositionenAVBulk
 * @property {function(string, PositionSerieItemDTO[]): Promise<void>} belegPositionenSerienZuordnen
 */
