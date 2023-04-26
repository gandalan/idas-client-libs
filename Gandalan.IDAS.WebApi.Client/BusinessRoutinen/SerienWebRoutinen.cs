using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class SerienWebRoutinen : WebRoutinenBase
    {
        public SerienWebRoutinen(IWebApiConfig settings) : base(settings)
        {
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
                return Get<SerieDTO[]>($"Serie/?changedSince={changedSince.ToString("o")}");
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

        public string SaveSerie(SerieDTO serie)
        {
            if (Login())
            {
                return Put<string>("Serie", serie);
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

        public string ReleaseElemente(Guid fromSerie)
        {
            if (Login())
            {
                return Get<string>($"Serie/ReleaseElemente?fromSerie={fromSerie}");
            }

            return null;
        }

        public async Task<string> ReleaseElementeAsync(Guid fromSerie)
        {
            if (Login())
            {
                return await GetAsync<string>($"Serie/ReleaseElemente?fromSerie={fromSerie}");
            }

            return null;
        }

        public string MoveElemente(Guid fromSerie, Guid toSerie)
        {
            if (Login())
            {
                return Get<string>($"Serie/MoveElemente?fromSerie={fromSerie}&toSerie={toSerie}");
            }

            return null;
        }

        public async Task<string> MoveElementeAsync(Guid fromSerie, Guid toSerie)
        {
            if (Login())
            {
                return await GetAsync<string>($"Serie/MoveElemente?fromSerie={fromSerie}&toSerie={toSerie}");
            }

            return null;
        }

        public string RedistributeElemente(Guid fromSerie)
        {
            if (Login())
            {
                return Get<string>($"Serie/RedistributeElemente?fromSerie={fromSerie}");
            }

            return null;
        }

        public async Task<string> RedistributeElementeAsync(Guid fromSerie)
        {
            if (Login())
            {
                return await GetAsync<string>($"Serie/RedistributeElemente?fromSerie={fromSerie}");
            }

            return null;
        }

        public async Task<SerieDTO[]> GetAllSerienAsync()
        {
            if (Login())
            {
                return await GetAsync<SerieDTO[]>("Serie");
            }

            return null;
        }

        public async Task<SerieDTO[]> GetAllSerienAsync(DateTime changedSince)
        {
            if (Login())
            {
                return await GetAsync<SerieDTO[]>($"Serie/?changedSince={changedSince.ToString("o")}");
            }

            return null;
        }

        public async Task<SerieDTO> GetSerieAsync(Guid guid)
        {
            if (Login())
            {
                return await GetAsync<SerieDTO>("Serie/" + guid.ToString());
            }

            return null;
        }

        public async Task<string> SaveSerieAsync(SerieDTO serie)
        {
            if (Login())
            {
                return await PutAsync<string>("Serie", serie);
            }

            return "Not logged in";
        }

        public async Task<string> DeleteSerieAsync(Guid guid)
        {
            if (Login())
            {
                return await DeleteAsync($"Serie/{guid}");
            }

            return "Not logged in";
        }

        public IList<SerieAuslastungDTO> GetAuslastung(Guid serie)
        {
            if (Login())
            {
                return Get<IList<SerieAuslastungDTO>>($"Auslastung/{serie}");
            }

            return null;
        }

        public async Task<IList<SerieAuslastungDTO>> GetAuslastungAsync(Guid serie)
        {
            if (Login())
            {
                return await GetAsync<IList<SerieAuslastungDTO>>($"Auslastung/{serie}");
            }

            return null;
        }

        public IDictionary<Guid, IList<SerieAuslastungDTO>> GetGesamtAuslastung(bool includeAbgelaufene = false)
        {
            if (Login())
            {
                return Get<IDictionary<Guid, IList<SerieAuslastungDTO>>>(
                    $"Auslastung/?includeAbgelaufene={includeAbgelaufene}");
            }

            return null;
        }

        public async Task<IDictionary<Guid, IList<SerieAuslastungDTO>>> GetGesamtAuslastungAsync(
            bool includeAbgelaufene = false)
        {
            if (Login())
            {
                return await GetAsync<IDictionary<Guid, IList<SerieAuslastungDTO>>>(
                    $"Auslastung/?includeAbgelaufene={includeAbgelaufene}");
            }

            return null;
        }

        public IDictionary<Guid, IList<SerieAuslastungDTO>> GetSerienKapazitaeten(
            DateTime? startDate = null, DateTime? endDate = null, bool includeStaendige = false)
        {
            if (Login())
            {
                return Get<IDictionary<Guid, IList<SerieAuslastungDTO>>>(
                    $"SerieKapazitaet/?startDate={startDate}&endDate={endDate}&includeStaendige={includeStaendige}");
            }

            return null;
        }
        
        public async Task<IDictionary<Guid, IList<SerieAuslastungDTO>>> GetSerienKapazitaetenAsync(
            DateTime? startDate = null, DateTime? endDate = null, bool includeStaendige = false)
        {
            if (await LoginAsync())
            {
                return await GetAsync<IDictionary<Guid, IList<SerieAuslastungDTO>>>(
                    $"SerieKapazitaet/?startDate={startDate:o}&endDate={endDate:o}&includeStaendige={includeStaendige}");
            }

            return null;
        }
    }
}