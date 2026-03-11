/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').PreisermittlungsEinstellungenDTO} PreisermittlungsEinstellungenDTO
 * @typedef {import('../dtos/index.js').KonfigSatzInfoDTO} KonfigSatzInfoDTO
 * @typedef {import('../dtos/index.js').WerteListeDTO} WerteListeDTO
 * @typedef {import('../dtos/index.js').ContractDTO} ContractDTO
 * @typedef {import('../dtos/index.js').TemplateDTO} TemplateDTO
 * @typedef {import('../dtos/index.js').ChangeInfoDTO} ChangeInfoDTO
 * @typedef {import('../dtos/index.js').UpdateInfoDTO} UpdateInfoDTO
 */

/**
 * Settings API - Application settings and configuration
 * @param {FluentApi} fluentApi
 */
export function createSettingsApi(fluentApi) {
  return {
    // SettingsWebRoutinen
    /**
     * Get all settings
     * @returns {Promise<Record<string, object>>}
     */
    getAllSettings: () => fluentApi.get('Settings'),

    /**
     * Save setting
     * @param {string} key
     * @param {object} value
     * @returns {Promise<void>}
     */
    saveSetting: (key, value) => fluentApi.put(`Settings/${key}`, value),

    // PreiskonditionenWebRoutinen
    /**
     * Get price conditions
     * @returns {Promise<PreisermittlungsEinstellungenDTO>}
     */
    getPreiskonditionen: () => fluentApi.get('Preiskonditionen/'),

    /**
     * Save price conditions
     * @param {string} konditionen
     * @returns {Promise<string>}
     */
    savePreiskonditionen: (konditionen) => fluentApi.put('Preiskonditionen/', konditionen),

    // KonfigSatzInfoWebRoutinen
    /**
     * Get all config set info
     * @returns {Promise<KonfigSatzInfoDTO[]>}
     */
    getAllKonfigSatzInfo: () => fluentApi.get('KonfigSatzInfo'),

    /**
     * Save config set info
     * @param {KonfigSatzInfoDTO} konfigSatzInfo
     * @returns {Promise<KonfigSatzInfoDTO>}
     */
    saveKonfigSatzInfo: (konfigSatzInfo) => fluentApi.put('KonfigSatzInfo', konfigSatzInfo),

    // WertelistenWebRoutinen
    /**
     * Get all value lists
     * @param {boolean} includeAutoWerteListen
     * @returns {Promise<WerteListeDTO[]>}
     */
    getAllWertelisten: (includeAutoWerteListen) =>
      fluentApi.get(`WerteListe?includeAutoWerteListen=${includeAutoWerteListen}`),

    /**
     * Get value list by GUID
     * @param {string} wertelisteGuid
     * @param {boolean} [includeAutoWerteListen=true]
     * @returns {Promise<WerteListeDTO>}
     */
    getWerteliste: (wertelisteGuid, includeAutoWerteListen = true) =>
      fluentApi.get(`WerteListe/${wertelisteGuid}?includeAutoWerteListen=${includeAutoWerteListen}`),

    /**
     * Save value list
     * @param {WerteListeDTO} dto
     * @returns {Promise<void>}
     */
    saveWerteliste: (dto) => fluentApi.put(`WerteListe/${dto.werteListeGuid}`, dto),

    // ContractWebRoutinen
    /**
     * Get all contracts
     * @returns {Promise<ContractDTO[]>}
     */
    getAllContracts: () => fluentApi.get('Contracts'),

    /**
     * Save contract
     * @param {ContractDTO} dto
     * @returns {Promise<ContractDTO>}
     */
    saveContract: (dto) => fluentApi.put('Contracts', dto),

    /**
     * Delete contract
     * @param {ContractDTO} dto
     * @returns {Promise<void>}
     */
    deleteContract: (dto) => fluentApi.delete(`Contracts/${dto.contractGuid}`),

    // TemplateWebRoutinen
    /**
     * Get all templates
     * @returns {Promise<TemplateDTO[]>}
     */
    getAllTemplates: () => fluentApi.get('Template'),

    /**
     * Get template by ID
     * @param {string} id
     * @returns {Promise<TemplateDTO>}
     */
    getTemplate: (id) => fluentApi.get(`Template?id=${id}`),

    /**
     * Save template
     * @param {TemplateDTO} dto
     * @returns {Promise<void>}
     */
    saveTemplate: (dto) => fluentApi.put(`Template/${dto.templateGuid}`, dto),

    /**
     * Delete template
     * @param {string} templateGuid
     * @returns {Promise<void>}
     */
    deleteTemplate: (templateGuid) => fluentApi.delete(`Template/${templateGuid}`),

    // ChangeInfoWebRoutinen
    /**
     * Get change info
     * @returns {Promise<ChangeInfoDTO>}
     */
    getChangeInfo: () => fluentApi.get('ChangeInfo'),

    // UpdateInfoWebRoutinen
    /**
     * Get update info
     * @returns {Promise<UpdateInfoDTO>}
     */
    getUpdateInfo: () => fluentApi.get('UpdateInfo'),

    // DataMigrationHistoryWebRoutinen
    /**
     * Get data migration history version
     * @returns {Promise<number>}
     */
    getDataMigrationHistoryVersion: () => fluentApi.get('DataMigrationHistory'),

    /**
     * Set data migration history version
     * @param {number} newVersion
     * @returns {Promise<void>}
     */
    setDataMigrationHistoryVersion: (newVersion) =>
      fluentApi.put('DataMigrationHistory', newVersion.toString()),
  };
}

/**
 * @typedef {ReturnType<typeof createSettingsApi>} SettingsApi
 */
