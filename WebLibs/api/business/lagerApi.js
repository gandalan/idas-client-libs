/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/produktion.js').LagerbestandDTO} LagerbestandDTO
 * @typedef {import('../dtos/produktion.js').LagerbuchungDTO} LagerbuchungDTO
 * @typedef {import('../dtos/produktion.js').LagerReservierungDTO} LagerReservierungDTO
 */

/**
 * Lager API - Warehouse/inventory management
 * @param {FluentApi} fluentApi
 */
export function createLagerApi(fluentApi) {
    return {
        // LagerbestandWebRoutinen
        /**
         * Get inventory by GUID
         * @param {string} guid
         * @returns {Promise<LagerbestandDTO>}
         */
        get: (guid) => fluentApi.get(`Lagerbestand/?id=${guid}`),

        /**
         * Get inventory from GUID list
         * @param {string[]} guids
         * @returns {Promise<LagerbestandDTO[]>}
         */
        getFromGuidList: (guids) =>
            fluentApi.post("Lagerbestand/GetFromGuidList", guids),

        /**
         * Get all inventory
         * @param {Date} [changedSince]
         * @returns {Promise<LagerbestandDTO[]>}
         */
        getAll: (changedSince) => {
            if (changedSince) {
                return fluentApi.get(`Lagerbestand?changedSince=${changedSince.toISOString()}`);
            }
            return fluentApi.get("Lagerbestand");
        },

        /**
         * Get inventory below minimum stock
         * @returns {Promise<LagerbestandDTO[]>}
         */
        getUnterschreitungEisernerBestand: () =>
            fluentApi.get("Lagerbestand/UnterschreitungEisernerBestand"),

        /**
         * Book inventory
         * @param {LagerbuchungDTO} buchung
         * @returns {Promise<LagerbestandDTO>}
         */
        buchung: (buchung) => fluentApi.put("Lagerbuchung", buchung),

        /**
         * Book multiple inventory items
         * @param {LagerbuchungDTO[]} buchungen
         * @returns {Promise<LagerbestandDTO[]>}
         */
        buchungListe: (buchungen) =>
            fluentApi.put("Lagerbuchung/PutBuchungListe", buchungen),

        /**
         * Save inventory
         * @param {LagerbestandDTO} dto
         * @returns {Promise<void>}
         */
        save: (dto) => fluentApi.put("Lagerbestand/", dto),

        /**
         * Save inventory list
         * @param {LagerbestandDTO[]} dtos
         * @returns {Promise<string[]>}
         */
        saveListe: (dtos) =>
            fluentApi.put("Lagerbestand/PutLagerbestandListe", dtos),

        /**
         * Delete inventory
         * @param {string} guid
         * @returns {Promise<void>}
         */
        delete: (guid) => fluentApi.delete(`Lagerbestand/?id=${guid}`),

        /**
         * Get inventory history
         * @param {Date} vonDatum
         * @param {Date} bisDatum
         * @param {boolean} [mitLagerbuchungen=true]
         * @param {boolean} [mitReservierungen=true]
         * @param {string} [katalogArtikelGuid]
         * @returns {Promise<LagerbuchungDTO[]>}
         */
        getHistorie: (vonDatum, bisDatum, mitLagerbuchungen = true, mitReservierungen = true, katalogArtikelGuid) => {
            const url = `Lagerbuchung/?vonDatum=${vonDatum.toISOString()}&bisDatum=${bisDatum.toISOString()}&mitLagerbuchungen=${mitLagerbuchungen}&mitReservierungen=${mitReservierungen}&katalogArtikelGuid=${katalogArtikelGuid || ""}`;
            return fluentApi.get(url);
        },

        // LagerReservierungen
        reservierung: {
            /**
             * Get reservation by GUID
             * @param {string} guid
             * @returns {Promise<LagerReservierungDTO>}
             */
            get: (guid) => fluentApi.get(`LagerReservierungen/?id=${guid}`),

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
            getAll: (artikelnummer = "", farbkuerzel = "", farbcode = "", bezug = "", oberflaeche = "", changedSince) => {
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
            save: (dtos) => fluentApi.put("LagerReservierungen/", dtos),

            /**
             * Delete reservations
             * @param {string[]} guids
             * @returns {Promise<void>}
             */
            delete: (guids) => fluentApi.delete("LagerReservierungen", guids),
        },

        // Functions
        /**
         * Get producer mandant IDs
         * @returns {Promise<number[]>}
         */
        getProduzentenMandantIds: () =>
            fluentApi.get("Lagerbestand/GetProduzentIdListe"),

        /**
         * Initialize inventory for articles
         * @param {number} mandantID
         * @returns {Promise<number[]>}
         */
        initializeBestand: (mandantID) =>
            fluentApi.get(`Lagerbestand/InitializeBestandForArtikel?mandantId=${mandantID}`),
    };
}

/**
 * @typedef {ReturnType<typeof createLagerApi>} LagerApi
 */
