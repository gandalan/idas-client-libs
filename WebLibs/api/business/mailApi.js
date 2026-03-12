/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/index.js').JobStatusResponseDTO} JobStatusResponseDTO
 * @typedef {import('../dtos/index.js').JobStatusEntryDTO} JobStatusEntryDTO
 * @typedef {import('../dtos/index.js').MailJobInfo} MailJobInfo
 */

/**
 * Mail API - Email sending and management
 * @param {FluentApi} fluentApi
 */
export function createMailApi(fluentApi) {
    return {
        // MailWebRoutinen
        /**
         * Send mail
         * @param {MailJobInfo} job
         * @param {string[]} [attachments]
         * @returns {Promise<JobStatusResponseDTO>}
         */
        send: (job, attachments) => {
            const formData = new FormData();
            formData.append("jobAsString", JSON.stringify(job));
            if (attachments?.length) {
                attachments.forEach(file => formData.append("files", file));
            }
            return fluentApi.post("Mail", formData);
        },

        /**
         * Get mail status
         * @param {string} guid
         * @returns {Promise<JobStatusEntryDTO[]>}
         */
        getStatus: (guid) => fluentApi.get(`Mail/${guid}`),
    };
}

/**
 * @typedef {ReturnType<typeof createMailApi>} MailApi
 */
