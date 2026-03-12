/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/belege.js').VorgangDTO} VorgangDTO
 * @typedef {import('../dtos/belege.js').VorgangListItemDTO} VorgangListItemDTO
 * @typedef {import('../dtos/belege.js').VorgangStatusDTO} VorgangStatusDTO
 */

/**
 * @typedef {Object} VorgangApi
 * @property {(jahr: number) => Promise<VorgangListItemDTO[]>} getList - Get list of vorgangs by year
 * @property {(status: string, jahr: number) => Promise<VorgangListItemDTO[]>} getListByStatus - Get list by status and year
 * @property {(status: string, jahr: number, changedSince: Date) => Promise<VorgangListItemDTO[]>} getListByStatusAndChangedSince - Get list by status, year, and changed since date
 * @property {(changedSince: Date, jahr: number, status: string, art: string, includeArchive: boolean, includeOthersData: boolean, search: string) => Promise<VorgangListItemDTO[]>} getListWithFilters - Get list with all filter options
 * @property {(jahr: number, status: string, changedSince: Date, art: string, includeArchive: boolean, includeOthersData: boolean, search: string) => Promise<VorgangListItemDTO[]>} getListByYearAndFilters - Get list by year with filters
 * @property {(kundeGuid: string) => Promise<VorgangListItemDTO[]>} getListByKunde - Get list by customer GUID
 * @property {(list: VorgangDTO[]) => Promise<void>} saveList - Save multiple vorgangs
 * @property {(vorgangGuid: string, neueVorgangsNummer: number) => Promise<void>} changeNummer - Change vorgang number
 * @property {(vorgang: VorgangDTO) => Promise<VorgangDTO>} save - Save a single vorgang
 * @property {(vorgangGuid: string, includeKunde: boolean, returnNullIfNotFound: boolean) => Promise<VorgangDTO>} getByGuid - Get vorgang by GUID
 * @property {(vorgangsNummer: number, jahr: number, includeKunde: boolean) => Promise<VorgangDTO>} getByNummer - Get vorgang by number and year
 * @property {(vorgangGuid: string) => Promise<VorgangStatusDTO>} getStatus - Get vorgang status
 * @property {(vorgangGuid: string, statusCode: string) => Promise<VorgangStatusDTO>} setStatus - Set vorgang status
 * @property {(vorgangGuids: string[], textStatus: string) => Promise<void>} setTextStatus - Set text status for multiple vorgangs
 * @property {(vorgangGuid: string) => Promise<void>} archive - Archive a vorgang
 * @property {(vorgangGuidList: string[]) => Promise<void>} archiveList - Archive multiple vorgangs
 * @property {(vorgangGuid: string) => Promise<void>} unarchive - Unarchive a vorgang
 * @property {(belegGuid: string, neueBelegArt: string) => Promise<void>} changeBelegArt - Change beleg art
 * @property {(changedSince: Date) => Promise<Record<number, VorgangListItemDTO[]>>} getAllForFunction - Get all vorgangs for function by changed since date
 * @property {(vorgangGuid: string, mandantId: number) => Promise<VorgangDTO>} getForFunction - Get vorgang for function
 */

/**
 * @param {FluentApi} api
 * @returns {VorgangApi}
 */
export function createVorgangApi(api) {
    return {
        async getList(jahr) {
            return await api.get(`Vorgang/?jahr=${jahr}`);
        },

        async getListByStatus(status, jahr) {
            return await api.get(`Vorgang/?status=${status}&jahr=${jahr}`);
        },

        async getListByStatusAndChangedSince(status, jahr, changedSince) {
            return await api.get(`Vorgang/?status=${status}&jahr=${jahr}&changedSince=${changedSince.toISOString()}`);
        },

        async getListWithFilters(changedSince, jahr = 0, status = "Alle", art = "", includeArchive = false, includeOthersData = false, search = "") {
            return await api.get(`Vorgang/?status=${status}&jahr=${jahr}&changedSince=${changedSince.toISOString()}&art=${art}&includeArchive=${includeArchive}&includeOthersData=${includeOthersData}&search=${search}`);
        },

        async getListByYearAndFilters(jahr, status, changedSince, art = "", includeArchive = false, includeOthersData = false, search = "") {
            return await api.get(`Vorgang/?status=${status}&jahr=${jahr}&changedSince=${changedSince.toISOString()}&art=${art}&includeArchive=${includeArchive}&includeOthersData=${includeOthersData}&search=${search}`);
        },

        async getListByKunde(kundeGuid) {
            return await api.get(`Vorgang/?kundeGuid=${kundeGuid}`);
        },

        async saveList(list) {
            for (const vorgang of list) {
                await this.save(vorgang);
            }
        },

        async changeNummer(vorgangGuid, neueVorgangsNummer) {
            return await api.put(`Vorgang/${vorgangGuid}/vorgangsnummer`, neueVorgangsNummer);
        },

        async save(vorgang) {
            return await api.put("Vorgang", vorgang);
        },

        async getByGuid(vorgangGuid, includeKunde, returnNullIfNotFound = false) {
            return await api.get(`Vorgang/${vorgangGuid}?includeKunde=${includeKunde}&returnNullIfNotFound=${returnNullIfNotFound}`);
        },

        async getByNummer(vorgangsNummer, jahr, includeKunde = false) {
            return await api.get(`Vorgang/${vorgangsNummer}/${jahr}?includeKunde=${includeKunde}`);
        },

        async getStatus(vorgangGuid) {
            return await api.get(`VorgangStatus/${vorgangGuid}`);
        },

        async setStatus(vorgangGuid, statusCode) {
            const set = {
                VorgangGuid: vorgangGuid,
                NeuerStatus: statusCode
            };
            return await api.put("VorgangStatus", set);
        },

        async setTextStatus(vorgangGuids, textStatus) {
            const set = {
                VorgangGuids: vorgangGuids,
                NeuerTextStatus: textStatus
            };
            return await api.post("VorgangTextStatus", set);
        },

        async archive(vorgangGuid) {
            return await api.post(`Archivierung/?vguid=${vorgangGuid}`, null);
        },

        async archiveList(vorgangGuidList) {
            return await api.post("Archivierung/", vorgangGuidList);
        },

        async unarchive(vorgangGuid) {
            return await api.post(`ArchivierungAufheben/?vguid=${vorgangGuid}`, null);
        },

        async changeBelegArt(belegGuid, neueBelegArt) {
            return await api.post(`BelegArt/?bguid=${belegGuid}&neueBelegArt=${neueBelegArt}`, null);
        },

        async getAllForFunction(changedSince) {
            return await api.get(`GetAllVorgangForFunction/?changedSince=${changedSince.toISOString()}`);
        },

        async getForFunction(vorgangGuid, mandantId) {
            return await api.get(`GetVorgangForFunction?id=${vorgangGuid}&mandantID=${mandantId}`);
        }
    };
}
