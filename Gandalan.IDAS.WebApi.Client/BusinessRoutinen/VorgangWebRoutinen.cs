using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class VorgangWebRoutinen : WebRoutinenBase
    {
        public VorgangWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(int jahr)
            => await GetAsync<VorgangListItemDTO[]>($"Vorgang/?jahr={jahr}");

        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(string status, int jahr)
            => await GetAsync<VorgangListItemDTO[]>($"Vorgang/?status={status}&jahr={jahr}");

        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(string status, int jahr, DateTime changedSince)
            => await GetAsync<VorgangListItemDTO[]>($"Vorgang/?status={status}&jahr={jahr}&changedSince={changedSince:o}");

        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(DateTime changedSince, int jahr = 0, string status = "Alle", string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "")
            => await GetAsync<VorgangListItemDTO[]>($"Vorgang/?status={status}&jahr={jahr}&changedSince={changedSince:o}&art={art}&includeArchive={includeArchive}&includeOthersData={includeOthersData}&search={search}");

        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(int jahr, string status, DateTime changedSince, string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "")
            => await GetAsync<VorgangListItemDTO[]>($"Vorgang/?status={status}&jahr={jahr}&changedSince={changedSince:o}&art={art}&includeArchive={includeArchive}&includeOthersData={includeOthersData}&search={search}");

        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(Guid kundeGuid)
            => await GetAsync<VorgangListItemDTO[]>($"Vorgang/?kundeGuid={kundeGuid}");

        public async Task SendeVorgaengeAsync(VorgangDTO[] list)
        {
            foreach (var v in list)
            {
                await SendeVorgangAsync(v);
            }
        }

        public async Task<VorgangDTO> SendeVorgangAsync(VorgangDTO vorgang)
            => await PutAsync<VorgangDTO>("Vorgang", vorgang);

        public async Task<VorgangDTO> LadeVorgangAsync(Guid vorgangGuid, bool mitKunde)
            => await GetAsync<VorgangDTO>("Vorgang/" + vorgangGuid + "?includeKunde=" + mitKunde);

        public async Task<VorgangDTO> LadeVorgangAsync(long vorgangsNummer, int jahr, bool mitKunde = false)
            => await GetAsync<VorgangDTO>($"Vorgang/{vorgangsNummer}/{jahr}?includeKunde={mitKunde}");

        public async Task<VorgangStatusDTO> GetStatusAsync(Guid vorgangGuid)
            => await GetAsync<VorgangStatusDTO>("VorgangStatus/" + vorgangGuid);

        public async Task<VorgangStatusDTO> SetStatusAsync(Guid vorgangGuid, string statusCode)
        {
            var set = new VorgangStatusDTO
            {
                VorgangGuid = vorgangGuid,
                NeuerStatus = statusCode
            };
            return await PutAsync<VorgangStatusDTO>("VorgangStatus", set);
        }

        public async Task SetTextStatusAsync(List<Guid> vorgangGuids, string textStatus)
        {
            var set = new VorgangTextStatusDTO
            {
                VorgangGuids = vorgangGuids,
                NeuerTextStatus = textStatus
            };
            await PostAsync("VorgangTextStatus", set);
        }

        public async Task ArchiviereVorgangAsync(Guid vorgangGuid)
            => await PostAsync("Archivierung/?vguid=" + vorgangGuid, null);

        public async Task ArchiviereVorgangListAsync(List<Guid> vorgangGuidList)
            => await PostAsync("Archivierung/", vorgangGuidList);

        public async Task AendereBelegArtAsync(Guid belegGuid, string neueBelegArt)
            => await PostAsync("BelegArt/?bguid=" + belegGuid + "&neueBelegArt=" + neueBelegArt, null);

        public async Task<Dictionary<long, List<VorgangListItemDTO>>> GetAllVorgangForFunctionAsync(DateTime changedSince)
            => await GetAsync<Dictionary<long, List<VorgangListItemDTO>>>($"GetAllVorgangForFunction/?changedSince={changedSince:o}");

        public async Task<VorgangDTO> GetVorgangForFunctionAsync(Guid vorgangGuid, long mandantId)
            => await GetAsync<VorgangDTO>($"GetVorgangForFunction?id={vorgangGuid}&mandantID={mandantId}");
    }
}
