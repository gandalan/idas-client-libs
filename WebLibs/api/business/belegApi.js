/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/belege.js').BelegStatusDTO} BelegStatusDTO
 * @typedef {import('../dtos/belege.js').VorgangDTO} VorgangDTO
 * @typedef {import('../dtos/belege.js').BelegartWechselDTO} BelegartWechselDTO
 * @typedef {import('../dtos/belege.js').VorgangListItemDTO} VorgangListItemDTO
 * @typedef {import('../dtos/belege.js').VorgangStatusDTO} VorgangStatusDTO
 * @typedef {import('../dtos/belege.js').VorgangStatusTableDTO} VorgangStatusTableDTO
 * @typedef {import('../dtos/belege.js').BaseListItemDTO} BaseListItemDTO
 * @typedef {import('../dtos/belege.js').VorgangHistorienDTO} VorgangHistorienDTO
 * @typedef {import('../dtos/belege.js').BelegHistorienDTO} BelegHistorienDTO
 * @typedef {import('../dtos/belege.js').BelegPositionHistorienDTO} BelegPositionHistorienDTO
 * @typedef {import('../dtos/av.js').SerieHistorieDTO} SerieHistorieDTO
 * @typedef {import('../dtos/belege.js').VorgangHistorieDTO} VorgangHistorieDTO
 * @typedef {import('../dtos/belege.js').BelegHistorieDTO} BelegHistorieDTO
 * @typedef {import('../dtos/belege.js').BelegPositionHistorieDTO} BelegPositionHistorieDTO
 */

/**
 * Beleg API - Document and process management
 * @param {FluentApi} fluentApi
 */
export function createBelegApi(fluentApi) {
    return {
    // BelegStatusWebRoutinen
    /**
     * Get beleg status
     * @param {string} belegGuid
     * @returns {Promise<BelegStatusDTO>}
     */
        getBelegStatus: (belegGuid) => fluentApi.get(`BelegStatus?id=${belegGuid}`),

        /**
     * Set beleg status
     * @param {string} belegGuid
     * @param {string} statusCode
     * @param {string} [statusText]
     * @returns {Promise<BelegStatusDTO>}
     */
        setBelegStatus: (belegGuid, statusCode, statusText = "") =>
            fluentApi.put("BelegStatus", { belegGuid, neuerStatus: statusCode, neuerStatusText: statusText }),

        // BelegArtWebRoutinen
        /**
     * Copy beleg with new beleg art
     * @param {string} belegGuid
     * @param {string} neueBelegArt
     * @param {boolean} [saldenKopieren=false]
     * @returns {Promise<VorgangDTO>}
     */
        belegKopieren: (belegGuid, neueBelegArt, saldenKopieren = false) =>
            fluentApi.post(`BelegArt?bguid=${belegGuid}&saldenKopieren=${saldenKopieren}&neueBelegArt=${neueBelegArt}`, {}),

        // BelegArtPosWebRoutinen
        /**
     * Change beleg art for position
     * @param {BelegartWechselDTO} dto
     * @returns {Promise<VorgangDTO>}
     */
        belegWechsel: (dto) => fluentApi.put("BelegArtPos", dto),

        // BelegLoeschenWebRoutinen
        /**
     * Delete beleg
     * @param {string} belegGuid
     * @returns {Promise<VorgangDTO>}
     */
        belegLoeschen: (belegGuid) => fluentApi.delete(`Vorgang/DeleteBeleg/${belegGuid}`),

        // VorgangListeWebRoutinen
        /**
     * Load vorgang list by year
     * @param {number} jahr
     * @param {boolean} [includeASP=false]
     * @param {boolean} [includeAdditionalProperties=false]
     * @returns {Promise<VorgangListItemDTO[]>}
     */
        ladeVorgangsListeByJahr: (jahr, includeASP = false, includeAdditionalProperties = false) =>
            fluentApi.get(`VorgangListe/?jahr=${jahr}&includeASP=${includeASP}&includeAdditionalProperties=${includeAdditionalProperties}`),

        /**
     * Load vorgang list by status and year
     * @param {string} status
     * @param {number} jahr
     * @param {boolean} [includeASP=false]
     * @param {boolean} [includeAdditionalProperties=false]
     * @returns {Promise<VorgangListItemDTO[]>}
     */
        ladeVorgangsListeByStatus: (status, jahr, includeASP = false, includeAdditionalProperties = false) =>
            fluentApi.get(`VorgangListe/?status=${status}&jahr=${jahr}&includeASP=${includeASP}&includeAdditionalProperties=${includeAdditionalProperties}`),

        /**
     * Load vorgang list by status, year, and change date
     * @param {string} status
     * @param {number} jahr
     * @param {Date} changedSince
     * @param {boolean} [includeASP=false]
     * @param {boolean} [includeAdditionalProperties=false]
     * @returns {Promise<VorgangListItemDTO[]>}
     */
        ladeVorgangsListeByStatusAndDate: (status, jahr, changedSince, includeASP = false, includeAdditionalProperties = false) =>
            fluentApi.get(`VorgangListe/?status=${status}&jahr=${jahr}&changedSince=${changedSince.toISOString()}&includeASP=${includeASP}&includeAdditionalProperties=${includeAdditionalProperties}`),

        /**
     * Load vorgang list with full filters
     * @param {number} jahr
     * @param {string} status
     * @param {Date} changedSince
     * @param {string} [art]
     * @param {boolean} [includeArchive=false]
     * @param {boolean} [includeOthersData=false]
     * @param {string} [search]
     * @param {boolean} [includeASP=false]
     * @param {boolean} [includeAdditionalProperties=false]
     * @returns {Promise<VorgangListItemDTO[]>}
     */
        ladeVorgangsListe: (jahr, status, changedSince, art = "", includeArchive = false, includeOthersData = false, search = "", includeASP = false, includeAdditionalProperties = false) =>
            fluentApi.get(`VorgangListe/?status=${status}&jahr=${jahr}&changedSince=${changedSince.toISOString()}&art=${art}&includeArchive=${includeArchive}&includeOthersData=${includeOthersData}&search=${search}&includeASP=${includeASP}&includeAdditionalProperties=${includeAdditionalProperties}`),

        /**
     * Load vorgang list by customer
     * @param {string} kundeGuid
     * @returns {Promise<VorgangListItemDTO[]>}
     */
        ladeVorgangsListeByKunde: (kundeGuid) => fluentApi.get(`VorgangListe/?kundeGuid=${kundeGuid}`),

        // VorgangStatusTableWebRoutinen
        /**
     * Update vorgang status table for function
     * @param {VorgangStatusTableDTO} dto
     * @returns {Promise<void>}
     */
        updateVorgangStatusTableForFunction: (dto) => fluentApi.post("VorgangStatus/UpdateVorgangStatusTableForFunction", dto),

        /**
     * Get not calculated vorgang status table for function
     * @returns {Promise<VorgangStatusTableDTO[]>}
     */
        getNotCalculatedVorgangStatusTableForFunction: () =>
            fluentApi.get("VorgangStatus/GetNotCalculatedVorgangStatusTableForFunction"),

        // VorgangReaktivierenWebRoutinen
        /**
     * Reactivate vorgang
     * @param {BelegartWechselDTO} dto
     * @returns {Promise<VorgangDTO>}
     */
        vorgangReaktivieren: (dto) => fluentApi.put("VorgangReaktivieren", dto),

        // LieferscheineWebRoutinen
        /**
     * Load delivery note list by year
     * @param {number} jahr
     * @returns {Promise<BaseListItemDTO[]>}
     */
        ladeLieferscheinListeByJahr: (jahr) => fluentApi.get(`Lieferscheine/?jahr=${jahr}`),

        /**
     * Load delivery note list by status and year
     * @param {string} status
     * @param {number} jahr
     * @returns {Promise<BaseListItemDTO[]>}
     */
        ladeLieferscheinListeByStatus: (status, jahr) => fluentApi.get(`Lieferscheine/?status=${status}&jahr=${jahr}`),

        /**
     * Load delivery note list by status, year, and change date
     * @param {string} status
     * @param {number} jahr
     * @param {Date} changedSince
     * @returns {Promise<BaseListItemDTO[]>}
     */
        ladeLieferscheinListeByStatusAndDate: (status, jahr, changedSince) =>
            fluentApi.get(`Lieferscheine/?status=${status}&jahr=${jahr}&changedSince=${changedSince.toISOString()}`),

        /**
     * Load delivery note list with full filters
     * @param {number} jahr
     * @param {string} status
     * @param {Date} changedSince
     * @param {string} [art]
     * @param {boolean} [includeArchive=false]
     * @param {boolean} [includeOthersData=false]
     * @param {string} [search]
     * @returns {Promise<BaseListItemDTO[]>}
     */
        ladeLieferscheinListe: (jahr, status, changedSince, art = "", includeArchive = false, includeOthersData = false, search = "") =>
            fluentApi.get(`Lieferscheine/?status=${status}&jahr=${jahr}&changedSince=${changedSince.toISOString()}&art=${art}&includeArchive=${includeArchive}&includeOthersData=${includeOthersData}&search=${search}`),

        /**
     * Get vorgang by delivery note GUID
     * @param {string} lieferscheinGuid
     * @returns {Promise<VorgangDTO>}
     */
        getVorgangByLieferscheinGuid: (lieferscheinGuid) => fluentApi.get(`Lieferscheine/${lieferscheinGuid}`),

        /**
     * Get vorgang status
     * @param {string} vorgangGuid
     * @returns {Promise<VorgangStatusDTO>}
     */
        getLieferscheinStatus: (vorgangGuid) => fluentApi.get(`VorgangStatus/${vorgangGuid}`),

        /**
     * Set vorgang status
     * @param {string} vorgangGuid
     * @param {string} statusCode
     * @returns {Promise<VorgangStatusDTO>}
     */
        setLieferscheinStatus: (vorgangGuid, statusCode) =>
            fluentApi.put("VorgangStatus", { vorgangGuid, neuerStatus: statusCode }),

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

        // PositionStornoWebRoutinen
        /**
     * Storniere position
     * @param {string} positionGuid
     * @returns {Promise<void>}
     */
        positionStornieren: (positionGuid) =>
            fluentApi.post(`PositionStorno?posGuid=${positionGuid}`, null),

        /**
     * Storniere beleg
     * @param {string} belegGuid
     * @returns {Promise<void>}
     */
        belegStornieren: (belegGuid) =>
            fluentApi.post(`BelegStorno?belegGuid=${belegGuid}`, null),

        // FremdfertigungWebRoutinen
        /**
     * Order external production
     * @param {string} belegGuid
     * @returns {Promise<void>}
     */
        fremdfertigungBestellen: (belegGuid) =>
            fluentApi.put(`Fremdfertigung/?bguid=${belegGuid}`, null),
    };
}

/**
 * @typedef {ReturnType<typeof createBelegApi>} BelegApi
 */
