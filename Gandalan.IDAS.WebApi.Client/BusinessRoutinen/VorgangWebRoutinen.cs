using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class VorgangWebRoutinen : WebRoutinenBase
    {
        public VorgangWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public VorgangListItemDTO[] LadeVorgangsListe(int jahr)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>("Vorgang/?jahr=" + jahr);
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(string status, int jahr)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"Vorgang/?status={status}&jahr={jahr}");
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(string status, int jahr, DateTime changedSince)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"Vorgang/?status={status}&jahr={jahr}&changedSince={changedSince.ToString("yyyy-MM-ddTHH:mm:ss")}");
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(int jahr, string status, DateTime changedSince, string art = "", bool includeArchive = false, bool includeOthersData = false, string search = "")
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"Vorgang/?status={status}&jahr={jahr}&changedSince={changedSince.ToString("yyyy-MM-ddTHH:mm:ss")}&art={art}&includeArchive={includeArchive}&includeOthersData={includeOthersData}&search={search}");
            }
            return null;
        }

        public VorgangListItemDTO[] LadeVorgangsListe(Guid kundeGuid)
        {
            if (Login())
            {
                return Get<VorgangListItemDTO[]>($"Vorgang/?kundeGuid={kundeGuid}");
            }
            return null;
        }

        public void SendeVorgaenge(VorgangDTO[] list)
        {
            foreach (VorgangDTO v in list)
                SendeVorgang(v);
        }

        public VorgangDTO SendeVorgang(VorgangDTO vorgang)
        {
            if (Login())
            {
                return Put<VorgangDTO>("Vorgang", vorgang);
            }
            return null;
        }

        public VorgangDTO LadeVorgang(Guid vorgangGuid, bool mitKunde)
        {
            if (Login())
            {
                return Get<VorgangDTO>("Vorgang/" + vorgangGuid.ToString() + "?includeKunde=" + mitKunde.ToString());
            }
            return null;
        }

        public VorgangDTO LadeVorgang(long vorgangsNummer, int jahr, string status, bool mitKunde = false)
        {
            if (Login())
            {
                return Get<VorgangDTO>($"Vorgang/{vorgangsNummer}?jahr={jahr}?status={status}?includeKunde={mitKunde}");
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

        public void SetTextStatus(List<Guid> vorgangGuids, string textStatus)
        {
            if (Login())
            {
                VorgangTextStatusDTO set = new VorgangTextStatusDTO()
                {
                    VorgangGuids = vorgangGuids,
                    NeuerTextStatus = textStatus
                };
                Post("VorgangTextStatus", set);
            }
        }

        public void ArchiviereVorgang(Guid vorgangGuid)
        {
            if (Login())
            {
                Post("Archivierung/?vguid=" + vorgangGuid.ToString(), null);
            }
        }

        public void ArchiviereVorgangList(List<Guid> vorgangGuidList)
        {
            if (Login())
            {
                Post("Archivierung/", vorgangGuidList);
            }
        }

        public void AendereBelegArt(Guid belegGuid, string neueBelegArt)
        {
            if (Login())
            {
                Post("BelegArt/?bguid=" + belegGuid.ToString() + "&neueBelegArt=" + neueBelegArt, null);
            }
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

        public async void SendeVorgaengeAsync(VorgangDTO[] list)
        {
            foreach (VorgangDTO v in list)
                await SendeVorgangAsync(v);
        }

        public async Task<VorgangDTO> SendeVorgangAsync(VorgangDTO vorgang)
        {
            return await Task<VorgangDTO>.Run(() => { return SendeVorgang(vorgang); });
        }

        public async Task<VorgangDTO> LadeVorgangAsync(Guid vorgangGuid, bool mitKunde)
        {
            return await Task<VorgangDTO>.Run(() => { return LadeVorgang(vorgangGuid, mitKunde); });
        }

        public async Task AendereBelegArtAsync(Guid belegGuid, string neueBelegArt)
        {
            await Task.Run(() => { AendereBelegArt(belegGuid, neueBelegArt); });
        }

        public async Task ArchiviereVorgangAsync(Guid vorgangGuid)
        {
            await Task.Run(() => { ArchiviereVorgang(vorgangGuid); });
        }

        public async Task ArchiviereVorgangListAsync(List<Guid> vorgangGuidList)
        {
            await Task.Run(() => { ArchiviereVorgangList(vorgangGuidList); });
        }

        public async Task<VorgangStatusDTO> GetStatusAsync(Guid vorgangGuid)
        {
            return await Task<VorgangStatusDTO>.Run(() => { return GetStatus(vorgangGuid); });
        }

        public async Task<VorgangStatusDTO> SetStatusAsync(Guid vorgangGuid, string statusCode)
        {
            return await Task<VorgangStatusDTO>.Run(() => { return SetStatus(vorgangGuid, statusCode); });
        }

        public async Task SetTextStatusAsync(List<Guid> vorgangGuids, string textStatus)
        {
            await Task.Run(() => { SetTextStatus(vorgangGuids, textStatus); });
        }
    }
}
