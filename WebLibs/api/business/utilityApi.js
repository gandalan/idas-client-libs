/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/belege.js').VorgangDTO} VorgangDTO
 * @typedef {import('../dtos/belege.js').BaseListItemDTO} BaseListItemDTO
 * @typedef {import('../dtos/belege.js').MaterialBestellungListItemDTO} MaterialBestellungListItemDTO
 * @typedef {import('../dtos/belege.js').VorgangExtendedDTO} VorgangExtendedDTO
 * @typedef {import('../dtos/belege.js').BestellungListItemDTO} BestellungListItemDTO
 * @typedef {import('../dtos/produktion.js').MaterialbedarfDTO} MaterialbedarfDTO
 * @typedef {import('../dtos/produktion.js').ZusammenfassungsOptionen} ZusammenfassungsOptionen
 * @typedef {import('../dtos/produktion.js').GesamtMaterialbedarfGetReturn} GesamtMaterialbedarfGetReturn
 * @typedef {import('../dtos/produktion.js').MaterialbedarfCutOptimization} MaterialbedarfCutOptimization
 * @typedef {import('../dtos/index.js').WebJobHistorieDTO} WebJobHistorieDTO
 * @typedef {import('../dtos/index.js').NachrichtenDTO} NachrichtenDTO
 * @typedef {import('../dtos/index.js').BenutzerDTO} BenutzerDTO
 */

/**
 * Utility API - Backup, IBOS1 import, material requirements, web jobs, and general utilities
 * @param {FluentApi} fluentApi
 */
export function createUtilityApi(fluentApi) {
    return {
    // WebJobWebRoutinen
    /**
     * Add web job history
     * @param {WebJobHistorieDTO} historyDto
     * @returns {Promise<void>}
     */
        addWebJobHistorie: (historyDto) => fluentApi.post("Historie", historyDto),

        /**
     * Delete old web job history
     * @returns {Promise<void>}
     */
        deleteOldWebJobHistorie: () => fluentApi.get("Historie/DeleteOldHistorie"),

        // MaterialbedarfWebRoutinen
        /**
     * Get cut optimization
     * @param {MaterialbedarfDTO[]} materialbedarfDtos
     * @returns {Promise<Record<string, MaterialbedarfCutOptimization>>}
     */
        getCutOptimization: (materialbedarfDtos) =>
            fluentApi.post("Materialbedarf/CutOptimization", materialbedarfDtos),

        // GesamtMaterialbedarfWebRoutinen
        /**
     * Get total material requirements
     * @param {ZusammenfassungsOptionen} optionen
     * @param {boolean} stangenoptimierung
     * @param {Date} [stichTag]
     * @param {Date} [bedarfAb]
     * @param {boolean} [filterCsvExportedMaterial=true]
     * @returns {Promise<GesamtMaterialbedarfGetReturn>}
     */
        getGesamtMaterialbedarf: (optionen, stangenoptimierung, stichTag, bedarfAb, filterCsvExportedMaterial = true) =>
            fluentApi.get(`GesamtMaterialbedarf?optionen=${optionen}&stangenoptimierung=${stangenoptimierung}&stichTag=${stichTag?.toISOString() || ""}&bedarfAb=${bedarfAb?.toISOString() || ""}&filterCsvExportedMaterial=${filterCsvExportedMaterial}`),

        /**
     * Update total material requirement delivery date
     * @param {number} mandantId
     * @param {string} posGuid
     * @returns {Promise<void>}
     */
        gesamtBedarfUpdateLiefertag: (mandantId, posGuid) =>
            fluentApi.post(`GesamtMaterialbedarf/GesamtBedarfUpdateLiefertag?mandantId=${mandantId}&posGuid=${posGuid}`, null),

        /**
     * Recalculate total material requirement
     * @param {number} mandantId
     * @param {string} avPosGuid
     * @returns {Promise<void>}
     */
        recalculateGesamtbedarf: (mandantId, avPosGuid) =>
            fluentApi.post(`GesamtMaterialbedarf/RecalculateGesamtBedarf?mandantId=${mandantId}&avPosGuid=${avPosGuid}`, null),

        // MaterialBestellungWebRoutinen
        /**
     * Create vorgang at coater
     * @param {VorgangDTO} vorgang
     * @param {string} mGuid
     * @param {string} produzentenKundenNummer
     * @returns {Promise<VorgangDTO>}
     */
        erzeugeVorgangBeiBeschichter: (vorgang, mGuid, produzentenKundenNummer) =>
            fluentApi.put(`MaterialBestellung?mGuid=${mGuid}&produzentenKundenNummer=${produzentenKundenNummer}`, vorgang),

        /**
     * Create order vorgang
     * @param {VorgangDTO} vorgang
     * @returns {Promise<VorgangDTO>}
     */
        erzeugeBestellVorgang: (vorgang) =>
            fluentApi.put("MaterialBestellung/BestellungSpeichern", vorgang),

        /**
     * Create complaint at coater
     * @param {VorgangDTO} vorgang
     * @param {string} quellVorgang
     * @param {string} mGuid
     * @param {string} produzentenKundenNummer
     * @returns {Promise<VorgangDTO>}
     */
        erzeugeReklamationBeiBeschichter: (vorgang, quellVorgang, mGuid, produzentenKundenNummer) =>
            fluentApi.put(`MaterialBestellungReklamation?quellVorgangGuid=${quellVorgang}&mGuid=${mGuid}&produzentenKundenNummer=${produzentenKundenNummer}`, vorgang),

        /**
     * Update status at producer
     * @param {string} vorgangGuid
     * @param {string} status
     * @param {string} [externeReferenz]
     * @returns {Promise<void>}
     */
        updateStatusBeimProduzenten: (vorgangGuid, status, externeReferenz = "") =>
            fluentApi.post(`MaterialBestellungStatus?vorgangGuid=${vorgangGuid}&status=${status}&externeReferenz=${externeReferenz}`, null),

        /**
     * Get all material orders by year
     * @param {number} jahr
     * @returns {Promise<BaseListItemDTO[]>}
     */
        getMaterialBestellungenByJahr: (jahr) =>
            fluentApi.get(`MaterialBestellungen/?jahr=${jahr}`),

        /**
     * Get all material orders
     * @returns {Promise<BaseListItemDTO[]>}
     */
        getMaterialBestellungen: () => fluentApi.get("MaterialBestellungen"),

        // NewsletterWebRoutinen
        /**
     * Request newsletter subscription by GUID
     * @param {string} guid
     * @returns {Promise<void>}
     */
        requestNewsletterByGuid: (guid) =>
            fluentApi.post(`Newsletter/?id=${guid}&eintragen=true`, null),

        /**
     * Request newsletter subscription by email
     * @param {string} mail
     * @returns {Promise<void>}
     */
        requestNewsletterByMail: (mail) =>
            fluentApi.post(`Newsletter/?mail=${encodeURIComponent(mail)}&eintragen=true`, null),

        /**
     * Unsubscribe newsletter by email
     * @param {string} mail
     * @returns {Promise<void>}
     */
        deleteNewsletterByMail: (mail) =>
            fluentApi.post(`Newsletter/?mail=${encodeURIComponent(mail)}&eintragen=false`, null),

        /**
     * Unsubscribe newsletter by GUID
     * @param {string} guid
     * @returns {Promise<void>}
     */
        deleteNewsletterByGuid: (guid) =>
            fluentApi.post(`Newsletter/?id=${guid}&eintragen=false`, null),

        // BackupWebRoutinen
        /**
     * Get vorgang GUIDs for backup
     * @param {string} email
     * @param {number} [year=0]
     * @param {boolean} [onlyBills=false]
     * @returns {Promise<string[]>}
     */
        getBackupVorgangGuids: (email, year = 0, onlyBills = false) =>
            fluentApi.get(`Backup/GetVorgangGuids?email=${encodeURIComponent(email)}&jahr=${year}&nurRechnungen=${onlyBills}`),

        /**
     * Get vorgang for backup
     * @param {string} email
     * @param {string} guid
     * @param {boolean} [onlyBills=false]
     * @returns {Promise<VorgangExtendedDTO>}
     */
        getBackupVorgang: (email, guid, onlyBills = false) =>
            fluentApi.get(`Backup/GetVorgang?email=${encodeURIComponent(email)}&nurRechnungen=${onlyBills}&guid=${guid}`),

        /**
     * Request backup
     * @param {string} email
     * @param {boolean} onlyBills
     * @param {number} year
     * @returns {Promise<void>}
     */
        requestBackup: (email, onlyBills, year) =>
            fluentApi.post(`Backup/RequestBackup?email=${encodeURIComponent(email)}&nurRechnungen=${onlyBills}&jahr=${year}`, null),

        // IBOS1ImportRoutinen
        /**
     * Load orders
     * @param {number} [jahr=-1]
     * @param {boolean} [includeAbgeholte=false]
     * @returns {Promise<BestellungListItemDTO[]>}
     */
        ladeBestellungen: (jahr = -1, includeAbgeholte = false) =>
            fluentApi.get(`Bestellungen?jahr=${jahr}&includeAbgeholte=${includeAbgeholte}`),

        /**
     * Reset orders
     * @param {Date} resetAb
     * @returns {Promise<void>}
     */
        resetBestellungen: (resetAb) =>
            fluentApi.get(`BestellungenReset?resetAb=${resetAb.toISOString()}`),

        /**
     * Load material orders
     * @param {number} [jahr=-1]
     * @param {string} [vorgangStatusText='Alle']
     * @param {boolean} [includeAbgeholte=false]
     * @param {boolean} [includeArchive=false]
     * @param {boolean} [includeAllTypes=false]
     * @param {boolean} [includeArtosGeloeschtFlag=false]
     * @returns {Promise<MaterialBestellungListItemDTO[]>}
     */
        ladeMaterialBestellungen: (jahr = -1, vorgangStatusText = "Alle", includeAbgeholte = false, includeArchive = false, includeAllTypes = false, includeArtosGeloeschtFlag = false) =>
            fluentApi.get(`MaterialBestellungen?jahr=${jahr}&status=${vorgangStatusText}&includeAbgeholte=${includeAbgeholte}&includeArchive=${includeArchive}&includeAllTypes=${includeAllTypes}&includeArtosGeloeschtFlag=${includeArtosGeloeschtFlag}`),

        /**
     * Load material orders by date range
     * @param {Date} vonDatum
     * @param {Date} bisDatum
     * @param {string} [vorgangStatusText='Alle']
     * @param {boolean} [includeAbgeholte=false]
     * @param {boolean} [includeArchive=false]
     * @param {boolean} [includeAllTypes=false]
     * @param {boolean} [includeArtosGeloeschtFlag=false]
     * @returns {Promise<MaterialBestellungListItemDTO[]>}
     */
        ladeMaterialBestellungenVonBis: (vonDatum, bisDatum, vorgangStatusText = "Alle", includeAbgeholte = false, includeArchive = false, includeAllTypes = false, includeArtosGeloeschtFlag = false) =>
            fluentApi.get(`MaterialBestellungen?jahr=0&status=${vorgangStatusText}&includeAbgeholte=${includeAbgeholte}&includeArchive=${includeArchive}&includeAllTypes=${includeAllTypes}&vonDatum=${vonDatum.toISOString()}&bisDatum=${bisDatum.toISOString()}`),

        /**
     * Reset material orders
     * @param {Date} resetAb
     * @returns {Promise<void>}
     */
        resetMaterialBestellungen: (resetAb) =>
            fluentApi.get(`MaterialBestellungenReset?resetAb=${resetAb.toISOString()}`),

        /**
     * Get gSQL beleg
     * @param {string} belegGuid
     * @returns {Promise<string>}
     */
        getGsqlBeleg: async (belegGuid) => {
            const data = await fluentApi.get(`Bestellungen/${belegGuid}`);
            return new TextDecoder().decode(data);
        },

        // NotifyWebRoutinen
        /**
     * Get all notifications
     * @returns {Promise<NachrichtenDTO[]>}
     */
        getAllNotifications: () => {
            const mandant = fluentApi.settings?.authToken?.mandant?.mandantGuid;
            const produzent = fluentApi.settings?.authToken?.mandant?.produzentMandantGuid;
            if (!mandant) return Promise.resolve([]);
            return fluentApi.get(`Nachrichten?mandantGuid=${mandant}&produzentGuid=${produzent}`);
        },

        // AppWebRoutinen - Helper method that doesn't exist in mandantApi.js
        /**
     * Get single user by customer and email
     * @param {string} kundeGuid
     * @param {string} email
     * @returns {Promise<BenutzerDTO | undefined>}
     */
        getOneBenutzerByKunde: async (kundeGuid, email) => {
            const list = await fluentApi.get(`AppBenutzer/${kundeGuid}`);
            return list.find(x => x.emailAdresse === email);
        },
    };
}

/**
 * Utility API contract inferred from createUtilityApi implementation.
 *
 * @typedef {ReturnType<typeof createUtilityApi>} UtilityApi
 */
