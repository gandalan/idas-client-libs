/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').ChangeDTO} ChangeDTO
 * @typedef {import('../dtos/index.js').TagInfoDTO} TagInfoDTO
 * @typedef {import('../dtos/index.js').TagVorlageDTO} TagVorlageDTO
 * @typedef {Object} FilterItemDTO
 * @typedef {import('../dtos/index.js').ChangeInfoDTO} ChangeInfoDTO
 * @typedef {import('../dtos/index.js').UpdateInfoDTO} UpdateInfoDTO
 */

/**
 * System API - System administration and configuration
 * @param {FluentApi} fluentApi
 */
export function createSystemApi(fluentApi) {
    return {
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
        deleteOldChanges: () => fluentApi.delete("Change"),

        // TagInfoWebRoutinen
        tagInfo: {
            /**
             * Get all tag info
             * @param {Date} [changedSince]
             * @returns {Promise<TagInfoDTO[]>}
             */
            getAll: (changedSince) => {
                if (changedSince) {
                    return fluentApi.get(`GetAllTagInfo?changedSince=${changedSince.toISOString()}`);
                }
                return fluentApi.get("GetAllTagInfo");
            },

            /**
             * Get tag info suggestions
             * @param {Date} [changedSince]
             * @returns {Promise<TagInfoDTO[]>}
             */
            getSuggestions: (changedSince) => {
                if (changedSince) {
                    return fluentApi.get(`GetTagInfoSuggestions?changedSince=${changedSince.toISOString()}`);
                }
                return fluentApi.get("GetTagInfoSuggestions");
            },

            /**
             * Get tag info by object GUID
             * @param {string} objectGuid
             * @returns {Promise<TagInfoDTO[]>}
             */
            get: (objectGuid) => fluentApi.get(`GetTagInfo?objectGuid=${objectGuid}`),

            /**
             * Get tag info for GUID list
             * @param {string[]} guidList
             * @returns {Promise<Record<string, TagInfoDTO[]>>}
             */
            getForGuidList: (guidList) =>
                fluentApi.put("GetTagInfoForGuidList", guidList),

            /**
             * Get tag info for external production GUID list
             * @param {string[]} guidList
             * @returns {Promise<Record<string, TagInfoDTO[]>>}
             */
            getForFremdfertigungGuidList: (guidList) =>
                fluentApi.put("GetTagInfoForFremdfertigungGuidList", guidList),

            /**
             * Add or update tag info
             * @param {TagInfoDTO} dto
             * @returns {Promise<void>}
             */
            addOrUpdate: (dto) => fluentApi.post("TagInfo", dto),

            /**
             * Delete tag info
             * @param {TagInfoDTO} dto
             * @returns {Promise<void>}
             */
            delete: (dto) => fluentApi.delete("TagInfo", dto),

            /**
             * Get tag templates
             * @returns {Promise<TagVorlageDTO[]>}
             */
            getVorlagen: () => fluentApi.get("TagVorlagen/GetTagVorlagen"),

            /**
             * Add or update tag template
             * @param {TagVorlageDTO} dto
             * @returns {Promise<void>}
             */
            addOrUpdateVorlage: (dto) =>
                fluentApi.post("TagVorlagen/AddOrUpdateTagVorlagen", dto),

            /**
             * Delete tag template
             * @param {string} tagVorlageGuid
             * @returns {Promise<void>}
             */
            deleteVorlage: (tagVorlageGuid) =>
                fluentApi.delete(`TagVorlagen/DeleteTagVorlage?tagVorlageGuid=${tagVorlageGuid}`),

            /**
             * Get tag info for function
             * @param {string} objectGuid
             * @param {number} mandantID
             * @returns {Promise<TagInfoDTO[]>}
             */
            getForFunction: (objectGuid, mandantID) =>
                fluentApi.get(`GetTagInfoForFunction?objectGuid=${objectGuid}&mandantID=${mandantID}`),

            /**
             * Get tag info list for function
             * @param {string[]} guidList
             * @param {number} mandantID
             * @returns {Promise<Record<string, TagInfoDTO[]>>}
             */
            getListForFunction: (guidList, mandantID) =>
                fluentApi.put(`GetTagInfoListForFunction?mandantID=${mandantID}`, guidList),

            /**
             * Add tag info for function
             * @param {TagInfoDTO} dto
             * @param {number} mandantID
             * @returns {Promise<void>}
             */
            addForFunction: (dto, mandantID) =>
                fluentApi.post(`AddTagInfoForFunction?mandantID=${mandantID}`, dto),

            /**
             * Delete tag info for function
             * @param {TagInfoDTO} dto
             * @param {number} mandantID
             * @returns {Promise<void>}
             */
            deleteForFunction: (dto, mandantID) =>
                fluentApi.delete(`DeleteTagInfoForFunction?mandantID=${mandantID}`, dto),

            /**
             * Clean up tag infos
             * @returns {Promise<void>}
             */
            cleanUp: () => fluentApi.delete("CleanUpTagInfos"),
        },

        // FilterWebRoutinen
        filter: {
            /**
             * Get all filters
             * @returns {Promise<FilterItemDTO[]>}
             */
            getAll: () => fluentApi.get("Filter"),

            /**
             * Get filter by ID
             * @param {string} id
             * @returns {Promise<FilterItemDTO>}
             */
            get: (id) => fluentApi.get(`Filter?id=${id}`),

            /**
             * Get filters by context
             * @param {string} context
             * @returns {Promise<FilterItemDTO[]>}
             */
            getByContext: (context) => fluentApi.get(`Filter?context=${context}`),

            /**
             * Save filter
             * @param {FilterItemDTO} dto
             * @returns {Promise<void>}
             */
            save: (dto) => fluentApi.put("Filter", dto),
        },

        // ChangeInfoWebRoutinen
        /**
         * Get change info
         * @returns {Promise<ChangeInfoDTO>}
         */
        getChangeInfo: () => fluentApi.get("ChangeInfo"),

        // UpdateInfoWebRoutinen
        /**
         * Get update info
         * @returns {Promise<UpdateInfoDTO>}
         */
        getUpdateInfo: () => fluentApi.get("UpdateInfo"),
    };
}

/**
 * @typedef {ReturnType<typeof createSystemApi>} SystemApi
 */
