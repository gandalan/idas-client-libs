using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class LieferscheineWebRoutinen : WebRoutinenBase
    {
        public LieferscheineWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public BaseListItemDTO[] LadeListe(int jahr)
        {
            if (Login())
            {
                return Get<BaseListItemDTO[]>("Lieferscheine/?jahr=" + jahr);
            }
            return null;
        }

        public BaseListItemDTO[] LadeListe(string status, int jahr)
        {
            if (Login())
            {
                return Get<BaseListItemDTO[]>($"Lieferscheine/?status={status}&jahr={jahr}");
            }
            return null;
        }

        public BaseListItemDTO[] LadeListe(string status, int jahr, DateTime changedSince)
        {
            if (Login())
            {
                return Get<BaseListItemDTO[]>($"Lieferscheine/?status={status}&jahr={jahr}&changedSince={changedSince.ToString("yyyy-MM-ddTHH:mm:ss")}");
            }
            return null;
        }
        
        public BaseListItemDTO[] LadeListe(int jahr, string status, DateTime changedSince, string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "")
        {
            if (Login())
            {
                return Get<BaseListItemDTO[]>($"Lieferscheine/?status={status}&jahr={jahr}&changedSince={changedSince.ToString("yyyy-MM-ddTHH:mm:ss")}&art={art}&includeArchive={includeArchive}&includeOthersData={includeOthersData}&search={search}");
            }
            return null;
        }

        public VorgangDTO GetVorgangByLieferscheinGuid(Guid lieferscheinGuid)
        {
            if (Login())
            {
                return Get<VorgangDTO>("Lieferscheine/" + lieferscheinGuid.ToString());
            }
            return null;
        }

        public VorgangStatusDTO GetStatus(Guid vorgangGuid)
        {
            if (Login())
            {
                return Get<VorgangStatusDTO>("VorgangStatus/" + vorgangGuid.ToString());
            }
            return null;
        }
                
        public VorgangStatusDTO SetStatus(Guid vorgangGuid, string statusCode)
        {
            if (Login())
            {
                VorgangStatusDTO set = new VorgangStatusDTO()
                {
                    VorgangGuid = vorgangGuid,
                    NeuerStatus = statusCode
                };
                return Put<VorgangStatusDTO>("VorgangStatus", set);
            }
            return null;
        }

        public async Task<BaseListItemDTO[]> LadeListeAsync(int jahr)
        {
            return await Task<BaseListItemDTO[]>.Run(() => { return LadeListe(jahr); });
        }

        public async Task<BaseListItemDTO[]> LadeListeAsync(string status, int jahr)
        {
            return await Task<BaseListItemDTO[]>.Run(() => { return LadeListe(status, jahr); });
        }

        public async Task<BaseListItemDTO[]> LadeListeAsync(string status, int jahr, DateTime changedSince)
        {
            return await Task<BaseListItemDTO[]>.Run(() => { return LadeListe(status, jahr, changedSince); });
        }

        public async Task<BaseListItemDTO[]> LadeListeAsync(int jahr, string status, DateTime changedSince, string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "")
        {
            return await Task<BaseListItemDTO[]>.Run(() => { return LadeListe(jahr, status, changedSince, art, includeArchive, includeOthersData, search);});
        }

        public async Task<VorgangDTO> GetVorgangByLieferscheinGuidAsync(Guid vorgangGuid)
        {
            return await Task<VorgangDTO>.Run(() => { return GetVorgangByLieferscheinGuid(vorgangGuid); });
        }

        public async Task<VorgangStatusDTO> GetStatusAsync(Guid vorgangGuid)
        {
            return await Task<VorgangStatusDTO>.Run(() => { return GetStatus(vorgangGuid); });
        }

        public async Task<VorgangStatusDTO> SetStatusAsync(Guid vorgangGuid, string statusCode)
        {
            return await Task<VorgangStatusDTO>.Run(() => { return SetStatus(vorgangGuid, statusCode); });
        }
    }
}
