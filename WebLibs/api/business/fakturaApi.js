/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').SetFakturaDTO} SetFakturaDTO
 * @typedef {import('../dtos/index.js').BelegeInfoDTO} BelegeInfoDTO
 * @typedef {import('../dtos/index.js').BelegartWechselDTO} BelegartWechselDTO
 * @typedef {import('../dtos/index.js').SammelrechnungDTO} SammelrechnungDTO
 * @typedef {import('../dtos/index.js').SammelrechnungListItemDTO} SammelrechnungListItemDTO
 * @typedef {import('../dtos/index.js').CreateSammelrechnungDTO} CreateSammelrechnungDTO
 * @typedef {import('../dtos/index.js').AddRechnungSammelrechnungDTO} AddRechnungSammelrechnungDTO
 */

/**
 * Faktura API - Invoicing and billing management
 * @param {FluentApi} fluentApi
 * @returns {FakturaApi}
 */
export function createFakturaApi(fluentApi) {
  return {
    // FakturaWebRoutinen
    /**
     * Get vorgang identifier
     * @param {string} vorgangGuid
     * @returns {Promise<string>}
     */
    getVorgangKennzeichen: (vorgangGuid) =>
      fluentApi.get(`Faktura/GetVorgangKennzeichen?vorgangGuid=${vorgangGuid}`),

    /**
     * Get beleg identifier
     * @param {string} belegGuid
     * @returns {Promise<string>}
     */
    getBelegKennzeichen: (belegGuid) =>
      fluentApi.get(`Faktura/GetBelegKennzeichen?belegGuid=${belegGuid}`),

    /**
     * Get beleg position identifier
     * @param {string} belegPositionGuid
     * @returns {Promise<string>}
     */
    getBelegPositionKennzeichen: (belegPositionGuid) =>
      fluentApi.get(`Faktura/GetBelegPositionKennzeichen?vorgangGuid=${belegPositionGuid}`),

    /**
     * Get beleg position AV identifier
     * @param {string} belegPositionAvGuid
     * @returns {Promise<string>}
     */
    getBelegPositionAvKennzeichen: (belegPositionAvGuid) =>
      fluentApi.get(`Faktura/GetBelegPositionAVKennzeichen?vorgangGuid=${belegPositionAvGuid}`),

    /**
     * Set vorgang identifier
     * @param {SetFakturaDTO} dto
     * @returns {Promise<string>}
     */
    setVorgangKennzeichen: (dto) =>
      fluentApi.post('Faktura/SetVorgangKennzeichen', dto),

    /**
     * Set beleg identifier
     * @param {SetFakturaDTO} dto
     * @returns {Promise<string>}
     */
    setBelegKennzeichen: (dto) =>
      fluentApi.post('Faktura/SetBelegKennzeichen', dto),

    /**
     * Set beleg position identifier
     * @param {SetFakturaDTO} dto
     * @returns {Promise<string>}
     */
    setBelegPositionKennzeichen: (dto) =>
      fluentApi.post('Faktura/SetBelegPositionKennzeichen', dto),

    /**
     * Set beleg position AV identifier
     * @param {SetFakturaDTO} dto
     * @returns {Promise<string>}
     */
    setBelegPositionAvKennzeichen: (dto) =>
      fluentApi.post('Faktura/SetBelegPositionAVKennzeichen', dto),

    /**
     * Set automatic invoicing in delivery notes
     * @returns {Promise<void>}
     */
    setFakturaInAbAuto: () =>
      fluentApi.post('Faktura/SetFakturaInABAuto', null),

    // RechnungenWebRoutinen
    /**
     * Get all deliverable delivery notes
     * @returns {Promise<BelegeInfoDTO[]>}
     */
    getAllAbFakturierbar: () =>
      fluentApi.get('Rechnungen/GetABFakturierbar'),

    /**
     * Get all printable invoices
     * @param {Date} [printedSince]
     * @returns {Promise<BelegeInfoDTO[]>}
     */
    getAllRechnungenDruckbar: (printedSince) =>
      fluentApi.get(`Rechnungen/GetNotPrintedRechnungen?printedSince=${printedSince?.toISOString()}`),

    /**
     * Get all exportable invoices
     * @param {Date} [exportedSince]
     * @returns {Promise<BelegeInfoDTO[]>}
     */
    getAllRechnungenExportierbar: (exportedSince) =>
      fluentApi.get(`Rechnungen/GetNotExportedRechnungen?exportedSince=${exportedSince?.toISOString()}`),

    /**
     * Set belege as printed
     * @param {string[]} belegListe
     * @returns {Promise<void>}
     */
    setBelegePrinted: (belegListe) =>
      fluentApi.post('Rechnungen/SetBelegePrinted', belegListe),

    /**
     * Set belege as exported
     * @param {string[]} belegListe
     * @returns {Promise<void>}
     */
    setBelegeExported: (belegListe) =>
      fluentApi.post('Rechnungen/SetBelegeExported', belegListe),

    /**
     * Create invoices from delivery notes
     * @param {BelegartWechselDTO[]} belegeWechsel
     * @returns {Promise<Record<string, string>>} Map of belegGuid to rechnungGuid
     */
    erstelleRechnungen: (belegeWechsel) =>
      fluentApi.post('Rechnungen/ErstelleRechnungen', belegeWechsel),

    // SammelrechnungenWebRoutinen
    /**
     * Create collective invoice
     * @param {CreateSammelrechnungDTO} dto
     * @returns {Promise<SammelrechnungListItemDTO>}
     */
    erstelleSammelrechnungen: (dto) =>
      fluentApi.post('Sammelrechnungen/ErstelleSammelrechnungen', dto),

    /**
     * Get not printed collective invoices
     * @param {Date} [printedSince]
     * @returns {Promise<SammelrechnungListItemDTO[]>}
     */
    getNotPrintedSammelrechnungen: (printedSince) =>
      fluentApi.get(`Sammelrechnungen/GetNotPrintedSammelrechnungen?printedSince=${printedSince?.toISOString()}`),

    /**
     * Get not exported collective invoices
     * @param {Date} [exportedSince]
     * @returns {Promise<SammelrechnungListItemDTO[]>}
     */
    getNotExportedSammelrechnungen: (exportedSince) =>
      fluentApi.get(`Sammelrechnungen/GetNotExportedSammelrechnungen?exportedSince=${exportedSince?.toISOString()}`),

    /**
     * Get collective invoice by GUID
     * @param {string} guid
     * @param {boolean} includeBelegDruckDTO
     * @returns {Promise<SammelrechnungDTO>}
     */
    getSammelrechnung: (guid, includeBelegDruckDTO) =>
      fluentApi.get(`Sammelrechnungen/GetSammelrechnung?guid=${guid}&includeBelegDruckDTO=${includeBelegDruckDTO}`),

    /**
     * Get possible collective invoice items
     * @returns {Promise<BelegeInfoDTO[]>}
     */
    getPossibleSammelrechnungRechnungen: () =>
      fluentApi.get('Sammelrechnungen/GetPossibleSammelrechnungRechnungen'),

    /**
     * Update collective invoice
     * @param {SammelrechnungDTO} dto
     * @returns {Promise<SammelrechnungDTO>}
     */
    updateSammelrechnung: (dto) =>
      fluentApi.post('Sammelrechnungen/UpdateSammelrechnung', dto),

    /**
     * Add invoice to collective invoice
     * @param {string} belegGuid
     * @param {string} sammelrechnungGuid
     * @returns {Promise<SammelrechnungListItemDTO>}
     */
    addRechnungToSammelrechnungen: (belegGuid, sammelrechnungGuid) =>
      fluentApi.post('Sammelrechnungen/AddRechnungToSammelrechnungen', { belegGuid, sammelrechnungGuid }),

    /**
     * Set invoices as printed
     * @param {string[]} guidListe
     * @param {boolean} [setEinzel=false]
     * @returns {Promise<void>}
     */
    setRechnungenAlsGedruckt: (guidListe, setEinzel = false) =>
      fluentApi.post(`Sammelrechnungen/SetSammelrechnungPrinted?setEinzel=${setEinzel}`, guidListe),

    /**
     * Set invoices as exported to accounting
     * @param {string[]} guidListe
     * @param {boolean} [setEinzel=false]
     * @returns {Promise<void>}
     */
    setRechnungenAlsFibuUebergeben: (guidListe, setEinzel = false) =>
      fluentApi.post(`Sammelrechnungen/SetSammelrechnungExported?setEinzel=${setEinzel}`, guidListe),

    /**
     * Search collective invoices
     * @param {string} term
     * @returns {Promise<SammelrechnungListItemDTO[]>}
     */
    searchSammelrechnung: (term) =>
      fluentApi.get(`Sammelrechnungen/SearchSammelrechnung?term=${term}`),
  };
}
