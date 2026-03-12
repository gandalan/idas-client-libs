/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/faktura.js').BelegeInfoDTO} BelegeInfoDTO
 * @typedef {import('../dtos/belege.js').BelegartWechselDTO} BelegartWechselDTO
 * @typedef {import('../dtos/faktura.js').SammelrechnungDTO} SammelrechnungDTO
 * @typedef {import('../dtos/faktura.js').SammelrechnungListItemDTO} SammelrechnungListItemDTO
 * @typedef {import('../dtos/faktura.js').CreateSammelrechnungDTO} CreateSammelrechnungDTO
 */

/**
 * Rechnung API - Invoice creation and management
 * Corresponds to RechnungenWebRoutinen and SammelrechnungenWebRoutinen in C#
 * @param {FluentApi} fluentApi
 */
export function createRechnungApi(fluentApi) {
    return {
        // RechnungenWebRoutinen
        /**
         * Get all deliverable delivery notes
         * @returns {Promise<BelegeInfoDTO[]>}
         */
        getAllAbFakturierbar: () =>
            fluentApi.get("Rechnungen/GetABFakturierbar"),

        /**
         * Get all printable invoices
         * @param {Date} [printedSince]
         * @returns {Promise<BelegeInfoDTO[]>}
         */
        getAllDruckbar: (printedSince) =>
            fluentApi.get(`Rechnungen/GetNotPrintedRechnungen?printedSince=${printedSince?.toISOString()}`),

        /**
         * Get all exportable invoices
         * @param {Date} [exportedSince]
         * @returns {Promise<BelegeInfoDTO[]>}
         */
        getAllExportierbar: (exportedSince) =>
            fluentApi.get(`Rechnungen/GetNotExportedRechnungen?exportedSince=${exportedSince?.toISOString()}`),

        /**
         * Set belege as printed
         * @param {string[]} belegListe
         * @returns {Promise<void>}
         */
        setBelegePrinted: (belegListe) =>
            fluentApi.post("Rechnungen/SetBelegePrinted", belegListe),

        /**
         * Set belege as exported
         * @param {string[]} belegListe
         * @returns {Promise<void>}
         */
        setBelegeExported: (belegListe) =>
            fluentApi.post("Rechnungen/SetBelegeExported", belegListe),

        /**
         * Create invoices from delivery notes
         * @param {BelegartWechselDTO[]} belegeWechsel
         * @returns {Promise<Record<string, string>>} Map of belegGuid to rechnungGuid
         */
        erstelleRechnungen: (belegeWechsel) =>
            fluentApi.post("Rechnungen/ErstelleRechnungen", belegeWechsel),

        // SammelrechnungenWebRoutinen
        sammel: {
            /**
             * Create collective invoice
             * @param {CreateSammelrechnungDTO} dto
             * @returns {Promise<SammelrechnungListItemDTO>}
             */
            erstellen: (dto) =>
                fluentApi.post("Sammelrechnungen/ErstelleSammelrechnungen", dto),

            /**
             * Get not printed collective invoices
             * @param {Date} [printedSince]
             * @returns {Promise<SammelrechnungListItemDTO[]>}
             */
            getNotPrinted: (printedSince) =>
                fluentApi.get(`Sammelrechnungen/GetNotPrintedSammelrechnungen?printedSince=${printedSince?.toISOString()}`),

            /**
             * Get not exported collective invoices
             * @param {Date} [exportedSince]
             * @returns {Promise<SammelrechnungListItemDTO[]>}
             */
            getNotExported: (exportedSince) =>
                fluentApi.get(`Sammelrechnungen/GetNotExportedSammelrechnungen?exportedSince=${exportedSince?.toISOString()}`),

            /**
             * Get collective invoice by GUID
             * @param {string} guid
             * @param {boolean} includeBelegDruckDTO
             * @returns {Promise<SammelrechnungDTO>}
             */
            get: (guid, includeBelegDruckDTO) =>
                fluentApi.get(`Sammelrechnungen/GetSammelrechnung?guid=${guid}&includeBelegDruckDTO=${includeBelegDruckDTO}`),

            /**
             * Get possible collective invoice items
             * @returns {Promise<BelegeInfoDTO[]>}
             */
            getPossibleRechnungen: () =>
                fluentApi.get("Sammelrechnungen/GetPossibleSammelrechnungRechnungen"),

            /**
             * Update collective invoice
             * @param {SammelrechnungDTO} dto
             * @returns {Promise<SammelrechnungDTO>}
             */
            update: (dto) =>
                fluentApi.post("Sammelrechnungen/UpdateSammelrechnung", dto),

            /**
             * Add invoice to collective invoice
             * @param {string} belegGuid
             * @param {string} sammelrechnungGuid
             * @returns {Promise<SammelrechnungListItemDTO>}
             */
            addRechnung: (belegGuid, sammelrechnungGuid) =>
                fluentApi.post("Sammelrechnungen/AddRechnungToSammelrechnungen", { belegGuid, sammelrechnungGuid }),

            /**
             * Set invoices as printed
             * @param {string[]} guidListe
             * @param {boolean} [setEinzel=false]
             * @returns {Promise<void>}
             */
            setAlsGedruckt: (guidListe, setEinzel = false) =>
                fluentApi.post(`Sammelrechnungen/SetSammelrechnungPrinted?setEinzel=${setEinzel}`, guidListe),

            /**
             * Set invoices as exported to accounting
             * @param {string[]} guidListe
             * @param {boolean} [setEinzel=false]
             * @returns {Promise<void>}
             */
            setAlsFibuUebergeben: (guidListe, setEinzel = false) =>
                fluentApi.post(`Sammelrechnungen/SetSammelrechnungExported?setEinzel=${setEinzel}`, guidListe),

            /**
             * Search collective invoices
             * @param {string} term
             * @returns {Promise<SammelrechnungListItemDTO[]>}
             */
            search: (term) =>
                fluentApi.get(`Sammelrechnungen/SearchSammelrechnung?term=${term}`),
        },
    };
}

/**
 * @typedef {ReturnType<typeof createRechnungApi>} RechnungApi
 */
