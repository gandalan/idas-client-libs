using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.Data;
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

        public BelegPositionAVDTO[] GetVorgangBelegPositionenAV(Guid vorgangGuid, bool includeOriginalBeleg = true, bool includeProdDaten = true)
        {
            if (Login())
            {
                return Get<BelegPositionAVDTO[]>($"BelegPositionenAV/?vorgangGuid={vorgangGuid}&includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
            }
            return null;
        }

        public async Task<BelegPositionAVDTO[]> GetVorgangBelegPositionenAVAsync(Guid vorgangGuid, bool includeOriginalBeleg = true, bool includeProdDaten = true)
        {
            if (Login())
            {
                return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAV/?vorgangGuid={vorgangGuid}&includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
            }
            return null;
        }
                
        public List<BelegPositionAVDTO> GetBelegPositionenAV(Guid belegpositionGuid)
        {
            if (Login())
            {
                return Get<List<BelegPositionAVDTO>>($"BelegPositionenAV/{belegpositionGuid}");
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
                return Put<List<BelegPositionAVDTO>>($"BelegPositionenAVBulk/AddToSerie/{serieGuid}", positionen);
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


        public string BelegPositionenAVBerechnen(List<Guid> guids)
        {
            if (Login())
            {
                return Put<string>($"BelegPositionenAVBulk/AVBerechnung", guids);
            }
            return "Not logged in";
        }

        public async Task<BelegPositionAVDTO[]> GetAllBelegPositionenAVAsync(bool includeOriginalBeleg = true, bool includeProdDaten = true)
        {
            if (Login())
            {
                return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAV?includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
            }
            return null;
        }

        public async Task<BelegPositionAVDTO[]> GetAllBelegPositionenAVAsync(DateTime changedSince, bool includeOriginalBeleg = true, bool includeProdDaten = true)
        {
            if (Login())
            {
                return await GetAsync<BelegPositionAVDTO[]>($"BelegPositionenAV/?changedSince={changedSince.ToString("o")}&includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
            }
            return null;
        }

        public BelegPositionAVDTO GetBelegPositionAVById(Guid avGuid)
        {
            if (Login())
            {
                return Get<BelegPositionAVDTO>($"BelegPositionenAVById/{avGuid}");
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

        public IList<BelegPositionAVDTO> GetBelegPositionAVByPCode(string pcode, bool includeOriginalBeleg = true, bool includeProdDaten = true)
        {
            if (Login())
            {
                return Get<IList<BelegPositionAVDTO>>($"BelegPositionenAVByPCode/{pcode}?includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
            }
            return null;
        }

        public IList<BelegPositionAVDTO> SearchBelegPositionAVByPCode(string search)
        {
            if (Login())
            {
                return Get<IList<BelegPositionAVDTO>>($"BelegPositionenAVSearchByPCode?search={Uri.EscapeDataString(search)}");
            }
            return null;
        }

        public async Task<IList<BelegPositionAVDTO>> GetBelegPositionAVByPCodeAsync(string pcode, bool includeOriginalBeleg = true, bool includeProdDaten = true)
        {
            if (Login())
            {
                return await GetAsync<IList<BelegPositionAVDTO>>($"BelegPositionenAVByPCode/{pcode}?includeOriginalBeleg={includeOriginalBeleg}&includeProdDaten={includeProdDaten}");
            }
            return null;
        }

        public async Task<IList<BelegPositionAVDTO>> SearchBelegPositionAVByPCodeAsync(string search)
        {
            if (Login())
            {
                return await GetAsync<IList<BelegPositionAVDTO>>($"BelegPositionenAVSearchByPCode?search={Uri.EscapeDataString(search)}");
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

        public async Task<string> BelegPositionenAVBerechnenAsync(List<Guid> guids)
        {
            if (Login())
            {
                return await PutAsync<string>($"BelegPositionenAVBulk/AVBerechnung", guids);
            }
            return "Not logged in";
        }

        public async Task<string> BelegPositionenSerienZuordnen(Guid belegGuid, List<PositionSerieItemDTO> positionSerieItems)
        {
            if (Login())
            {
                return await PutAsync($"BelegPositionenAVBulk/SerienZuorden/{belegGuid}", positionSerieItems);
            }
            return "Not logged in";
        }
    }
}
