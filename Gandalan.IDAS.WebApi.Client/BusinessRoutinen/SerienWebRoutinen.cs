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

        public async Task ReleaseElementeAsync(Guid fromSerie)
            => await GetAsync($"Serie/ReleaseElemente?fromSerie={fromSerie}");

        
        public async Task<string> MoveElementeAsync(Guid fromSerie, Guid toSerie)
            => await GetAsync<string>($"Serie/MoveElemente?fromSerie={fromSerie}&toSerie={toSerie}");

        public async Task<string> RedistributeElementeAsync(Guid fromSerie)
            => await GetAsync<string>($"Serie/RedistributeElemente?fromSerie={fromSerie}");

        public async Task<SerieDTO[]> GetAllSerienAsync() 
            => await GetAsync<SerieDTO[]>("Serie");

        public async Task<SerieDTO[]> GetAllSerienAsync(DateTime changedSince)
            => await GetAsync<SerieDTO[]>($"Serie/?changedSince={changedSince:o}");

        public async Task<SerieDTO> GetSerieAsync(Guid guid)
            => await GetAsync<SerieDTO>($"Serie/{guid}");

        public async Task SaveSerieAsync(SerieDTO serie) 
            => await PutAsync("Serie", serie);

        public async Task DeleteSerieAsync(Guid guid) 
            => await DeleteAsync($"Serie/{guid}");

        public async Task<IList<SerieAuslastungDTO>> GetAuslastungAsync(Guid serie) 
            => await GetAsync<IList<SerieAuslastungDTO>>($"Auslastung/{serie}");

        public async Task<IDictionary<Guid, IList<SerieAuslastungDTO>>> GetGesamtAuslastungAsync(bool includeAbgelaufene = false)
            => await GetAsync<IDictionary<Guid, IList<SerieAuslastungDTO>>>($"Auslastung/?includeAbgelaufene={includeAbgelaufene}");

        public async Task<IDictionary<Guid, IList<SerieAuslastungDTO>>> GetSerienKapazitaetenAsync(DateTime? startDate = null, 
            DateTime? endDate = null, bool includeStaendige = false) 
            => await GetAsync<IDictionary<Guid, IList<SerieAuslastungDTO>>>(
                    $"SerieKapazitaet/?startDate={startDate:o}&endDate={endDate:o}&includeStaendige={includeStaendige}");
    }
}