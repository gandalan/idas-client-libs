using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class LieferscheineWebRoutinen : WebRoutinenBase
    {
        public LieferscheineWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<BaseListItemDTO[]> LadeListeAsync(int jahr)
            => await GetAsync<BaseListItemDTO[]>("Lieferscheine/?jahr=" + jahr);

        public async Task<BaseListItemDTO[]> LadeListeAsync(string status, int jahr)
            => await GetAsync<BaseListItemDTO[]>($"Lieferscheine/?status={status}&jahr={jahr}");

        public async Task<BaseListItemDTO[]> LadeListeAsync(string status, int jahr, DateTime changedSince)
            => await GetAsync<BaseListItemDTO[]>($"Lieferscheine/?status={status}&jahr={jahr}&changedSince={changedSince:o}");

        public async Task<BaseListItemDTO[]> LadeListe(int jahr, string status, DateTime changedSince, string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "")
            => await GetAsync<BaseListItemDTO[]>($"Lieferscheine/?status={status}&jahr={jahr}&changedSince={changedSince:o}&art={art}&includeArchive={includeArchive}&includeOthersData={includeOthersData}&search={search}");

        public async Task<VorgangDTO> GetAsyncVorgangByLieferscheinGuidAsync(Guid lieferscheinGuid)
            => await GetAsync<VorgangDTO>("Lieferscheine/" + lieferscheinGuid);

        public async Task<VorgangStatusDTO> GetAsyncStatusAsync(Guid vorgangGuid)
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
    }
}
