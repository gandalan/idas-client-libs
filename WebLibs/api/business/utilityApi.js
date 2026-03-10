/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').FileInfoDTO} FileInfoDTO
 * @typedef {import('../dtos/produktion.js').LagerbestandDTO} LagerbestandDTO
 * @typedef {import('../dtos/produktion.js').LagerbuchungDTO} LagerbuchungDTO
 * @typedef {import('../dtos/produktion.js').LagerReservierungDTO} LagerReservierungDTO
 * @typedef {import('../dtos/produktion.js').LieferzusageDTO} LieferzusageDTO
 * @typedef {import('../dtos/produktion.js').GesamtLieferzusageDTO} GesamtLieferzusageDTO
 * @typedef {import('../dtos/belege.js').VorgangDTO} VorgangDTO
 * @typedef {import('../dtos/belege.js').BaseListItemDTO} BaseListItemDTO
 * @typedef {import('../dtos/belege.js').BestellungListItemDTO} BestellungListItemDTO
 * @typedef {import('../dtos/belege.js').MaterialBestellungListItemDTO} MaterialBestellungListItemDTO
 * @typedef {import('../dtos/belege.js').VorgangExtendedDTO} VorgangExtendedDTO
 * @typedef {import('../dtos/index.js').ChangeDTO} ChangeDTO
 * @typedef {import('../dtos/index.js').BenutzerDTO} BenutzerDTO
 * @typedef {import('../dtos/index.js').UserAuthTokenDTO} UserAuthTokenDTO
 * @typedef {import('../dtos/index.js').LoginDTO} LoginDTO
 * @typedef {import('../dtos/index.js').CreateServiceTokenRequestDTO} CreateServiceTokenRequestDTO
 * @typedef {import('../dtos/kunden.js').AppActivationStatusDTO} AppActivationStatusDTO
 * @typedef {import('../dtos/produktion.js').MaterialbedarfDTO} MaterialbedarfDTO
 * @typedef {import('../dtos/produktion.js').ZusammenfassungsOptionen} ZusammenfassungsOptionen
 * @typedef {import('../dtos/produktion.js').GesamtMaterialbedarfGetReturn} GesamtMaterialbedarfGetReturn
 * @typedef {import('../dtos/produktion.js').MaterialbedarfCutOptimization} MaterialbedarfCutOptimization
 * @typedef {import('../dtos/index.js').WebJobHistorieDTO} WebJobHistorieDTO
 * @typedef {import('../dtos/index.js').NachrichtenDTO} NachrichtenDTO
 * @typedef {import('../dtos/index.js').MailJobInfo} MailJobInfo
 * @typedef {import('../dtos/index.js').JobStatusResponseDTO} JobStatusResponseDTO
 * @typedef {import('../dtos/index.js').JobStatusEntryDTO} JobStatusEntryDTO
 * @typedef {import('../dtos/settings.js').MandantDTO} MandantDTO
 */

/**
 * Utility API - File handling, inventory, delivery promises, and general utilities
 * @param {FluentApi} fluentApi
 * @returns {UtilityApi}
 */
export function createUtilityApi(fluentApi) {
  return {
    // FileWebRoutinen
    /**
     * Get file by name
     * @param {string} name
     * @returns {Promise<Uint8Array>}
     */
    getFile: (name) => fluentApi.get(`StaticFile/?name=${name}`),

    /**
     * Get file list
     * @returns {Promise<FileInfoDTO[]>}
     */
    getFileList: () => fluentApi.get('StaticFile'),

    /**
     * Get files as zip
     * @param {string[]} fileNames
     * @returns {Promise<Uint8Array>}
     */
    getFilesZipped: (fileNames) => fluentApi.put('StaticFile', fileNames),

    // DataFileWebRoutinen
    /**
     * Get data file
     * @param {string} filename
     * @returns {Promise<Uint8Array>}
     */
    getDataFile: (filename) => fluentApi.get(`DataFile/?filename=${filename}`),

    /**
     * Get data file list
     * @param {string} [directory='/']
     * @returns {Promise<FileInfoDTO[]>}
     */
    getDataFileList: (directory = '/') =>
      fluentApi.get(`DataFile/?subdir=${encodeURIComponent(directory)}`),

    /**
     * Save data file
     * @param {string} fileName
     * @param {Uint8Array} data
     * @returns {Promise<void>}
     */
    saveDataFile: (fileName, data) =>
      fluentApi.put(`DataFile/?filename=${fileName}`, data),

    /**
     * Delete data file
     * @param {string} filename
     * @returns {Promise<void>}
     */
    deleteDataFile: (filename) =>
      fluentApi.delete(`DataFile/?filename=${filename}`),

    // MailWebRoutinen
    /**
     * Send mail
     * @param {MailJobInfo} job
     * @param {string[]} [attachments]
     * @returns {Promise<JobStatusResponseDTO>}
     */
    sendMail: (job, attachments) => {
      const formData = new FormData();
      formData.append('jobAsString', JSON.stringify(job));
      if (attachments?.length) {
        attachments.forEach(file => formData.append('files', file));
      }
      return fluentApi.post('Mail', formData);
    },

    /**
     * Get mail status
     * @param {string} guid
     * @returns {Promise<JobStatusEntryDTO[]>}
     */
    getMailStatus: (guid) => fluentApi.get(`Mail/${guid}`),

    // PrintWebRoutinen
    /**
     * Generate PDF for beleg
     * @param {string} belegGuid
     * @returns {Promise<Uint8Array>}
     */
    pdfErzeugen: (belegGuid) =>
      fluentApi.post(`Print/?bguid=${belegGuid}`, []),

    /**
     * Generate XPS for beleg
     * @param {string} belegGuid
     * @returns {Promise<Uint8Array>}
     */
    xpsErzeugen: (belegGuid) =>
      fluentApi.post(`Print/?bguid=${belegGuid}&fileFormat=XPS`, []),

    // PrintV2WebRoutinen
    /**
     * Generate PDF v2
     * @param {string} belegGuid
     * @param {string} email
     * @returns {Promise<Uint8Array>}
     */
    pdfV2: (belegGuid, email) =>
      fluentApi.get(`PrintV2/Pdf?bguid=${belegGuid}&email=${encodeURIComponent(email)}`),

    // BriefbogenWebRoutinen
    /**
     * Load letterhead
     * @returns {Promise<Uint8Array>}
     */
    briefbogenLaden: () => fluentApi.get('Briefbogen'),

    // ChangeWebRoutinen
    /**
     * Get changes for type
     * @param {string} typeName
     * @param {Date} changedSince
     * @returns {Promise<ChangeDTO[]>}
     */
    getChanges: (typeName, changedSince) =>
      fluentApi.get(`Change/?typeName=${typeName}&changedSince=${changedSince.toISOString()}`),

    /**
     * Delete old changes
     * @returns {Promise<void>}
     */
    deleteOldChanges: () => fluentApi.delete('Change'),

    // WebJobWebRoutinen
    /**
     * Add web job history
     * @param {WebJobHistorieDTO} historyDto
     * @returns {Promise<void>}
     */
    addWebJobHistorie: (historyDto) => fluentApi.post('Historie', historyDto),

    /**
     * Delete old web job history
     * @returns {Promise<void>}
     */
    deleteOldWebJobHistorie: () => fluentApi.get('Historie/DeleteOldHistorie'),

    // LagerbestandWebRoutinen
    /**
     * Get inventory by GUID
     * @param {string} guid
     * @returns {Promise<LagerbestandDTO>}
     */
    getLagerbestand: (guid) => fluentApi.get(`Lagerbestand/?id=${guid}`),

    /**
     * Get inventory from GUID list
     * @param {string[]} guids
     * @returns {Promise<LagerbestandDTO[]>}
     */
    getLagerbestandFromGuidList: (guids) =>
      fluentApi.post('Lagerbestand/GetFromGuidList', guids),

    /**
     * Get all inventory
     * @param {Date} [changedSince]
     * @returns {Promise<LagerbestandDTO[]>}
     */
    getAllLagerbestand: (changedSince) => {
      if (changedSince) {
        return fluentApi.get(`Lagerbestand?changedSince=${changedSince.toISOString()}`);
      }
      return fluentApi.get('Lagerbestand');
    },

    /**
     * Get inventory below minimum stock
     * @returns {Promise<LagerbestandDTO[]>}
     */
    getUnterschreitungEisernerBestand: () =>
      fluentApi.get('Lagerbestand/UnterschreitungEisernerBestand'),

    /**
     * Book inventory
     * @param {LagerbuchungDTO} buchung
     * @returns {Promise<LagerbestandDTO>}
     */
    lagerbuchung: (buchung) => fluentApi.put('Lagerbuchung', buchung),

    /**
     * Book multiple inventory items
     * @param {LagerbuchungDTO[]} buchungen
     * @returns {Promise<LagerbestandDTO[]>}
     */
    lagerbuchungListe: (buchungen) =>
      fluentApi.put('Lagerbuchung/PutBuchungListe', buchungen),

    /**
     * Save inventory
     * @param {LagerbestandDTO} dto
     * @returns {Promise<void>}
     */
    saveLagerbestand: (dto) => fluentApi.put('Lagerbestand/', dto),

    /**
     * Save inventory list
     * @param {LagerbestandDTO[]} dtos
     * @returns {Promise<string[]>}
     */
    saveLagerbestandListe: (dtos) =>
      fluentApi.put('Lagerbestand/PutLagerbestandListe', dtos),

    /**
     * Delete inventory
     * @param {string} guid
     * @returns {Promise<void>}
     */
    deleteLagerbestand: (guid) => fluentApi.delete(`Lagerbestand/?id=${guid}`),

    /**
     * Get inventory history
     * @param {Date} vonDatum
     * @param {Date} bisDatum
     * @param {boolean} [mitLagerbuchungen=true]
     * @param {boolean} [mitReservierungen=true]
     * @param {string} [katalogArtikelGuid]
     * @returns {Promise<LagerbuchungDTO[]>}
     */
    getLagerhistorie: (vonDatum, bisDatum, mitLagerbuchungen = true, mitReservierungen = true, katalogArtikelGuid) => {
      const url = `Lagerbuchung/?vonDatum=${vonDatum.toISOString()}&bisDatum=${bisDatum.toISOString()}&mitLagerbuchungen=${mitLagerbuchungen}&mitReservierungen=${mitReservierungen}&katalogArtikelGuid=${katalogArtikelGuid || ''}`;
      return fluentApi.get(url);
    },

    // LagerReservierungen
    /**
     * Get reservation by GUID
     * @param {string} guid
     * @returns {Promise<LagerReservierungDTO>}
     */
    getReservierung: (guid) => fluentApi.get(`LagerReservierungen/?id=${guid}`),

    /**
     * Get all reservations
     * @param {string} [artikelnummer]
     * @param {string} [farbkuerzel]
     * @param {string} [farbcode]
     * @param {string} [bezug]
     * @param {string} [oberflaeche]
     * @param {Date} [changedSince]
     * @returns {Promise<LagerReservierungDTO[]>}
     */
    getAllReservierungen: (artikelnummer = '', farbkuerzel = '', farbcode = '', bezug = '', oberflaeche = '', changedSince) => {
      let url = `LagerReservierungen?artikelnummer=${artikelnummer}&farbkuerzel=${farbkuerzel}&farbcode=${farbcode}&bezug=${bezug}&oberflaeche=${oberflaeche}`;
      if (changedSince) {
        url += `&changedSince=${changedSince.toISOString()}`;
      }
      return fluentApi.get(url);
    },

    /**
     * Save reservations
     * @param {LagerReservierungDTO[]} dtos
     * @returns {Promise<void>}
     */
    saveReservierungen: (dtos) => fluentApi.put('LagerReservierungen/', dtos),

    /**
     * Delete reservations
     * @param {string[]} guids
     * @returns {Promise<void>}
     */
    deleteReservierungen: (guids) => fluentApi.delete('LagerReservierungen', guids),

    /**
     * Get producer mandant IDs
     * @returns {Promise<number[]>}
     */
    getProduzentenMandantIds: () =>
      fluentApi.get('Lagerbestand/GetProduzentIdListe'),

    /**
     * Initialize inventory for articles
     * @param {number} mandantID
     * @returns {Promise<number[]>}
     */
    initializeLagerbestand: (mandantID) =>
      fluentApi.get(`Lagerbestand/InitializeBestandForArtikel?mandantId=${mandantID}`),

    // MaterialbedarfWebRoutinen
    /**
     * Get cut optimization
     * @param {MaterialbedarfDTO[]} materialbedarfDtos
     * @returns {Promise<Record<string, MaterialbedarfCutOptimization>>}
     */
    getCutOptimization: (materialbedarfDtos) =>
      fluentApi.post('Materialbedarf/CutOptimization', materialbedarfDtos),

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
      fluentApi.get(`GesamtMaterialbedarf?optionen=${optionen}&stangenoptimierung=${stangenoptimierung}&stichTag=${stichTag?.toISOString() || ''}&bedarfAb=${bedarfAb?.toISOString() || ''}&filterCsvExportedMaterial=${filterCsvExportedMaterial}`),

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
      fluentApi.put('MaterialBestellung/BestellungSpeichern', vorgang),

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
    updateStatusBeimProduzenten: (vorgangGuid, status, externeReferenz = '') =>
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
    getMaterialBestellungen: () => fluentApi.get('MaterialBestellungen'),

    // LieferzusageWebRoutinen
    /**
     * Get all delivery promises for serie
     * @param {string} serieGuid
     * @param {string} [lieferant]
     * @returns {Promise<LieferzusageDTO[]>}
     */
    getAllLieferzusagen: (serieGuid, lieferant = '') =>
      fluentApi.get(`Lieferzusage/?serieGuid=${serieGuid}&lieferant=${lieferant}`),

    /**
     * Get delivery promises count
     * @param {string} serieGuid
     * @param {string} [lieferant]
     * @returns {Promise<number>}
     */
    getLieferzusagenCount: (serieGuid, lieferant = '') =>
      fluentApi.get(`Lieferzusage/GetCount/${serieGuid}/${lieferant}`),

    /**
     * Submit material delivery promise
     * @param {LieferzusageDTO} lieferzusage
     * @returns {Promise<string>}
     */
    materialZusagen: (lieferzusage) =>
      fluentApi.post('Lieferzusage', lieferzusage),

    /**
     * Submit multiple material delivery promises
     * @param {LieferzusageDTO[]} lieferzusagen
     * @returns {Promise<string>}
     */
    materialZusagenListe: (lieferzusagen) =>
      fluentApi.post('Lieferzusage/PutLieferzusagenListe', lieferzusagen),

    /**
     * Reset delivery promise
     * @param {string} lieferzusageGuid
     * @returns {Promise<void>}
     */
    resetLieferzusage: (lieferzusageGuid) =>
      fluentApi.delete(`Lieferzusage?zusageGuid=${lieferzusageGuid}`),

    /**
     * Reset multiple delivery promises
     * @param {string[]} lieferzusagenGuids
     * @returns {Promise<string>}
     */
    resetLieferzusagen: (lieferzusagenGuids) =>
      fluentApi.delete('Lieferzusage/DeleteLieferzusagen', lieferzusagenGuids),

    /**
     * Reset delivery promises by serie
     * @param {string} serieGuid
     * @param {string} [lieferant]
     * @returns {Promise<void>}
     */
    resetLieferzusagenBySerie: (serieGuid, lieferant = '') =>
      fluentApi.delete(`Lieferzusage/DeleteLieferzusagenBySerie/?serieGuid=${serieGuid}&lieferant=${lieferant}`),

    // GesamtLieferzusagenWebRoutinen
    /**
     * Get total delivery promises
     * @param {Date} [stichTag]
     * @returns {Promise<GesamtLieferzusageDTO[]>}
     */
    getGesamtLieferzusagen: (stichTag) =>
      fluentApi.get(`GesamtLieferzusagen?stichTag=${stichTag?.toISOString() || ''}`),

    /**
     * Save total delivery promise
     * @param {GesamtLieferzusageDTO} dto
     * @returns {Promise<void>}
     */
    saveGesamtLieferzusage: (dto) =>
      fluentApi.put('GesamtLieferzusagen', dto),

    /**
     * Save multiple total delivery promises
     * @param {GesamtLieferzusageDTO[]} dtoSet
     * @returns {Promise<string>}
     */
    saveGesamtLieferzusagenListe: (dtoSet) =>
      fluentApi.put('GesamtLieferzusagen/PutGesamtLieferzusagenListe', dtoSet),

    /**
     * Book serie delivery promises
     * @param {string} serieGuid
     * @returns {Promise<void>}
     */
    serieBuchen: (serieGuid) =>
      fluentApi.post(`GesamtLieferzusagen/SerieBuchen?serieGuid=${serieGuid}`, null),

    /**
     * Delete total delivery promise
     * @param {string} gesamtLieferzusageGuid
     * @returns {Promise<void>}
     */
    deleteGesamtLieferzusage: (gesamtLieferzusageGuid) =>
      fluentApi.delete(`GesamtLieferzusage?gesamtLieferzusageGuid=${gesamtLieferzusageGuid}`),

    /**
     * Delete multiple total delivery promises
     * @param {string[]} gesamtLieferzusagenGuids
     * @returns {Promise<string>}
     */
    deleteGesamtLieferzusagen: (gesamtLieferzusagenGuids) =>
      fluentApi.delete('GesamtLieferzusage/DeleteGesamtLieferzusagen', gesamtLieferzusagenGuids),

    // AppWebRoutinen
    /**
     * Get mandant status by customer
     * @param {string} kundeGuid
     * @returns {Promise<AppActivationStatusDTO>}
     */
    getMandantStatusByKunde: (kundeGuid) =>
      fluentApi.get(`AppMandant/${kundeGuid}`),

    /**
     * Set mandant status by customer
     * @param {AppActivationStatusDTO} data
     * @returns {Promise<AppActivationStatusDTO>}
     */
    setMandantStatusByKunde: (data) =>
      fluentApi.put('AppMandant', data),

    /**
     * Get mandanten
     * @returns {Promise<MandantDTO[]>}
     */
    getAppMandanten: () => fluentApi.get('AppMandant/'),

    /**
     * Get users by customer
     * @param {string} kundeGuid
     * @returns {Promise<BenutzerDTO[]>}
     */
    getBenutzerByKunde: (kundeGuid) =>
      fluentApi.get(`AppBenutzer/${kundeGuid}`),

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

    /**
     * Create or update mandant
     * @param {MandantDTO} data
     * @returns {Promise<MandantDTO>}
     */
    createOrUpdateMandant: (data) => fluentApi.put('Mandanten', data),

    /**
     * Create or update user by customer
     * @param {string} kundeGuid
     * @param {BenutzerDTO} data
     * @param {boolean} [pwSenden=false]
     * @param {string} [passwort]
     * @returns {Promise<BenutzerDTO>}
     */
    createOrUpdateBenutzerByKunde: (kundeGuid, data, pwSenden = false, passwort = '') =>
      fluentApi.post(`AppBenutzer/?kundeGuid=${kundeGuid}&pwSenden=${pwSenden}&passwort=${passwort}`, data),

    /**
     * Delete user by customer
     * @param {string} kundeGuid
     * @param {BenutzerDTO} data
     * @returns {Promise<void>}
     */
    deleteBenutzerByKunde: (kundeGuid, data) =>
      fluentApi.delete(`AppBenutzer/?kundeGuid=${kundeGuid}&benutzerGuid=${data.benutzerGuid}`),

    /**
     * Activate mandant
     * @param {string} adminEmail
     * @returns {Promise<void>}
     */
    aktiviereMandant: (adminEmail) =>
      fluentApi.post('ProduzentAktivieren', { adminEmail }),

    // MandantenWebRoutinen
    /**
     * Sync mandanten list
     * @param {MandantDTO[]} list
     * @returns {Promise<void>}
     */
    mandantenAbgleichen: (list) =>
      Promise.all(list.map(m => fluentApi.put('Mandanten', m))),

    /**
     * Create mandant
     * @param {MandantDTO} mandant
     * @returns {Promise<MandantDTO>}
     */
    mandantenAnlegen: (mandant) => fluentApi.put('Mandanten', mandant),

    /**
     * Load mandanten with filter
     * @param {string} filter
     * @returns {Promise<MandantDTO[]>}
     */
    ladeMandantenMitFilter: (filter) =>
      fluentApi.get(`Mandanten?filter=${encodeURIComponent(filter)}`),

    // MandantenAdminWebRoutinen
    /**
     * Load mandanten with filter (admin)
     * @param {string} filter
     * @param {boolean} onlyHaendler
     * @param {boolean} onlyProduzenten
     * @returns {Promise<MandantDTO[]>}
     */
    ladeMandantenAdminMitFilter: (filter, onlyHaendler, onlyProduzenten) =>
      fluentApi.get(`MandantenAdmin?filter=${encodeURIComponent(filter || '')}&onlyHaendler=${onlyHaendler}&onlyProduzenten=${onlyProduzenten}`),

    /**
     * Load mandant by GUID (admin)
     * @param {string} guid
     * @returns {Promise<MandantDTO>}
     */
    ladeMandantAdmin: (guid) =>
      fluentApi.get(`MandantenAdmin?guid=${guid}`),

    /**
     * Move mandant
     * @param {string} mandantGuid
     * @param {string} zielMandantGuid
     * @returns {Promise<void>}
     */
    mandantenUmziehen: (mandantGuid, zielMandantGuid) =>
      fluentApi.put('MandantenAdmin', [mandantGuid, zielMandantGuid]),

    /**
     * Add admin rights
     * @param {string} email
     * @returns {Promise<void>}
     */
    addAdminRechte: (email) =>
      fluentApi.post(`MandantenAdmin/SetAdminRechte?email=${encodeURIComponent(email)}`, null),

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
    ladeMaterialBestellungen: (jahr = -1, vorgangStatusText = 'Alle', includeAbgeholte = false, includeArchive = false, includeAllTypes = false, includeArtosGeloeschtFlag = false) =>
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
    ladeMaterialBestellungenVonBis: (vonDatum, bisDatum, vorgangStatusText = 'Alle', includeAbgeholte = false, includeArchive = false, includeAllTypes = false, includeArtosGeloeschtFlag = false) =>
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

    // AuthTokenWebRoutinen
    /**
     * Remove expired tokens
     * @returns {Promise<void>}
     */
    removeExpiredTokens: () =>
      fluentApi.post('AuthToken/RemoveExpiredTokens', null),

    /**
     * Get external app auth token
     * @param {string} fremdApp
     * @returns {Promise<UserAuthTokenDTO>}
     */
    getFremdAppAuthToken: (fremdApp) =>
      fluentApi.get(`AuthToken/GetFremdAppAuthToken?fremdApp=${fremdApp}`),

    // LoginJwtRoutinen
    /**
     * Authenticate
     * @param {LoginDTO} dto
     * @returns {Promise<string>}
     */
    authenticate: (dto) => fluentApi.post('LoginJwt/Authenticate', dto),

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
    refreshToken: (token) => fluentApi.put('LoginJwt/Refresh', token),

    /**
     * Create service token
     * @param {CreateServiceTokenRequestDTO} [dto]
     * @returns {Promise<string>}
     */
    createServiceToken: (dto) => fluentApi.post('LoginJwt/CreateServiceToken', dto),

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
  };
}
