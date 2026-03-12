/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').FarbeDTO} FarbeDTO
 * @typedef {import('../dtos/index.js').FarbGruppeDTO} FarbGruppeDTO
 * @typedef {import('../dtos/index.js').OberflaecheDTO} OberflaecheDTO
 * @typedef {import('../dtos/index.js').FarbKuerzelDTO} FarbKuerzelDTO
 * @typedef {import('../dtos/index.js').FarbKuerzelGruppeDTO} FarbKuerzelGruppeDTO
 * @typedef {import('../dtos/index.js').FarbgruppenaufpreiseDTO} FarbgruppenaufpreiseDTO
 * @typedef {import('../dtos/index.js').ProduzentenFarbGruppeDTO} ProduzentenFarbGruppeDTO
 */

/**
 * Farbe API - Color management
 * @param {FluentApi} fluentApi
 */
export function createFarbeApi(fluentApi) {
    return {
        // FarbenWebRoutinen
        /**
         * Get all colors
         * @returns {Promise<FarbeDTO[]>}
         */
        getAllFarben: () => fluentApi.get("Farben"),

        /**
         * Save color
         * @param {FarbeDTO} dto
         * @returns {Promise<void>}
         */
        saveFarbe: (dto) => fluentApi.put(`Farben/${dto.FarbItemGuid}`, dto),

        // OberflaechenWebRoutinen
        /**
         * Get all surfaces
         * @returns {Promise<OberflaecheDTO[]>}
         */
        getAllOberflaechen: () => fluentApi.get("Oberflaeche"),

        /**
         * Save surface
         * @param {OberflaecheDTO} dto
         * @returns {Promise<void>}
         */
        saveOberflaeche: (dto) => fluentApi.put(`Oberflaeche/${dto.OberflaecheGuid}`, dto),

        // FarbGruppenWebRoutinen
        /**
         * Get all color groups
         * @returns {Promise<FarbGruppeDTO[]>}
         */
        getAllFarbGruppen: () => fluentApi.get("FarbGruppen"),

        /**
         * Save color group
         * @param {FarbGruppeDTO} dto
         * @returns {Promise<void>}
         */
        saveFarbGruppe: (dto) => fluentApi.put(`FarbGruppen/${dto.FarbItemGroupGuid}`, dto),

        // FarbKuerzelWebRoutinen
        /**
         * Get all color codes
         * @returns {Promise<FarbKuerzelDTO[]>}
         */
        getAllFarbKuerzel: () => fluentApi.get("FarbKuerzel"),

        /**
         * Save color code
         * @param {FarbKuerzelDTO} dto
         * @returns {Promise<void>}
         */
        saveFarbKuerzel: (dto) => fluentApi.put(`FarbKuerzel/${dto.FarbKuerzelGuid}`, dto),

        // FarbKuerzelGruppenWebRoutinen
        /**
         * Get all color code groups
         * @returns {Promise<FarbKuerzelGruppeDTO[]>}
         */
        getAllFarbKuerzelGruppen: () => fluentApi.get("FarbKuerzelGruppe"),

        /**
         * Save color code group
         * @param {FarbKuerzelGruppeDTO} dto
         * @returns {Promise<void>}
         */
        saveFarbKuerzelGruppe: (dto) => fluentApi.put("FarbKuerzelGruppe/", dto),

        // FarbgruppenaufpreisWebRoutinen
        /**
         * Get color group surcharges
         * @returns {Promise<FarbgruppenaufpreiseDTO[]>}
         */
        getFarbgruppenaufpreise: () => fluentApi.get("Farbgruppenaufpreis"),

        /**
         * Save color group surcharge
         * @param {FarbgruppenaufpreiseDTO} dto
         * @returns {Promise<void>}
         */
        saveFarbgruppenaufpreise: (dto) => fluentApi.put("Farbgruppenaufpreis", dto),

        // ProduzentenFarbGruppenWebRoutinen
        /**
         * Get all producer color groups
         * @returns {Promise<ProduzentenFarbGruppeDTO[]>}
         */
        getAllProduzentenFarbGruppen: () => fluentApi.get("ProduzentenFarbGruppen"),

        /**
         * Save producer color group
         * @param {ProduzentenFarbGruppeDTO} dto
         * @returns {Promise<void>}
         */
        saveProduzentenFarbGruppe: (dto) =>
            fluentApi.put(`ProduzentenFarbGruppen/${dto.ProduzentenFarbGruppeGuid}`, dto),

        /**
         * Delete producer color group
         * @param {string} produzentenFarbGruppeGuid
         * @returns {Promise<void>}
         */
        deleteProduzentenFarbGruppe: (produzentenFarbGruppeGuid) =>
            fluentApi.delete(`ProduzentenFarbGruppen/${produzentenFarbGruppeGuid}`),
    };
}

/**
 * @typedef {ReturnType<typeof createFarbeApi>} FarbeApi
 */
