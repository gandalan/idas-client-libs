/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').FileInfoDTO} FileInfoDTO
 */

/**
 * File API - File management and storage
 * @param {FluentApi} fluentApi
 */
export function createFileApi(fluentApi) {
    return {
        // FileWebRoutinen
        /**
         * Get file by name
         * @param {string} name
         * @returns {Promise<Uint8Array>}
         */
        get: (name) => fluentApi.get(`StaticFile/?name=${name}`),

        /**
         * Get file list
         * @returns {Promise<FileInfoDTO[]>}
         */
        getList: () => fluentApi.get("StaticFile"),

        /**
         * Get files as zip
         * @param {string[]} fileNames
         * @returns {Promise<Uint8Array>}
         */
        getZipped: (fileNames) => fluentApi.put("StaticFile", fileNames),

        // DataFileWebRoutinen
        data: {
            /**
             * Get data file
             * @param {string} filename
             * @returns {Promise<Uint8Array>}
             */
            get: (filename) => fluentApi.get(`DataFile/?filename=${filename}`),

            /**
             * Get data file list
             * @param {string} [directory='/']
             * @returns {Promise<FileInfoDTO[]>}
             */
            getList: (directory = "/") =>
                fluentApi.get(`DataFile/?subdir=${encodeURIComponent(directory)}`),

            /**
             * Save data file
             * @param {string} fileName
             * @param {Uint8Array} data
             * @returns {Promise<void>}
             */
            save: (fileName, data) =>
                fluentApi.put(`DataFile/?filename=${fileName}`, data),

            /**
             * Delete data file
             * @param {string} filename
             * @returns {Promise<void>}
             */
            delete: (filename) =>
                fluentApi.delete(`DataFile/?filename=${filename}`),
        },
    };
}

/**
 * @typedef {ReturnType<typeof createFileApi>} FileApi
 */
