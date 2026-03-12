/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/belege.js').VorgangHistorienDTO} VorgangHistorienDTO
 * @typedef {import('../dtos/belege.js').BelegHistorienDTO} BelegHistorienDTO
 * @typedef {import('../dtos/belege.js').BelegPositionHistorienDTO} BelegPositionHistorienDTO
 * @typedef {import('../dtos/belege.js').VorgangHistorieDTO} VorgangHistorieDTO
 * @typedef {import('../dtos/belege.js').BelegHistorieDTO} BelegHistorieDTO
 * @typedef {import('../dtos/belege.js').BelegPositionHistorieDTO} BelegPositionHistorieDTO
 * @typedef {import('../dtos/index.js').SerieHistorieDTO} SerieHistorieDTO
 */

/**
 * Historie API - History tracking and management
 * @param {FluentApi} fluentApi
 */
export function createHistorieApi(fluentApi) {
    return {
        // HistorieWebRoutinen
        /**
         * Get vorgang history
         * @param {string} vorgangGuid
         * @param {boolean} [includeBelege=false]
         * @param {boolean} [includePositionen=false]
         * @returns {Promise<VorgangHistorienDTO>}
         */
        getVorgangHistorie: (vorgangGuid, includeBelege = false, includePositionen = false) =>
            fluentApi.get(`HistorieVorgang?vorgangGuid=${vorgangGuid}&includeBelege=${includeBelege}&includePositionen=${includePositionen}`),

        /**
         * Get beleg history
         * @param {string} belegGuid
         * @param {boolean} [includePositionen=false]
         * @returns {Promise<BelegHistorienDTO>}
         */
        getBelegHistorie: (belegGuid, includePositionen = false) =>
            fluentApi.get(`HistorieBeleg?belegGuid=${belegGuid}&includePositionen=${includePositionen}`),

        /**
         * Get beleg position history
         * @param {string} positionGuid
         * @returns {Promise<BelegPositionHistorienDTO>}
         */
        getBelegPositionHistorie: (positionGuid) =>
            fluentApi.get(`HistorieBelegPosition?positionGuid=${positionGuid}`),

        /**
         * Get serie history since date
         * @param {Date} sinceWhen
         * @returns {Promise<SerieHistorieDTO[]>}
         */
        getSerieHistorieSince: (sinceWhen) =>
            fluentApi.get(`HistorieSerie?createdSince=${sinceWhen.toISOString()}`),

        /**
         * Get serie history by GUID
         * @param {string} serieGuid
         * @returns {Promise<SerieHistorieDTO[]>}
         */
        getSerieHistorie: (serieGuid) => fluentApi.get(`HistorieSerie?serieGuid=${serieGuid}`),

        /**
         * Add vorgang history
         * @param {string} vorgangGuid
         * @param {VorgangHistorieDTO} historyDto
         * @returns {Promise<void>}
         */
        addVorgangHistorie: (vorgangGuid, historyDto) =>
            fluentApi.post(`HistorieVorgang?vorgangGuid=${vorgangGuid}`, historyDto),

        /**
         * Add beleg history
         * @param {string} belegGuid
         * @param {BelegHistorieDTO} historyDto
         * @returns {Promise<void>}
         */
        addBelegHistorie: (belegGuid, historyDto) =>
            fluentApi.post(`HistorieBeleg?belegGuid=${belegGuid}`, historyDto),

        /**
         * Add beleg position history
         * @param {string} positionGuid
         * @param {BelegPositionHistorieDTO} historyDto
         * @returns {Promise<void>}
         */
        addBelegPositionHistorie: (positionGuid, historyDto) =>
            fluentApi.post(`HistorieBelegPosition?positionGuid=${positionGuid}`, historyDto),

        /**
         * Add serie history
         * @param {SerieHistorieDTO} historyDto
         * @returns {Promise<void>}
         */
        addSerieHistorie: (historyDto) => fluentApi.post("HistorieSerie", historyDto),

        /**
         * Add vorgang history from function
         * @param {string} vorgangGuid
         * @param {VorgangHistorieDTO} historyDto
         * @param {number} mandantID
         * @returns {Promise<void>}
         */
        addVorgangHistorieFromFunction: (vorgangGuid, historyDto, mandantID) =>
            fluentApi.post(`AddVorgangHistorieFromFunction?vorgangGuid=${vorgangGuid}&mandantID=${mandantID}`, historyDto),

        /**
         * Add beleg position history from function
         * @param {string} positionGuid
         * @param {BelegPositionHistorieDTO} historyDto
         * @param {number} mandantID
         * @returns {Promise<void>}
         */
        addBelegPositionHistorieFromFunction: (positionGuid, historyDto, mandantID) =>
            fluentApi.post(`AddBelegPositionHistorieFromFunction?positionGuid=${positionGuid}&mandantID=${mandantID}`, historyDto),

        /**
         * Add serie history from function
         * @param {SerieHistorieDTO} historyDto
         * @param {number} mandantID
         * @returns {Promise<void>}
         */
        addSerieHistorieFromFunction: (historyDto, mandantID) =>
            fluentApi.post(`AddBelegPositionHistorieFromFunction?mandantID=${mandantID}`, historyDto),

        /**
         * Get last editor for beleg
         * @param {string} belegGuid
         * @returns {Promise<string>}
         */
        getLetzterBearbeiter: (belegGuid) =>
            fluentApi.get(`HistorieBeleg/LetzterBearbeiter?belegGuid=${belegGuid}`),

        /**
         * Get last editors for belege
         * @param {string[]} belegGuids
         * @returns {Promise<Record<string, string>>}
         */
        getLetzteBearbeiter: (belegGuids) =>
            fluentApi.post("HistorieBeleg/LetzteBearbeiter", belegGuids),
    };
}

/**
 * @typedef {ReturnType<typeof createHistorieApi>} HistorieApi
 */
