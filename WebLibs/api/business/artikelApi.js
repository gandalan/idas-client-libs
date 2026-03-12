/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').WarenGruppeDTO} WarenGruppeDTO
 * @typedef {import('../dtos/index.js').KatalogArtikelDTO} KatalogArtikelDTO
 * @typedef {import('../dtos/index.js').ProduktGruppeDTO} ProduktGruppeDTO
 * @typedef {import('../dtos/index.js').ProduktFamilieDTO} ProduktFamilieDTO
 * @typedef {import('../dtos/index.js').KomponenteDTO} KomponenteDTO
 * @typedef {import('../dtos/index.js').VarianteDTO} VarianteDTO
 * @typedef {import('../dtos/index.js').KonturDTO} KonturDTO
 * @typedef {import('../dtos/index.js').KatalogArtikelIndiDatenDTO} KatalogArtikelIndiDatenDTO
 * @typedef {import('../dtos/index.js').SchnittDTO} SchnittDTO
 * @typedef {import('../dtos/belege.js').BelegDTO} BelegDTO
 */

/**
 * Artikel API - Article and product management
 * @param {FluentApi} fluentApi
 */
export function createArtikelApi(fluentApi) {
    return {
    // ArtikelWebRoutinen
    /**
     * Get all articles
     * @param {Date} [changedSince] - Filter by change date
     * @returns {Promise<WarenGruppeDTO[]>}
     */
        getAll: (changedSince) => {
            const url = changedSince
                ? `Artikel?changedSince=${changedSince.toISOString()}`
                : "Artikel";
            return fluentApi.get(url);
        },

        /**
     * Save article
     * @param {KatalogArtikelDTO} artikel
     * @returns {Promise<KatalogArtikelDTO>}
     */
        saveArtikel: (artikel) => fluentApi.put(`Artikel/${artikel.katalogArtikelGuid}`, artikel),

        /**
     * Delete article
     * @param {KatalogArtikelDTO} artikel
     * @returns {Promise<void>}
     */
        deleteArtikel: (artikel) => fluentApi.delete(`Artikel/${artikel.katalogArtikelGuid}`),

        // ArtikelIndiDatenWebRoutinen
        /**
     * Get all article individual data
     * @param {Date} [changedSince] - Filter by change date
     * @returns {Promise<KatalogArtikelIndiDatenDTO[]>}
     */
        getAllIndiDaten: (changedSince) => {
            const url = changedSince
                ? `ArtikelIndiDaten?changedSince=${changedSince.toISOString()}`
                : "ArtikelIndiDaten";
            return fluentApi.get(url);
        },

        /**
     * Save article individual data
     * @param {KatalogArtikelIndiDatenDTO} daten
     * @returns {Promise<void>}
     */
        saveArtikelIndiDaten: (daten) => fluentApi.put(`ArtikelIndiDaten/${daten.katalogArtikelGuid}`, daten),

        /**
     * Delete article individual data
     * @param {KatalogArtikelIndiDatenDTO} daten
     * @returns {Promise<void>}
     */
        deleteArtikelIndiDaten: (daten) => fluentApi.delete(`ArtikelIndiDaten/${daten.katalogArtikelGuid}`),

        // WarenGruppeWebRoutinen
        /**
     * Get all product groups
     * @returns {Promise<WarenGruppeDTO[]>}
     */
        getAllWarenGruppen: () => fluentApi.get("WarenGruppe"),

        /**
     * Save product group
     * @param {WarenGruppeDTO} dto
     * @returns {Promise<void>}
     */
        saveWarenGruppe: (dto) => fluentApi.put(`WarenGruppe/${dto.warenGruppeGuid}`, dto),

        // ProduktGruppenWebRoutinen
        /**
     * Get all product groups
     * @param {boolean} [includeFamilien=true] - Include families and variants
     * @returns {Promise<ProduktGruppeDTO[]>}
     */
        getAllProduktGruppen: (includeFamilien = true) =>
            fluentApi.get(`ProduktGruppe?includeFamilien=${includeFamilien}&includeVarianten=${includeFamilien}&includeUIDefs=${includeFamilien}&maxLevel=99`),

        /**
     * Save product group
     * @param {ProduktGruppeDTO} produktGruppe
     * @returns {Promise<ProduktGruppeDTO>}
     */
        saveProduktGruppe: (produktGruppe) =>
            fluentApi.put(`ProduktGruppe/${produktGruppe.produktGruppeGuid}`, produktGruppe),

        // ProduktFamilienWebRoutinen
        /**
     * Get all product families
     * @param {boolean} [includeVarianten=true] - Include variants
     * @returns {Promise<ProduktFamilieDTO[]>}
     */
        getAllProduktFamilien: (includeVarianten = true) =>
            fluentApi.get(`ProduktFamilie?includeVarianten=${includeVarianten}&includeUIDefs=${includeVarianten}&maxLevel=99`),

        /**
     * Save product family
     * @param {ProduktFamilieDTO} produktFamilie
     * @returns {Promise<ProduktFamilieDTO>}
     */
        saveProduktFamilie: (produktFamilie) =>
            fluentApi.put(`ProduktFamilie/${produktFamilie.produktFamilieGuid}`, produktFamilie),

        // KomponentenWebRoutinen
        /**
     * Get all components
     * @returns {Promise<KomponenteDTO[]>}
     */
        getAllKomponenten: () => fluentApi.get("Komponente"),

        /**
     * Save component
     * @param {KomponenteDTO} dto
     * @returns {Promise<void>}
     */
        saveKomponente: (dto) => fluentApi.put("Komponente", dto),

        // VariantenWebRoutinen
        /**
     * Get all variants
     * @returns {Promise<VarianteDTO[]>}
     */
        getAllVarianten: () => fluentApi.get("Variante?includeUIDefs=true&maxLevel=99"),

        /**
     * Get all variant GUIDs
     * @returns {Promise<string[]>}
     */
        getAllVariantenGuids: () => fluentApi.get("Variante/GetAllGuids"),

        /**
     * Get all variant changes since date
     * @param {Date} [changedSince]
     * @returns {Promise<string[]>}
     */
        getAllVariantenChanges: (changedSince) => {
            const url = changedSince
                ? `Variante/GetAllVariantenChanges?changedSince=${changedSince.toISOString()}`
                : "Variante/GetAllGuids";
            return fluentApi.get(url);
        },

        /**
     * Get variant by GUID
     * @param {string} varianteGuid
     * @param {boolean} [includeUIDefs=true]
     * @param {boolean} [includeKonfigs=true]
     * @returns {Promise<VarianteDTO>}
     */
        getVariante: (varianteGuid, includeUIDefs = true, includeKonfigs = true) =>
            fluentApi.get(`Variante/${varianteGuid}?includeUIDefs=${includeUIDefs}&maxLevel=99&includeKonfigs=${includeKonfigs}`),

        /**
     * Save variant
     * @param {VarianteDTO} variante
     * @returns {Promise<VarianteDTO>}
     */
        saveVariante: (variante) => fluentApi.put(`Variante/${variante.varianteGuid}`, variante),

        /**
     * Trigger variant cache web job
     * @returns {Promise<void>}
     */
        cacheWebJob: () => fluentApi.post("Variante/CacheWebJob", null),

        // KonturenWebRoutinen
        /**
     * Get all contours
     * @returns {Promise<KonturDTO[]>}
     */
        getAllKonturen: () => fluentApi.get("Kontur"),

        /**
     * Save contour
     * @param {KonturDTO} dto
     * @returns {Promise<void>}
     */
        saveKontur: (dto) => fluentApi.put("Kontur", dto),

        // SchnitteWebRoutinen
        /**
     * Get all cuts
     * @returns {Promise<SchnittDTO[]>}
     */
        getAllSchnitte: () => fluentApi.get("Schnitt"),

        /**
     * Save cut
     * @param {SchnittDTO} dto
     * @returns {Promise<void>}
     */
        saveSchnitt: (dto) => fluentApi.put("Schnitt", dto),

        // SonderfarbWebRoutinen
        /**
     * Calculate special colors for beleg
     * @param {string} belegGuid
      * @returns {Promise<BelegDTO>}
     */
        berechneSonderfarben: (belegGuid) => fluentApi.post(`BelegSonderfarben?bguid=${belegGuid}`, null),

        // BenutzerVariantenWebRoutinen
        /**
     * Get user variants
     * @param {string} benutzerGuid
     * @param {boolean} mitSperrliste
     * @returns {Promise<VarianteDTO[]>}
     */
        getBenutzerVarianten: (benutzerGuid, mitSperrliste) =>
            fluentApi.get(`BenutzerVarianten?id=${benutzerGuid}&mitSperrliste=${mitSperrliste}`),

        // ResetCacheVariantenListenWebRoutinen
        /**
     * Reset variant list cache
     * @returns {Promise<void>}
     */
        resetCacheVariantenListen: () => fluentApi.put("ResetCacheVariantenListen", null),
    };
}

/**
   * @typedef {ReturnType<typeof createArtikelApi>} ArtikelApi
   */
