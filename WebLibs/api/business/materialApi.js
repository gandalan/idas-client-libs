/**
 * @typedef {Object} MaterialDTO
 * @property {string} MaterialGuid
 * @property {string} Bezeichnung
 * @property {boolean} IstSaegbar
 * @property {boolean} IstBeschichtbar
 * @property {boolean} IstFaerbbar
 * @property {Date} ChangedDate
 * @property {number} Version
 * @property {Array<string>} MoeglicheBearbeitungsMethoden
 */

/** @typedef {import('../fluentApi.js').FluentApi} FluentApi */

/**
 * @typedef {Object} MaterialApi
 * @property {() => Promise<MaterialDTO[]>} getAll - Get all materials
 * @property {(material: MaterialDTO) => Promise<void>} saveMaterial - Save a material
 */

/**
 * @param {FluentApi} fluentApi
 * @returns {MaterialApi}
 */
export function createMaterialApi(fluentApi) {
    const api = fluentApi.withBaseUrl("ModellDaten");

    return {
        async getAll() {
            return await api.get("Material");
        },

        async saveMaterial(material) {
            return await api.put("Material", material);
        }
    };
}
