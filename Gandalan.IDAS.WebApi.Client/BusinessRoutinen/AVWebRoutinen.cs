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
        public AVWebRoutinen(WebApiSettings settings) : base(settings)
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
                return Get<BelegPositionAVDTO[]>($"BelegPositionenAV/?changedSince={changedSince.ToString("yyyy-MM-ddTHH:mm:ss")}");
            }
            return null;
        }

        public SerieDTO[] GetAllSerien()
        {
            if (Login())
            {
                return Get<SerieDTO[]>("Serie");
            }
            return null;
        }

        public SerieDTO[] GetAllSerien(DateTime changedSince)
        {
            if (Login())
            {
                return Get<SerieDTO[]>($"Serie/?changedSince={changedSince.ToString("yyyy-MM-ddTHH:mm:ss")}");
            }
            return null;
        }

        public List<BelegPositionAVDTO> GetBelegPositionenAV(Guid guid)
        {
            if (Login())
            {
                return Get<List<BelegPositionAVDTO>>("BelegPositionenAV/" + guid.ToString());
            }
            return null;
        }
               
        public SerieDTO GetSerie(Guid guid)
        {
            if (Login())
            {
                return Get<SerieDTO>("Serie/" + guid.ToString());
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

        public string SaveSerie(SerieDTO serie)
        {
            if (Login())
            {
                return Put<string>("Serie", serie);
            }
            return "Not logged in";
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

        public string DeleteSerie(Guid guid)
        {
            if (Login())
            {
                return Delete($"Serie/{guid}");
            }
            return "Not logged in";
        }


        public async Task<BelegPositionAVDTO[]> GetAllBelegPositionenAVAsync()
        {
            return await Task.Run(() => GetAllBelegPositionenAV());
        }

        public async Task<BelegPositionAVDTO[]> GetAllBelegPositionenAVAsync(DateTime changedSince)
        {
            return await Task.Run(() => GetAllBelegPositionenAV(changedSince));
        }

        public async Task<List<BelegPositionAVDTO>> GetBelegPositionenAVAsync(Guid guid)
        {
            return await Task.Run(() => GetBelegPositionenAV(guid));
        }

        public async Task<string> SaveBelegPositionenAVAsync(BelegPositionAVDTO position)
        {
            return await Task.Run(() => SaveBelegPositionenAV(position));
        }

        public async Task<List<BelegPositionAVDTO>> SaveBelegPositionenAVAsync(List<BelegPositionAVDTO> positionen)
        {
            return await Task.Run(() => SaveBelegPositionenAV(positionen));
        }

        public async Task<string> DeleteBelegPositionenAVAsync(Guid guid)
        {
            return await Task.Run(() => DeleteBelegPositionenAV(guid));
        }

        public async Task<string> DeleteBelegPositionenAVAsync(List<Guid> guids)
        {
            return await Task.Run(() => DeleteBelegPositionenAV(guids));
        }

        public async Task<SerieDTO[]> GetAllSerienAsync()
        {
            return await Task.Run(() => GetAllSerien());
        }

        public async Task<SerieDTO[]> GetAllSerienAsync(DateTime changedSince)
        {
            return await Task.Run(() => GetAllSerien(changedSince));
        }

        public async Task<SerieDTO> GetSerieAsync(Guid guid)
        {
            return await Task.Run(() => GetSerie(guid));
        }

        public async Task<string> SaveSerieAsync(SerieDTO serie)
        {
            return await Task.Run(() => SaveSerie(serie));
        }

        public async Task<string> DeleteSerieAsync(Guid guid)
        {
            return await Task.Run(() => DeleteSerie(guid));
        }
    }
}
