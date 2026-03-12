/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/produktion.js').BearbeitungDTO} BearbeitungDTO
 * @typedef {import('../dtos/produktion.js').MaterialbedarfDTO} MaterialbedarfDTO
 * @typedef {import('../dtos/belege.js').VorgangDTO} VorgangDTO
 * @typedef {import('../dtos/belege.js').BelegartWechselDTO} BelegartWechselDTO
 * @typedef {import('../dtos/produktion.js').ProduktionsStatusDTO} ProduktionsStatusDTO
 * @typedef {import('../dtos/produktion.js').ProduktionsStatusHistorieDTO} ProduktionsStatusHistorieDTO
 * @typedef {import('../dtos/produktion.js').ProduktionsfreigabeItemDTO} ProduktionsfreigabeItemDTO
 * @typedef {import('../dtos/produktion.js').ProduktionsInfoDTO} ProduktionsInfoDTO
 */

/**
 * Produktion API - Production and manufacturing management
 * @param {FluentApi} fluentApi
 */
export function createProduktionApi(fluentApi) {
    return {
        // ProduktionWebRoutinen
        /**
         * Calculate production for position
         * @param {string} belegPositionsGuid
         * @returns {Promise<string>}
         */
        produktionBerechnen: (belegPositionsGuid) =>
            fluentApi.get(`Script/PosBerechnen?pguid=${belegPositionsGuid}`),

        /**
         * Get production for position
         * @param {string} belegPositionsGuid
         * @returns {Promise<BearbeitungDTO[]>}
         */
        getProduktion: (belegPositionsGuid) =>
            fluentApi.get(`Produktion/?posguid=${belegPositionsGuid}`),

        /**
         * Get material requirements for position
         * @param {string} belegPositionsGuid
         * @returns {Promise<MaterialbedarfDTO[]>}
         */
        getMaterialBedarf: (belegPositionsGuid) =>
            fluentApi.get(`MaterialBedarf/?posguid=${belegPositionsGuid}`),

        // ProduktionsfreigabeWebRoutinen
        /**
         * Add production release
         * @param {BelegartWechselDTO} dto
         * @returns {Promise<VorgangDTO>}
         */
        addProduktionsfreigabe: (dto) => fluentApi.put("Produktionsfreigabe", dto),

        /**
         * Run production release web job
         * @returns {Promise<void>}
         */
        produktionsfreigabeWebJob: () => fluentApi.post("Produktionsfreigabe/WebJob", null),

        // ProduktionsfreigabeListeWebRoutinen
        /**
         * Get all production release items
         * @returns {Promise<ProduktionsfreigabeItemDTO[]>}
         */
        getAllProduktionsfreigabeItems: () => fluentApi.get("ProduktionsfreigabeListe"),

        // ProduktionsfreigabeInfoWebRoutinen
        /**
         * Get production release info for belege
         * @param {string[]} belegGuids
         * @returns {Promise<Record<string, Date>>}
         */
        getProduktionsfreigabeInfo: (belegGuids) =>
            fluentApi.put("ProduktionsfreigabeInfo", belegGuids),

        // ProduktionsStatusWebRoutinen
        /**
         * Get all production statuses
         * @returns {Promise<ProduktionsStatusDTO[]>}
         */
        getAllProduktionsStatus: () => fluentApi.get("ProduktionsStatus"),

        /**
         * Get production status by GUID
         * @param {string} guid
         * @returns {Promise<ProduktionsStatusDTO>}
         */
        getProduktionsStatus: (guid) => fluentApi.get(`ProduktionsStatus/${guid}`),

        /**
         * Save production status
         * @param {ProduktionsStatusDTO} status
         * @returns {Promise<void>}
         */
        saveProduktionsStatus: (status) => fluentApi.put("ProduktionsStatus", status),

        /**
         * Save production status history
         * @param {string} avGuid
         * @param {ProduktionsStatusHistorieDTO} historie
         * @returns {Promise<void>}
         */
        saveProduktionsStatusHistorie: (avGuid, historie) =>
            fluentApi.put(`ProduktionsStatus/AddHistorie/${avGuid}`, historie),

        // ProduktionsInfoWebRoutinen
        /**
         * Get production info for vorgang
         * @param {string} vorgangGuid
         * @returns {Promise<ProduktionsInfoDTO>}
         */
        getProduktionsInfo: (vorgangGuid) => fluentApi.get(`ProduktionsInfo?vorgangGuid=${vorgangGuid}`),

        // IBOS1Routinen
        /**
         * Calculate IBOS1 production
         * @param {string} belegPositionsGuid
         * @returns {Promise<string>}
         */
        ibos1ProduktionBerechnen: (belegPositionsGuid) =>
            fluentApi.get(`IBOS1/Print?bguid=${belegPositionsGuid}`),

        /**
         * Test IBOS1 position
         * @param {string} belegPositionsGuid
         * @returns {Promise<string>}
         */
        ibos1PositionTesten: (belegPositionsGuid) =>
            fluentApi.get(`Test?bguid=${belegPositionsGuid}`),

        /**
         * Get IBOS1 production
         * @param {string} guid
         * @returns {Promise<string>}
         */
        getIbos1Produktion: (guid) =>
            fluentApi.get(`Produktion/?posguid=${guid}`),
    };
}

/**
 * @typedef {ReturnType<typeof createProduktionApi>} ProduktionApi
 */
