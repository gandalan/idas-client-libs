/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').UIDefinitionDTO} UIDefinitionDTO
 * @typedef {import('../dtos/index.js').UIScriptDTO} UIScriptDTO
 * @typedef {import('../dtos/index.js').UIEingabeFeldInfoDTO} UIEingabeFeldInfoDTO
 * @typedef {import('../dtos/index.js').TagInfoDTO} TagInfoDTO
 * @typedef {import('../dtos/index.js').TagVorlageDTO} TagVorlageDTO
 * @typedef {import('../dtos/index.js').FilterItemDTO} FilterItemDTO
 */

/**
 * UI API - User interface definitions and scripts
 * @param {FluentApi} fluentApi
 */
export function createUiApi(fluentApi) {
  return {
    // UIWebRoutinen
    /**
     * Get all UI definitions
     * @returns {Promise<UIDefinitionDTO[]>}
     */
    getAllUiDefinitions: () => fluentApi.get('UIDefinition?maxlevel=99'),

    /**
     * Get UI definition by GUID
     * @param {string} guid
     * @returns {Promise<UIDefinitionDTO>}
     */
    getUiDefinition: (guid) => fluentApi.get(`UIDefinition/Get?guid=${guid}&maxlevel=99`),

    /**
     * Save UI definition
     * @param {UIDefinitionDTO} uiDefinition
     * @returns {Promise<UIDefinitionDTO>}
     */
    saveUiDefinition: (uiDefinition) =>
      fluentApi.put(`UIDefinition/${uiDefinition.uiDefinitionGuid}`, uiDefinition),

    // UIScriptWebRoutinen
    /**
     * Get all UI scripts
     * @returns {Promise<UIScriptDTO[]>}
     */
    getAllUiScripts: () => fluentApi.get('UIScript/'),

    /**
     * Get UI script by name
     * @param {string} name
     * @returns {Promise<UIScriptDTO>}
     */
    getUiScript: (name) => fluentApi.get(`UIScript?name=${name}`),

    /**
     * Get UI script for function by name
     * @param {string} name
     * @returns {Promise<UIScriptDTO>}
     */
    getUiScriptForFunction: (name) => fluentApi.get(`UIScript/ForFunction?name=${name}`),

    /**
     * Save UI script
     * @param {UIScriptDTO} dto
     * @returns {Promise<void>}
     */
    saveUiScript: (dto) => fluentApi.put('UIScript/', dto),

    /**
     * Delete UI script
     * @param {string} guid
     * @returns {Promise<void>}
     */
    deleteUiScript: (guid) => fluentApi.delete(`UIScript?guid=${guid}`),

    // UIFeldInfoWebRoutinen
    /**
     * Get all UI field info
     * @returns {Promise<UIEingabeFeldInfoDTO[]>}
     */
    getAllUiFeldInfo: () => fluentApi.get('UIEingabeFeldInfo'),

    /**
     * Save UI field info
     * @param {UIEingabeFeldInfoDTO} uiEingabeFeldInfo
     * @returns {Promise<UIEingabeFeldInfoDTO>}
     */
    saveUiEingabeFeldInfo: (uiEingabeFeldInfo) =>
      fluentApi.put(`UIEingabeFeldInfo/${uiEingabeFeldInfo.uiEingabeFeldGuid}`, uiEingabeFeldInfo),

    // TagInfoWebRoutinen
    /**
     * Get all tag info
     * @param {Date} [changedSince]
     * @returns {Promise<TagInfoDTO[]>}
     */
    getAllTagInfo: (changedSince) => {
      if (changedSince) {
        return fluentApi.get(`GetAllTagInfo?changedSince=${changedSince.toISOString()}`);
      }
      return fluentApi.get('GetAllTagInfo');
    },

    /**
     * Get tag info suggestions
     * @param {Date} [changedSince]
     * @returns {Promise<TagInfoDTO[]>}
     */
    getTagInfoSuggestions: (changedSince) => {
      if (changedSince) {
        return fluentApi.get(`GetTagInfoSuggestions?changedSince=${changedSince.toISOString()}`);
      }
      return fluentApi.get('GetTagInfoSuggestions');
    },

    /**
     * Get tag info by object GUID
     * @param {string} objectGuid
     * @returns {Promise<TagInfoDTO[]>}
     */
    getTagInfo: (objectGuid) => fluentApi.get(`GetTagInfo?objectGuid=${objectGuid}`),

    /**
     * Get tag info for GUID list
     * @param {string[]} guidList
     * @returns {Promise<Record<string, TagInfoDTO[]>>}
     */
    getTagInfoForGuidList: (guidList) =>
      fluentApi.put('GetTagInfoForGuidList', guidList),

    /**
     * Get tag info for external production GUID list
     * @param {string[]} guidList
     * @returns {Promise<Record<string, TagInfoDTO[]>>}
     */
    getTagInfoForFremdfertigungGuidList: (guidList) =>
      fluentApi.put('GetTagInfoForFremdfertigungGuidList', guidList),

    /**
     * Add or update tag info
     * @param {TagInfoDTO} dto
     * @returns {Promise<void>}
     */
    addOrUpdateTagInfo: (dto) => fluentApi.post('TagInfo', dto),

    /**
     * Delete tag info
     * @param {TagInfoDTO} dto
     * @returns {Promise<void>}
     */
    deleteTagInfo: (dto) => fluentApi.delete('TagInfo', dto),

    /**
     * Get tag templates
     * @returns {Promise<TagVorlageDTO[]>}
     */
    getTagVorlagen: () => fluentApi.get('TagVorlagen/GetTagVorlagen'),

    /**
     * Add or update tag template
     * @param {TagVorlageDTO} dto
     * @returns {Promise<void>}
     */
    addOrUpdateTagVorlage: (dto) =>
      fluentApi.post('TagVorlagen/AddOrUpdateTagVorlagen', dto),

    /**
     * Delete tag template
     * @param {string} tagVorlageGuid
     * @returns {Promise<void>}
     */
    deleteTagVorlage: (tagVorlageGuid) =>
      fluentApi.delete(`TagVorlagen/DeleteTagVorlage?tagVorlageGuid=${tagVorlageGuid}`),

    /**
     * Get tag info for function
     * @param {string} objectGuid
     * @param {number} mandantID
     * @returns {Promise<TagInfoDTO[]>}
     */
    getTagInfoForFunction: (objectGuid, mandantID) =>
      fluentApi.get(`GetTagInfoForFunction?objectGuid=${objectGuid}&mandantID=${mandantID}`),

    /**
     * Get tag info list for function
     * @param {string[]} guidList
     * @param {number} mandantID
     * @returns {Promise<Record<string, TagInfoDTO[]>>}
     */
    getTagInfoListForFunction: (guidList, mandantID) =>
      fluentApi.put(`GetTagInfoListForFunction?mandantID=${mandantID}`, guidList),

    /**
     * Add tag info for function
     * @param {TagInfoDTO} dto
     * @param {number} mandantID
     * @returns {Promise<void>}
     */
    addTagInfoForFunction: (dto, mandantID) =>
      fluentApi.post(`AddTagInfoForFunction?mandantID=${mandantID}`, dto),

    /**
     * Delete tag info for function
     * @param {TagInfoDTO} dto
     * @param {number} mandantID
     * @returns {Promise<void>}
     */
    deleteTagInfoForFunction: (dto, mandantID) =>
      fluentApi.delete(`DeleteTagInfoForFunction?mandantID=${mandantID}`, dto),

    /**
     * Clean up tag infos
     * @returns {Promise<void>}
     */
    cleanUpTagInfos: () => fluentApi.delete('CleanUpTagInfos'),

    // FilterWebRoutinen
    /**
     * Get all filters
     * @returns {Promise<FilterItemDTO[]>}
     */
    getAllFilters: () => fluentApi.get('Filter'),

    /**
     * Get filter by ID
     * @param {string} id
     * @returns {Promise<FilterItemDTO>}
     */
    getFilter: (id) => fluentApi.get(`Filter?id=${id}`),

    /**
     * Get filters by context
     * @param {string} context
     * @returns {Promise<FilterItemDTO[]>}
     */
    getFiltersByContext: (context) => fluentApi.get(`Filter?context=${context}`),

    /**
     * Save filter
     * @param {FilterItemDTO} dto
     * @returns {Promise<void>}
     */
    saveFilter: (dto) => fluentApi.put('Filter', dto),

    // TranslateWebRoutinen
    /**
     * Translate text
     * @param {string} language
     * @param {string} text
     * @returns {Promise<string | null>}
     */
    translate: (language, text) => fluentApi.post(`translate?lang=${language}`, text),
  };
}

  /**
   * @typedef {ReturnType<typeof createUiApi>} UiApi
   */
