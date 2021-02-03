using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class VorgangListeWebRoutinen : WebRoutinenBase
    {
        public VorgangListeWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public VorgangListItemDTO[] LadeVorgangsListe(int jahr)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>("VorgangListe/?jahr=" + jahr);
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(string status, int jahr)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"VorgangListe/?status={status}&jahr={jahr}");
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(string status, int jahr, DateTime changedSince)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"VorgangListe/?status={status}&jahr={jahr}&changedSince={changedSince.ToString("yyyy-MM-ddTHH:mm:ss")}");
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(int jahr, string status, DateTime changedSince, string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "")
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"VorgangListe/?status={status}&jahr={jahr}&changedSince={changedSince.ToString("yyyy-MM-ddTHH:mm:ss")}&art={art}&includeArchive={includeArchive}&includeOthersData={includeOthersData}&search={search}");
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(Guid kundeGuid)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"VorgangListe/?kundeGuid={kundeGuid}");
            }
            return null;
        }



        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(int jahr)
        {
            return await Task<VorgangListItemDTO[]>.Run(() => { return LadeVorgangsListe(jahr); });
        }

        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(string status, int jahr)
        {
            return await Task<VorgangListItemDTO[]>.Run(() => { return LadeVorgangsListe(status, jahr); });
        }

        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(string status, int jahr, DateTime changedSince)
        {
            return await Task<VorgangListItemDTO[]>.Run(() => { return LadeVorgangsListe(status, jahr, changedSince); });
        }

        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(int jahr, string status, DateTime changedSince, string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "")
        {
            return await Task<VorgangListItemDTO[]>.Run(() => { return LadeVorgangsListe(jahr, status, changedSince, art, includeArchive, includeOthersData, search); });
        }

        public async Task<VorgangListItemDTO[]> LadeVorgangsListeAsync(Guid kundeGuid)
        {
            return await Task<VorgangListItemDTO[]>.Run(() => { return LadeVorgangsListe(kundeGuid); });
        }
    }
}
