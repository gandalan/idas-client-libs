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

        public VorgangListItemDTO[] LadeVorgangsListe(int jahr, bool includeASP = false)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"VorgangListe/?jahr={jahr}&includeASP={includeASP}");
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(string status, int jahr, bool includeASP = false)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"VorgangListe/?status={status}&jahr={jahr}&includeASP={includeASP}");
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(string status, int jahr, DateTime changedSince, bool includeASP = false)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"VorgangListe/?status={status}&jahr={jahr}&changedSince={changedSince.ToString("o")}&includeASP={includeASP}");
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(int jahr, string status, DateTime changedSince, string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "", bool includeASP = false)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"VorgangListe/?status={status}&jahr={jahr}&changedSince={changedSince.ToString("o")}&art={art}&includeArchive={includeArchive}&includeOthersData={includeOthersData}&search={search}&includeASP={includeASP}");
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
