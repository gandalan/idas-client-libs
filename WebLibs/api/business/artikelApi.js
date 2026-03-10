/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').WarenGruppeDTO} WarenGruppeDTO
 * @typedef {import('../dtos/index.js').KatalogArtikelDTO} KatalogArtikelDTO
 * @typedef {import('../dtos/index.js').ProduktGruppeDTO} ProduktGruppeDTO
 * @typedef {import('../dtos/index.js').ProduktFamilieDTO} ProduktFamilieDTO
 * @typedef {import('../dtos/index.js').FarbGruppeDTO} FarbGruppeDTO
 * @typedef {import('../dtos/index.js').FarbeDTO} FarbeDTO
 * @typedef {import('../dtos/index.js').OberflaecheDTO} OberflaecheDTO
 * @typedef {import('../dtos/index.js').KomponenteDTO} KomponenteDTO
 * @typedef {import('../dtos/index.js').VarianteDTO} VarianteDTO
 * @typedef {import('../dtos/index.js').KonturDTO} KonturDTO
 * @typedef {import('../dtos/index.js').FarbKuerzelDTO} FarbKuerzelDTO
 * @typedef {import('../dtos/index.js').FarbKuerzelGruppeDTO} FarbKuerzelGruppeDTO
 * @typedef {import('../dtos/index.js').FarbgruppenaufpreiseDTO} FarbgruppenaufpreiseDTO
 * @typedef {import('../dtos/index.js').ProduzentenFarbGruppeDTO} ProduzentenFarbGruppeDTO
 * @typedef {import('../dtos/index.js').KatalogArtikelIndiDatenDTO} KatalogArtikelIndiDatenDTO
 * @typedef {import('../dtos/index.js').AnpassungDTO} AnpassungDTO
 * @typedef {import('../dtos/index.js').AnpassungVorlageDTO} AnpassungVorlageDTO
 * @typedef {import('../dtos/index.js').SchnittDTO} SchnittDTO
 */

/**
 * Artikel API - Article and product management
 * @param {FluentApi} fluentApi
 * @returns {ArtikelApi}
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
        : 'Artikel';
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
        : 'ArtikelIndiDaten';
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
    getAllWarenGruppen: () => fluentApi.get('WarenGruppe'),

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

    // FarbGruppenWebRoutinen
    /**
     * Get all color groups
     * @returns {Promise<FarbGruppeDTO[]>}
     */
    getAllFarbGruppen: () => fluentApi.get('FarbGruppen'),

    /**
     * Save color group
     * @param {FarbGruppeDTO} dto
     * @returns {Promise<void>}
     */
    saveFarbGruppe: (dto) => fluentApi.put(`FarbGruppen/${dto.farbItemGroupGuid}`, dto),

    // FarbenWebRoutinen
    /**
     * Get all colors
     * @returns {Promise<FarbeDTO[]>}
     */
    getAllFarben: () => fluentApi.get('Farben'),

    /**
     * Save color
     * @param {FarbeDTO} dto
     * @returns {Promise<void>}
     */
    saveFarbe: (dto) => fluentApi.put(`Farben/${dto.farbItemGuid}`, dto),

    // OberflaechenWebRoutinen
    /**
     * Get all surfaces
     * @returns {Promise<OberflaecheDTO[]>}
     */
    getAllOberflaechen: () => fluentApi.get('Oberflaeche'),

    /**
     * Save surface
     * @param {OberflaecheDTO} dto
     * @returns {Promise<void>}
     */
    saveOberflaeche: (dto) => fluentApi.put(`Oberflaeche/${dto.oberflaecheGuid}`, dto),

    // KomponentenWebRoutinen
    /**
     * Get all components
     * @returns {Promise<KomponenteDTO[]>}
     */
    getAllKomponenten: () => fluentApi.get('Komponente'),

    /**
     * Save component
     * @param {KomponenteDTO} dto
     * @returns {Promise<void>}
     */
    saveKomponente: (dto) => fluentApi.put('Komponente', dto),

    // VariantenWebRoutinen
    /**
     * Get all variants
     * @returns {Promise<VarianteDTO[]>}
     */
    getAllVarianten: () => fluentApi.get('Variante?includeUIDefs=true&maxLevel=99'),

    /**
     * Get all variant GUIDs
     * @returns {Promise<string[]>}
     */
    getAllVariantenGuids: () => fluentApi.get('Variante/GetAllGuids'),

    /**
     * Get all variant changes since date
     * @param {Date} [changedSince]
     * @returns {Promise<string[]>}
     */
    getAllVariantenChanges: (changedSince) => {
      const url = changedSince
        ? `Variante/GetAllVariantenChanges?changedSince=${changedSince.toISOString()}`
        : 'Variante/GetAllGuids';
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
    cacheWebJob: () => fluentApi.post('Variante/CacheWebJob', null),

    // KonturenWebRoutinen
    /**
     * Get all contours
     * @returns {Promise<KonturDTO[]>}
     */
    getAllKonturen: () => fluentApi.get('Kontur'),

    /**
     * Save contour
     * @param {KonturDTO} dto
     * @returns {Promise<void>}
     */
    saveKontur: (dto) => fluentApi.put('Kontur', dto),

    // FarbKuerzelWebRoutinen
    /**
     * Get all color codes
     * @returns {Promise<FarbKuerzelDTO[]>}
     */
    getAllFarbKuerzel: () => fluentApi.get('FarbKuerzel'),

    /**
     * Save color code
     * @param {FarbKuerzelDTO} dto
     * @returns {Promise<void>}
     */
    saveFarbKuerzel: (dto) => fluentApi.put(`FarbKuerzel/${dto.farbKuerzelGuid}`, dto),

    // FarbKuerzelGruppenWebRoutinen
    /**
     * Get all color code groups
     * @returns {Promise<FarbKuerzelGruppeDTO[]>}
     */
    getAllFarbKuerzelGruppen: () => fluentApi.get('FarbKuerzelGruppe'),

    /**
     * Save color code group
     * @param {FarbKuerzelGruppeDTO} dto
     * @returns {Promise<void>}
     */
    saveFarbKuerzelGruppe: (dto) => fluentApi.put('FarbKuerzelGruppe/', dto),

    // FarbgruppenaufpreisWebRoutinen
    /**
     * Get color group surcharges
     * @returns {Promise<FarbgruppenaufpreiseDTO[]>}
     */
    getFarbgruppenaufpreise: () => fluentApi.get('Farbgruppenaufpreis'),

    /**
     * Save color group surcharge
     * @param {FarbgruppenaufpreiseDTO} dto
     * @returns {Promise<void>}
     */
    saveFarbgruppenaufpreise: (dto) => fluentApi.put('Farbgruppenaufpreis', dto),

    // ProduzentenFarbGruppenWebRoutinen
    /**
     * Get all producer color groups
     * @returns {Promise<ProduzentenFarbGruppeDTO[]>}
     */
    getAllProduzentenFarbGruppen: () => fluentApi.get('ProduzentenFarbGruppen'),

    /**
     * Save producer color group
     * @param {ProduzentenFarbGruppeDTO} dto
     * @returns {Promise<void>}
     */
    saveProduzentenFarbGruppe: (dto) => fluentApi.put(`ProduzentenFarbGruppen/${dto.produzentenFarbGruppeGuid}`, dto),

    /**
     * Delete producer color group
     * @param {string} produzentenFarbGruppeGuid
     * @returns {Promise<void>}
     */
    deleteProduzentenFarbGruppe: (produzentenFarbGruppeGuid) =>
      fluentApi.delete(`ProduzentenFarbGruppen/${produzentenFarbGruppeGuid}`),

    // AnpassungenWebRoutinen
    /**
     * Get all adjustments
     * @returns {Promise<AnpassungDTO[]>}
     */
    getAllAnpassungen: () => fluentApi.get('Anpassungen'),

    /**
     * Save adjustment
     * @param {AnpassungDTO} dto
     * @returns {Promise<void>}
     */
    saveAnpassung: (dto) => fluentApi.put(`Anpassungen/${dto.anpassungGuid}`, dto),

    /**
     * Delete adjustment
     * @param {string} anpassungGuid
     * @returns {Promise<void>}
     */
    deleteAnpassung: (anpassungGuid) => fluentApi.delete(`Anpassungen/${anpassungGuid}`),

    /**
     * Run adjustment web job
     * @returns {Promise<void>}
     */
    anpassungenWebJob: () => fluentApi.post('Anpassungen/WebJob', ''),

    // AnpassungVorlagenWebRoutinen
    /**
     * Get all adjustment templates
     * @returns {Promise<AnpassungVorlageDTO[]>}
     */
    getAllAnpassungVorlagen: () => fluentApi.get('AnpassungVorlagen'),

    /**
     * Get adjustment template by GUID
     * @param {string} guid
     * @returns {Promise<AnpassungVorlageDTO>}
     */
    getAnpassungVorlage: (guid) => fluentApi.get(`AnpassungVorlagen/${guid}`),

    /**
     * Save adjustment template
     * @param {AnpassungVorlageDTO} dto
     * @returns {Promise<void>}
     */
    saveAnpassungVorlage: (dto) => fluentApi.put(`AnpassungVorlagen/${dto.anpassungVorlageGuid}`, dto),

    /**
     * Delete adjustment template
     * @param {string} guid
     * @returns {Promise<void>}
     */
    deleteAnpassungVorlage: (guid) => fluentApi.delete(`AnpassungVorlagen/${guid}`),

    // SchnitteWebRoutinen
    /**
     * Get all cuts
     * @returns {Promise<SchnittDTO[]>}
     */
    getAllSchnitte: () => fluentApi.get('Schnitt'),

    /**
     * Save cut
     * @param {SchnittDTO} dto
     * @returns {Promise<void>}
     */
    saveSchnitt: (dto) => fluentApi.put('Schnitt', dto),

    // SonderfarbWebRoutinen
    /**
     * Calculate special colors for beleg
     * @param {string} belegGuid
     * @returns {Promise<import('../dtos/index.js').BelegDTO>}
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
    resetCacheVariantenListen: () => fluentApi.put('ResetCacheVariantenListen', null),
  };
}
