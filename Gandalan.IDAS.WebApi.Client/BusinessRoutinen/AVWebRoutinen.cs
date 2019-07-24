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

        public SerieDTO[] GetAllSerien()
        {
            if (Login())
            {
                return Get<SerieDTO[]>("Serie");
            }
            return null;
        }

        public BelegPositionAVDTO GetBelegPositionenAV(Guid guid)
        {
            if (Login())
            {
                return Get<BelegPositionAVDTO>("BelegPositionenAV/" + guid.ToString());
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

        public async Task<BelegPositionAVDTO> GetBelegPositionenAVAsync(Guid guid)
        {
            return await Task.Run(() => GetBelegPositionenAV(guid));
        }

        public async Task<string> SaveBelegPositionenAVAsync(BelegPositionAVDTO position)
        {
            return await Task.Run(() => SaveBelegPositionenAV(position));
        }

        public async Task<string> DeleteBelegPositionenAVAsync(Guid guid)
        {
            return await Task.Run(() => DeleteBelegPositionenAV(guid));
        }
                       
        public async Task<SerieDTO[]> GetAllSerienAsync()
        {
            return await Task.Run(() => GetAllSerien());
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
