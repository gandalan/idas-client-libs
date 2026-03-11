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
 * @typedef {import('../dtos/index.js').MandantAndBelegPosGuidDTO} MandantAndBelegPosGuidDTO
 * @typedef {import('../dtos/produktion.js').BelegPositionAVDTO} BelegPositionAVDTO
 * @typedef {import('../dtos/produktion.js').ProduktionsDatenDTO} ProduktionsDatenDTO
 * @typedef {import('../dtos/produktion.js').BerechnungParameterDTO} BerechnungParameterDTO
 * @typedef {import('../dtos/index.js').AVReserviertItemDTO} AVReserviertItemDTO
 * @typedef {import('../dtos/belege.js').CalculationInfoDTO} CalculationInfoDTO
 * @typedef {import('../dtos/produktion.js').AblageDTO} AblageDTO
 * @typedef {import('../dtos/produktion.js').FachzuordnungResultDTO} FachzuordnungResultDTO
 * @typedef {import('../dtos/produktion.js').AvReportVorgangRequestDto} AvReportVorgangRequestDto
 * @typedef {import('../dtos/produktion.js').AvReportVorgangDto} AvReportVorgangDto
 * @typedef {import('../dtos/produktion.js').SaegeDatenHistorieDTO} SaegeDatenHistorieDTO
 * @typedef {import('../dtos/produktion.js').SaegeDatenResultDTO} SaegeDatenResultDTO
 * @typedef {import('../dtos/index.js').MaterialBearbeitungsMethodeDTO} MaterialBearbeitungsMethodeDTO
 * @typedef {import('../dtos/produktion.js').SerienMaterialEditDTO} SerienMaterialEditDTO
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

        // BelegPositionenAVWebRoutinen
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

        // AVPostProzessWebRoutinen
        /**
     * Calculate AV post process
      * @param {BelegPositionAVDTO} dto
      * @returns {Promise<ProduktionsDatenDTO>}
     */
        avPostProzessBerechnen: (dto) => fluentApi.put("AVPostProcess", dto),

        // AVPreProzessWebRoutinen
        /**
     * Calculate AV pre process
      * @param {BerechnungParameterDTO} dto
      * @returns {Promise<BerechnungParameterDTO>}
     */
        avPreProzessBerechnen: (dto) => fluentApi.put("AVPreProcess", dto),

        // AVReserviertWebRoutinen
        /**
     * Get all AV reserved items
      * @returns {Promise<AVReserviertItemDTO[]>}
     */
        getAllAvReserviertItems: () => fluentApi.get("AVReserviert"),

        /**
     * Get AV reserved items by serie
     * @param {string} serieGuid
     * @returns {Promise<AVReserviertItemDTO[]>}
     */
        getAvReserviertItemsBySerie: (serieGuid) =>
            fluentApi.get(`AVReserviert/?serieGuid=${serieGuid}`),

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
     * Get capacity for positions
     * @param {string[]} positionGuids
     * @returns {Promise<Record<string, number | null>>}
     */
        getKapazitaet: (positionGuids) =>
            fluentApi.post("Kapaziaetsberechnung/GetKapaziaet", positionGuids),

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

        // AblageWebRoutinen
        /**
     * Get storage by GUID
     * @param {string} guid
      * @returns {Promise<AblageDTO>}
     */
        getAblage: (guid) => fluentApi.get(`Ablage/?id=${guid}`),

        /**
     * Get all storage items
     * @param {Date} [changedSince]
     * @param {boolean} [includeDetails=true]
      * @returns {Promise<AblageDTO[]>}
     */
        getAllAblagen: (changedSince, includeDetails = true) => {
            if (changedSince) {
                return fluentApi.get(`Ablage?changedSince=${changedSince.toISOString()}&includeDetails=${includeDetails}`);
            }
            return fluentApi.get(`Ablage?includeDetails=${includeDetails}`);
        },

        /**
     * Save storage
      * @param {AblageDTO} dto
     * @returns {Promise<void>}
     */
        saveAblage: (dto) => fluentApi.put("Ablage/", dto),

        /**
     * Delete storage
     * @param {string} guid
     * @returns {Promise<void>}
     */
        deleteAblage: (guid) => fluentApi.delete(`Ablage/?id=${guid}`),

        /**
     * Calculate serie compartment distribution
     * @param {string} serieGuid
     * @returns {Promise<FachzuordnungResultDTO>}
     */
        serienFachverteilung: (serieGuid) =>
            fluentApi.put(`Ablage/SerienFachverteilung/${serieGuid}`, null),

        /**
     * Calculate compartment distribution
     * @param {string[]} avGuids
     * @returns {Promise<FachzuordnungResultDTO>}
     */
        fachverteilung: (avGuids) =>
            fluentApi.put("Ablage/Fachverteilung", avGuids),

        // AvReportDataWebRoutinen
        /**
     * Get AV report vorgaenge
     * @param {AvReportVorgangRequestDto} request
     * @returns {Promise<AvReportVorgangDto[]>}
     */
        getAvReportVorgaenge: (request) =>
            fluentApi.post("avreportdata/vorgaenge", request),

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
        /**
     * Calculate material for serie
     * @param {string} serieGuid
     * @param {boolean} [sfZusammenfassen=false]
     * @param {boolean} [serieZusammenfassen=false]
     * @returns {Promise<void>}
     */
        serieMaterialBerechnen: (serieGuid, sfZusammenfassen = false, serieZusammenfassen = false) =>
            fluentApi.post("SerieMaterialbedarfBerechnen", serieGuid),

        /**
     * Get material for serie
     * @param {string} serieGuid
     * @returns {Promise<MaterialbedarfDTO[]>}
     */
        getSerieMaterial: (serieGuid) =>
            fluentApi.get(`SerieMaterialbedarfBerechnen?serieGuid=${serieGuid}`),

        /**
     * Get open material requirements for serie v2
     * @param {string} serieGuid
     * @param {boolean} [filterCsvExportedMaterial=true]
     * @returns {Promise<MaterialbedarfDTO[]>}
     */
        getSerieOffenerMaterialBedarfV2: (serieGuid, filterCsvExportedMaterial = true) =>
            fluentApi.get(`SerieOffenerMaterialbedarf?serieGuid=${serieGuid}&filterCsvExportedMaterial=${filterCsvExportedMaterial}`),

        /**
     * Get open material requirements for serie
     * @param {string} serieGuid
     * @returns {Promise<MaterialbedarfDTO[]>}
     */
        getSerieOffenerMaterialBedarf: (serieGuid) =>
            fluentApi.get(`SerieOffenerMaterialbedarf?serieGuid=${serieGuid}`),

        /**
     * Reset material for serie
     * @param {string} serieGuid
     * @returns {Promise<void>}
     */
        resetSerieMaterial: (serieGuid) =>
            fluentApi.delete(`SerieMaterialbedarfBerechnen?serieGuid=${serieGuid}`),

        /**
     * Calculate material bedarf for function
     * @param {string} serieGuid
     * @param {number} mandantId
     * @returns {Promise<string[]>}
     */
        serieMaterialBedarfBerechnenForFunction: (serieGuid, mandantId) =>
            fluentApi.put(`SerieMaterialbedarfBerechnen/ForFunction?mandantId=${mandantId}&serieGuid=${serieGuid}`, null),

        /**
     * Reset material bedarf from AV position for function
     * @param {string} avPosGuid
     * @param {number} mandantId
     * @returns {Promise<string[]>}
     */
        serieMaterialBedarfResetFromAvPosForFunction: (avPosGuid, mandantId) =>
            fluentApi.put(`SerieMaterialbedarfBerechnen/ResetFromAvPosForFunction?mandantId=${mandantId}&avPosGuid=${avPosGuid}`, null),

        // SerienMaterialEditWebRoutinen
        /**
     * Add or update serie material
     * @param {MaterialbedarfDTO} dto
     * @returns {Promise<SerienMaterialEditDTO>}
     */
        addOrUpdateSerienMaterial: (dto) =>
            fluentApi.put("SerieMaterialbedarfEdit", dto),

        /**
     * Delete serie material
     * @param {string} materialbedarfGuid
     * @returns {Promise<void>}
     */
        deleteSerienMaterial: (materialbedarfGuid) =>
            fluentApi.delete(`SerieMaterialbedarfEdit?bedarfGuid=${materialbedarfGuid}`),
    };
}

/**
 * @typedef {ReturnType<typeof createProduktionApi>} ProduktionApi
 */
