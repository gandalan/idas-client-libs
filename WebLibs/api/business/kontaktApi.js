/**
 * @typedef {import('../dtos/kunden.js').KontaktListItemDTO} KontaktListItemDTO
 * @typedef {import('../dtos/kunden.js').KontaktDTO} KontaktDTO
 */

/**
 * @typedef {Object} KontaktApi
 * @property {(ohneEndkunden?: boolean, includeASP?: boolean, includeAdditionalProperties?: boolean) => Promise<KontaktListItemDTO[]>} getList - Get list of all contacts
 * @property {(changedSince?: Date|null, ohneEndkunden?: boolean, includeASP?: boolean, includeAdditionalProperties?: boolean) => Promise<KontaktListItemDTO[]>} getListChangedSince - Get list of contacts changed since a specific date
 * @property {(kontaktGuid: string) => Promise<KontaktDTO>} getByGuid - Get contact by GUID
 * @property {(kundenNummer: string) => Promise<KontaktDTO>} getByKundenNummer - Get contact by customer number
 * @property {(kontakt: KontaktDTO) => Promise<KontaktDTO>} save - Save a contact
 * @property {(kontakteIds: string[]) => Promise<void>} archive - Archive multiple contacts
 * @property {(kontakteIds: string[]) => Promise<void>} unarchive - Unarchive multiple contacts
 * @property {(guidMapping: Record<string, string>) => Promise<void>} setFremdfertigungGuid - Set Fremdfertigung GUID mapping
 * @property {(kontaktGuid: string, mandantId: number) => Promise<KontaktDTO>} getForFunction - Get contact for function
 * @property {(changedSince?: Date|null) => Promise<Record<number, string[]>>} getAllForFunction - Get all contacts for function
 */

/**
 * @param {import("../fluentApi.js").FluentApi} fluentApi
 * @returns {KontaktApi}
 */
export function createKontaktApi(fluentApi) {
    return {
        async getList(ohneEndkunden = false, includeASP = true, includeAdditionalProperties = true) {
            return await fluentApi.get(`Kontakt?ohneEndkunden=${ohneEndkunden}&includeASP=${includeASP}&includeAdditionalProperties=${includeAdditionalProperties}`);
        },

        async getListChangedSince(changedSince = null, ohneEndkunden = false, includeASP = true, includeAdditionalProperties = true) {
            if (changedSince && changedSince > new Date(0)) {
                return await fluentApi.get(`Kontakt?changedSince=${changedSince.toISOString()}&ohneEndkunden=${ohneEndkunden}&includeASP=${includeASP}&includeAdditionalProperties=${includeAdditionalProperties}`);
            }
            return await fluentApi.get(`Kontakt?ohneEndkunden=${ohneEndkunden}&includeASP=${includeASP}&includeAdditionalProperties=${includeAdditionalProperties}`);
        },

        async getByGuid(kontaktGuid) {
            return await fluentApi.get(`Kontakt/${kontaktGuid}`);
        },

        async getByKundenNummer(kundenNummer) {
            return await fluentApi.get(`Kontakt/GetByKundenNummer?kundennummer=${kundenNummer}`);
        },

        async save(kontakt) {
            return await fluentApi.put("Kontakt", kontakt);
        },

        async archive(kontakteIds) {
            return await fluentApi.put("kontakt/archivieren", kontakteIds);
        },

        async unarchive(kontakteIds) {
            return await fluentApi.put("kontakt/entarchivieren", kontakteIds);
        },

        async setFremdfertigungGuid(guidMapping) {
            return await fluentApi.put("Kontakt/SetFremdfertigungGuid", guidMapping);
        },

        async getForFunction(kontaktGuid, mandantId) {
            return await fluentApi.get(`GetKontaktForFunction?id=${kontaktGuid}&mandantId=${mandantId}`);
        },

        async getAllForFunction(changedSince = null) {
            const isoString = changedSince ? changedSince.toISOString() : "";
            return await fluentApi.get(`GetAllKontakteForFunction?changedSince=${isoString}`);
        }
    };
}
