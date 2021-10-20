using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AVWebRoutinen : WebRoutinenBase
    {
        public AVWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public BelegPositionAVDTO[] GetAllBelegPositionenAV()
        {
            if (Login())
            {
                return Get<BelegPositionAVDTO[]>("BelegPositionenAV");
            }
            return null;
        }

        public BelegPositionAVDTO[] GetAllBelegPositionenAV(DateTime changedSince)
        {
            if (Login())
            {
                return Get<BelegPositionAVDTO[]>($"BelegPositionenAV/?changedSince={changedSince.ToString("o")}");
            }
            return null;
        }

        public BelegPositionAVDTO[] GetSerieBelegPositionenAV(Guid serieGuid, bool includeOriginalBeleg = true, bool includeProdDaten = true)
        {
            if (Login())
            {
                return Get<BelegPositionAVDTO[]>($"BelegPositionenAV/?serieGuid={serieGuid}&includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
            }
            return null;
        }

        public async Task<BelegPositionAVDTO[]> GetSerieBelegPositionenAVAsync(Guid serieGuid, bool includeOriginalBeleg = true, bool includeProdDaten = true)
        {
            if (Login())
            {
                return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAV/?serieGuid={serieGuid}&includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
            }
            return null;
        }

        public BelegPositionAVDTO GetBelegPositionAVById(Guid avGuid)
        {
            if (Login())
            {
                return Get<BelegPositionAVDTO>($"BelegPositionenAVById/{avGuid.ToString()}");
            }
            return null;
        }

        public List<BelegPositionAVDTO> GetBelegPositionenAV(Guid belegpositionGuid)
        {
            if (Login())
            {
                return Get<List<BelegPositionAVDTO>>("BelegPositionenAV/" + belegpositionGuid.ToString());
            }
            return null;
        }
               
        public string SaveBelegPositionenAV(BelegPositionAVDTO position)
        {
            if (Login())
            {
                return Put<string>("BelegPositionenAV", position);
            }
            return "Not logged in";
        }

        public List<BelegPositionAVDTO> SaveBelegPositionenAV(List<BelegPositionAVDTO> positionen)
        {
            if (Login())
            {
                return Put<List<BelegPositionAVDTO>>("BelegPositionenAVBulk", positionen);
            }
            return null;
        }

        public List<BelegPositionAVDTO> SaveBelegPositionenAVToSerie(Guid serieGuid, List<Guid> positionen)
        {
            if (Login())
            {
                return Put<List<BelegPositionAVDTO>>("BelegPositionenAVBulk/AddToSerie/" + serieGuid.ToString(), positionen);
            }
            return null;
        }

        public string DeleteBelegPositionenAV(Guid guid)
        {
            if (Login())
            {
                return Delete($"BelegPositionenAV/{guid}");
            }
            return "Not logged in";
        }

        public string DeleteBelegPositionenAV(List<Guid> guids)
        {
            if (Login())
            {
                return Delete<string>($"BelegPositionenAVBulk", guids);
            }
            return "Not logged in";
        }

        public async Task<BelegPositionAVDTO[]> GetAllBelegPositionenAVAsync()
        {
            if (Login())
            {
                return await GetAsync<BelegPositionAVDTO[]>("BelegPositionenAV");
            }
            return null;
        }

        public async Task<BelegPositionAVDTO[]> GetAllBelegPositionenAVAsync(DateTime changedSince)
        {
            if (Login())
            {
                return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAV/?changedSince={changedSince.ToString("o")}");
            }
            return null;
        }

        public async Task<BelegPositionAVDTO> GetBelegPositionAVByIdAsync(Guid avGuid)
        {
            if (Login())
            {
                return await GetAsync<BelegPositionAVDTO>($"BelegPositionenAVById/{avGuid.ToString()}");
            }
            return null;
        }

        public async Task<List<BelegPositionAVDTO>> GetBelegPositionenAVAsync(Guid guid)
        {
            if (Login())
            {
                return await GetAsync<List<BelegPositionAVDTO>>("BelegPositionenAV/" + guid.ToString());
            }
            return null;
        }

        public async Task<string> SaveBelegPositionenAVAsync(BelegPositionAVDTO position)
        {
            if (Login())
            {
                return await PutAsync<string>("BelegPositionenAV", position);
            }
            return "Not logged in";
        }

        public async Task<List<BelegPositionAVDTO>> SaveBelegPositionenAVAsync(List<BelegPositionAVDTO> positionen)
        {
            if (Login())
            {
                return await PutAsync<List<BelegPositionAVDTO>>("BelegPositionenAVBulk", positionen);
            }
            return null;
        }

        public async Task<string> DeleteBelegPositionenAVAsync(Guid guid)
        {
            if (Login())
            {
                return await DeleteAsync($"BelegPositionenAV/{guid}");
            }
            return "Not logged in";
        }

        public async Task<string> DeleteBelegPositionenAVAsync(List<Guid> guids)
        {
            if (Login())
            {
                return await DeleteAsync<string>($"BelegPositionenAVBulk", guids);
            }
            return "Not logged in";
        }
    }
}
