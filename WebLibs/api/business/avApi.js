/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').BelegPositionAVDTO} BelegPositionAVDTO
 * @typedef {import('../dtos/index.js').PositionSerieItemDTO} PositionSerieItemDTO
 * @typedef {import('../dtos/produktion.js').BerechnungParameterDTO} BerechnungParameterDTO
 * @typedef {import('../dtos/produktion.js').ProduktionsDatenDTO} ProduktionsDatenDTO
 * @typedef {import('../dtos/index.js').AVReserviertItemDTO} AVReserviertItemDTO
 * @typedef {import('../dtos/belege.js').CalculationInfoDTO} CalculationInfoDTO
 * @typedef {Object} AvReportVorgangRequestDto
 * @typedef {Object} AvReportVorgangDto
 * @typedef {import('../dtos/produktion.js').SaegeDatenHistorieDTO} SaegeDatenHistorieDTO
 * @typedef {import('../dtos/produktion.js').SaegeDatenResultDTO} SaegeDatenResultDTO
 * @typedef {import('../dtos/index.js').MaterialBearbeitungsMethodeDTO} MaterialBearbeitungsMethodeDTO
 * @typedef {import('../dtos/index.js').MaterialbedarfDTO} MaterialbedarfDTO
 * @typedef {import('../dtos/index.js').MandantAndBelegPosGuidDTO} MandantAndBelegPosGuidDTO
 * @typedef {import('../dtos/av.js').SerienMaterialEditDTO} SerienMaterialEditDTO
 */

/**
 * AV API - Arbeitsvorbereitung (work preparation) management
 * @param {FluentApi} fluentApi
 */
export function createAvApi(fluentApi) {
    return {
        // AVWebRoutinen
        /**
         * Get all AV positions
         * @param {boolean} [includeOriginalBeleg=true]
         * @param {boolean} [includeProdDaten=true]
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        getAll: (includeOriginalBeleg = true, includeProdDaten = true) =>
            fluentApi.get(`BelegPositionenAV?includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`),

        /**
         * Get all AV positions changed since date
         * @param {Date} changedSince
         * @param {boolean} [includeOriginalBeleg=true]
         * @param {boolean} [includeProdDaten=true]
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        getAllChangedSince: (changedSince, includeOriginalBeleg = true, includeProdDaten = true) =>
            fluentApi.get(`BelegPositionenAV/?changedSince=${changedSince.toISOString()}&includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`),

        /**
         * Get AV positions by serie
         * @param {string} serieGuid
         * @param {boolean} [includeOriginalBeleg=true]
         * @param {boolean} [includeProdDaten=true]
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        getBySerie: (serieGuid, includeOriginalBeleg = true, includeProdDaten = true) =>
            fluentApi.get(`BelegPositionenAV/?serieGuid=${serieGuid}&includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`),

        /**
         * Get AV positions by vorgang
         * @param {string} vorgangGuid
         * @param {boolean} [includeOriginalBeleg=true]
         * @param {boolean} [includeProdDaten=true]
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        getByVorgang: (vorgangGuid, includeOriginalBeleg = true, includeProdDaten = true) =>
            fluentApi.get(`BelegPositionenAV/?vorgangGuid=${vorgangGuid}&includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`),

        /**
         * Get AV positions by multiple vorgang GUIDs
         * @param {string[]} vorgangGuids
         * @param {boolean} [includeOriginalBeleg=true]
         * @param {boolean} [includeProdDaten=true]
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        getByVorgangGuids: (vorgangGuids, includeOriginalBeleg = true, includeProdDaten = true) => {
            const guidsString = vorgangGuids.join("&vorgangGuids=");
            return fluentApi.get(`BelegPositionenAVByVorgangIds/?vorgangGuids=${guidsString}&includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`);
        },

        /**
         * Get AV positions by beleg position GUID
         * @param {string} belegpositionGuid
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        getByBelegPosition: (belegpositionGuid) =>
            fluentApi.get(`BelegPositionenAV/${belegpositionGuid}`),

        /**
         * Get single AV position by GUID
         * @param {string} avGuid
         * @returns {Promise<BelegPositionAVDTO>}
         */
        getById: (avGuid) => fluentApi.get(`BelegPositionenAVById/${avGuid}`),

        /**
         * Get AV positions by PCode
         * @param {string} pcode
         * @param {boolean} [includeOriginalBeleg=true]
         * @param {boolean} [includeProdDaten=true]
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        getByPCode: (pcode, includeOriginalBeleg = true, includeProdDaten = true) =>
            fluentApi.get(`BelegPositionenAVByPCode/${pcode}?includeOriginalBeleg=${includeOriginalBeleg}&includeProdDaten=${includeProdDaten}`),

        /**
         * Search AV positions by PCode
         * @param {string} search
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        searchByPCode: (search) =>
            fluentApi.get(`BelegPositionenAVSearchByPCode?search=${encodeURIComponent(search)}`),

        /**
         * Save AV position
         * @param {BelegPositionAVDTO} position
         * @returns {Promise<void>}
         */
        save: (position) => fluentApi.put("BelegPositionenAV", position),

        /**
         * Save multiple AV positions
         * @param {BelegPositionAVDTO[]} positionen
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        saveList: (positionen) => fluentApi.put("BelegPositionenAVBulk", positionen),

        /**
         * Save AV positions to serie
         * @param {string} serieGuid
         * @param {string[]} positionGuids
         * @returns {Promise<BelegPositionAVDTO[]>}
         */
        saveToSerie: (serieGuid, positionGuids) =>
            fluentApi.put(`BelegPositionenAVBulk/AddToSerie/${serieGuid}`, positionGuids),

        /**
         * Calculate AV positions
         * @param {string[]} guids
         * @returns {Promise<void>}
         */
        berechnen: (guids) => fluentApi.put("BelegPositionenAVBulk/AVBerechnung", guids),

        /**
         * Delete AV position
         * @param {string} guid
         * @returns {Promise<void>}
         */
        delete: (guid) => fluentApi.delete(`BelegPositionenAV/${guid}`),

        /**
         * Delete multiple AV positions
         * @param {string[]} guids
         * @returns {Promise<void>}
         */
        deleteList: (guids) => fluentApi.delete("BelegPositionenAVBulk", guids),

        /**
         * Assign positions to series
         * @param {string} belegGuid
         * @param {PositionSerieItemDTO[]} positionSerieItems
         * @returns {Promise<void>}
         */
        serienZuordnen: (belegGuid, positionSerieItems) =>
            fluentApi.put(`BelegPositionenAVBulk/SerienZuorden/${belegGuid}`, positionSerieItems),

        // AVPreProzessWebRoutinen
        /**
         * Pre-process calculation
         * @param {BerechnungParameterDTO} dto
         * @returns {Promise<BerechnungParameterDTO>}
         */
        preProcess: (dto) => fluentApi.put("AVPreProcess", dto),

        // AVPostProzessWebRoutinen
        /**
         * Post-process calculation
         * @param {BelegPositionAVDTO} dto
         * @returns {Promise<ProduktionsDatenDTO>}
         */
        postProcess: (dto) => fluentApi.put("AVPostProcess", dto),

        // AVReserviertWebRoutinen
        reserviert: {
            /**
             * Get all reserved AV items
             * @returns {Promise<AVReserviertItemDTO[]>}
             */
            getAll: () => fluentApi.get("AVReserviert"),

            /**
             * Get reserved AV items by serie
             * @param {string} serieGuid
             * @returns {Promise<AVReserviertItemDTO[]>}
             */
            getBySerie: (serieGuid) => fluentApi.get(`AVReserviert/?serieGuid=${serieGuid}`),
        },

        // BelegPositionenAVWebRoutinen - Additional calculation methods
        /**
         * Run AV calculation for position
         * @param {string} id
         * @param {number} mandantId
         * @returns {Promise<void>}
         */
        runAvBerechnung: (id, mandantId) =>
            fluentApi.post(`BelegPositionenAV/RunAVBerechnung/${id}?mandantId=${mandantId}`, null),

        /**
         * Calculate items
         * @returns {Promise<void>}
         */
        calculateItems: () =>
            fluentApi.post("BelegPositionenAV/CalculateItems", null),

        /**
         * Get calculate item list
         * @returns {Promise<MandantAndBelegPosGuidDTO[]>}
         */
        getCalculateItemList: () =>
            fluentApi.get("BelegPositionenAV/GetCalculateItemList"),

        /**
         * Check AV position count
         * @param {string} belegPosGuid
         * @param {number} mandantId
         * @returns {Promise<string[]>}
         */
        checkAvPositionCount: (belegPosGuid, mandantId) =>
            fluentApi.put(`BelegPositionenAV/CheckAVPositionCount?mandantId=${mandantId}&belegPosGuid=${belegPosGuid}`, null),

        // AVBerechnungCloudRoutinen
        /**
         * Process AV calculation in cloud
         * @param {BerechnungParameterDTO} parameter
         * @returns {Promise<BerechnungParameterDTO>}
         */
        avBerechnungCloudProcess: (parameter) =>
            fluentApi.post("ProcessIbos/Process", parameter),

        /**
         * Calculate AV position
         * @param {number} mandantId
         * @param {string} avPosGuid
         * @returns {Promise<void>}
         */
        calculateAvPosition: (mandantId, avPosGuid) =>
            fluentApi.post(`ProcessIbos/CalculateAVPosition?mandantId=${mandantId}&avPosGuid=${avPosGuid}`, null),

        // CalculationInfoWebRoutinen
        /**
         * Put calculation info
         * @param {CalculationInfoDTO} calculationInfoDTO
         * @returns {Promise<CalculationInfoDTO>}
         */
        putCalculationInfo: (calculationInfoDTO) =>
            fluentApi.put("CalculationInfo", calculationInfoDTO),

        /**
         * Get calculation info
         * @param {number} mandantId
         * @param {string} belegPosGuid
         * @returns {Promise<CalculationInfoDTO>}
         */
        getCalculationInfo: (mandantId, belegPosGuid) =>
            fluentApi.get(`CalculationInfo?mandantId=${mandantId}&belegPosGuid=${belegPosGuid}`),

        /**
         * Get incomplete calculation infos
         * @returns {Promise<CalculationInfoDTO[]>}
         */
        getIncompleteCalculationInfos: () =>
            fluentApi.get("CalculationInfo/Incomplete"),

        /**
         * Get in-calculation count
         * @returns {Promise<number>}
         */
        getInCalculationCount: () => fluentApi.get("CalculationInfo/InCalculationCount"),

        // KapazitaetsberechnungWebRoutinen
        /**
         * Calculate capacity for function
         * @param {string} positionGuid
         * @param {number} mandantID
         * @returns {Promise<void>}
         */
        calculateKapazitaetForFunction: (positionGuid, mandantID) =>
            fluentApi.post(`Kapaziaetsberechnung/RunKapBerechnung?id=${positionGuid}&mandantId=${mandantID}`, null),

        /**
         * Calculate capacity for AV
         * @param {string[]} avPositionGuids
         * @param {number} mandantID
         * @returns {Promise<void>}
         */
        calculateKapazitaetForAv: (avPositionGuids, mandantID) =>
            fluentApi.post(`Kapaziaetsberechnung/RunKapBerechnungForAV?mandantId=${mandantID}`, avPositionGuids),

        /**
         * Calculate capacity items
         * @returns {Promise<void>}
         */
        calculateKapazitaetItems: () =>
            fluentApi.post("Kapaziaetsberechnung/CalculateItems"),

        // AvReportDataWebRoutinen
        /**
         * Get AV report vorgaenge
         * @param {AvReportVorgangRequestDto} request
         * @returns {Promise<AvReportVorgangDto[]>}
         */
        getAvReportVorgaenge: (request) =>
            fluentApi.post("avreportdata/vorgaenge", request),

        // SaegeDatenHistorieWebRoutinen
        /**
         * Get saw data history
         * @param {string} saegeDatenHistorieGuid
         * @param {boolean} [includeSaegeDatei=true]
         * @param {boolean} [includeMeldungen=true]
         * @returns {Promise<SaegeDatenHistorieDTO>}
         */
        getSaegeDatenHistorie: (saegeDatenHistorieGuid, includeSaegeDatei = true, includeMeldungen = true) =>
            fluentApi.get(`SaegeDatenHistorie/?saegeDatenHistorieGuid=${saegeDatenHistorieGuid}&includeSaegeDatei=${includeSaegeDatei}&includeMeldungen=${includeMeldungen}`).then(r => r?.[0]),

        /**
         * Get saw data history for serie
         * @param {string} serieGuid
         * @param {boolean} [includeSaegeDatei=false]
         * @param {boolean} [includeMeldungen=false]
         * @returns {Promise<SaegeDatenHistorieDTO[]>}
         */
        getSaegeDatenHistorieForSerie: (serieGuid, includeSaegeDatei = false, includeMeldungen = false) =>
            fluentApi.get(`SaegeDatenHistorie/?serieGuid=${serieGuid}&includeSaegeDatei=${includeSaegeDatei}&includeMeldungen=${includeMeldungen}`),

        /**
         * Get saw data history since date
         * @param {Date} sinceWhen
         * @param {boolean} [includeSaegeDatei=false]
         * @param {boolean} [includeMeldungen=false]
         * @returns {Promise<SaegeDatenHistorieDTO[]>}
         */
        getSaegeDatenHistorieSince: (sinceWhen, includeSaegeDatei = false, includeMeldungen = false) =>
            fluentApi.get(`SaegeDatenHistorie/?createdSince=${sinceWhen.toISOString()}&includeSaegeDatei=${includeSaegeDatei}&includeMeldungen=${includeMeldungen}`),

        /**
         * Save saw data history
         * @param {SaegeDatenHistorieDTO} dto
         * @returns {Promise<SaegeDatenResultDTO>}
         */
        saveSaegeDatenHistorie: (dto) =>
            fluentApi.put("SaegeDatenHistorie", dto),

        /**
         * Save saw data history bulk
         * @param {SaegeDatenHistorieDTO[]} dtos
         * @returns {Promise<void>}
         */
        saveSaegeDatenHistorieBulk: (dtos) =>
            fluentApi.put("SaegeDatenHistorie/SaveBulk", dtos),

        // MaterialBearbeitungenWebRoutinen
        /**
         * Get all material processing methods
         * @returns {Promise<MaterialBearbeitungsMethodeDTO[]>}
         */
        getAllMaterialBearbeitungsMethoden: () =>
            fluentApi.get("MaterialBearbeitungsMethoden"),

        /**
         * Save material processing method
         * @param {MaterialBearbeitungsMethodeDTO} dto
         * @returns {Promise<void>}
         */
        saveMaterialBearbeitungsMethode: (dto) =>
            fluentApi.put("MaterialBearbeitungsMethoden", dto),

        // SerienMaterialBerechnenWebRoutinen
        material: {
            /**
             * Calculate material for serie
             * @param {string} serieGuid
             * @returns {Promise<void>}
             */
            serieBerechnen: (serieGuid) =>
                fluentApi.post("SerieMaterialbedarfBerechnen", serieGuid),

            /**
             * Get material for serie
             * @param {string} serieGuid
             * @returns {Promise<MaterialbedarfDTO[]>}
             */
            getForSerie: (serieGuid) =>
                fluentApi.get(`SerieMaterialbedarfBerechnen?serieGuid=${serieGuid}`),

            /**
             * Get open material requirements for serie v2
             * @param {string} serieGuid
             * @param {boolean} [filterCsvExportedMaterial=true]
             * @returns {Promise<MaterialbedarfDTO[]>}
             */
            getOffenerBedarfV2: (serieGuid, filterCsvExportedMaterial = true) =>
                fluentApi.get(`SerieOffenerMaterialbedarf?serieGuid=${serieGuid}&filterCsvExportedMaterial=${filterCsvExportedMaterial}`),

            /**
             * Get open material requirements for serie
             * @param {string} serieGuid
             * @returns {Promise<MaterialbedarfDTO[]>}
             */
            getOffenerBedarf: (serieGuid) =>
                fluentApi.get(`SerieOffenerMaterialbedarf?serieGuid=${serieGuid}`),

            /**
             * Reset material for serie
             * @param {string} serieGuid
             * @returns {Promise<void>}
             */
            resetForSerie: (serieGuid) =>
                fluentApi.delete(`SerieMaterialbedarfBerechnen?serieGuid=${serieGuid}`),

            /**
             * Calculate material bedarf for function
             * @param {string} serieGuid
             * @param {number} mandantId
             * @returns {Promise<string[]>}
             */
            berechnenForFunction: (serieGuid, mandantId) =>
                fluentApi.put(`SerieMaterialbedarfBerechnen/ForFunction?mandantId=${mandantId}&serieGuid=${serieGuid}`, null),

            /**
             * Reset material bedarf from AV position for function
             * @param {string} avPosGuid
             * @param {number} mandantId
             * @returns {Promise<string[]>}
             */
            resetFromAvPosForFunction: (avPosGuid, mandantId) =>
                fluentApi.put(`SerieMaterialbedarfBerechnen/ResetFromAvPosForFunction?mandantId=${mandantId}&avPosGuid=${avPosGuid}`, null),

            // SerienMaterialEditWebRoutinen
            /**
             * Add or update serie material
             * @param {MaterialbedarfDTO} dto
             * @returns {Promise<SerienMaterialEditDTO>}
             */
            addOrUpdate: (dto) =>
                fluentApi.put("SerieMaterialbedarfEdit", dto),

            /**
             * Delete serie material
             * @param {string} materialbedarfGuid
             * @returns {Promise<void>}
             */
            delete: (materialbedarfGuid) =>
                fluentApi.delete(`SerieMaterialbedarfEdit?bedarfGuid=${materialbedarfGuid}`),
        },
    };
}

/**
 * @typedef {ReturnType<typeof createAvApi>} AvApi
 */
