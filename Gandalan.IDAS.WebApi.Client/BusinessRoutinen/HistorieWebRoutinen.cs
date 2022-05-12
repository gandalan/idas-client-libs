using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class HistorieWebRoutinen : WebRoutinenBase
    {
        public HistorieWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public VorgangHistorienDTO GetVorgangHistorie(Guid vorgangGuid, bool includeBelege = false, bool includePositionen = false)
        {
            if (Login())
            {
                return Get<VorgangHistorienDTO>($"HistorieVorgang?vorgangGuid={vorgangGuid}&includeBelege={includeBelege}&includePositionen={includePositionen}");
            }
            return null;
        }
        public async Task<VorgangHistorienDTO> GetVorgangHistorieAsync(Guid vorgangGuid, bool includeBelege = false, bool includePositionen = false)
        {
            return await Task.Run(() => { return GetVorgangHistorie(vorgangGuid, includeBelege, includePositionen); });
        }

        public BelegHistorienDTO GetBelegHistorie(Guid belegGuid, bool includePositionen = false)
        {
            if (Login())
            {
                return Get<BelegHistorienDTO>($"HistorieBeleg?belegGuid={belegGuid}&includePositionen={includePositionen}");
            }
            return null;
        }
        public async Task<BelegHistorienDTO> GetBelegHistorieAsync(Guid belegGuid, bool includePositionen = false)
        {
            return await Task.Run(() => { return GetBelegHistorie(belegGuid, includePositionen); });
        }

        public BelegPositionHistorienDTO GetBelegPositionHistorie(Guid positionGuid)
        {
            if (Login())
            {
                return Get<BelegPositionHistorienDTO>($"HistorieBelegPosition?positionGuid={positionGuid}");
            }
            return null;
        }
        public async Task<BelegPositionHistorienDTO> GetBelegPositionHistorieAsync(Guid positionGuid)
        {
            return await Task.Run(() => { return GetBelegPositionHistorie(positionGuid); });
        }

        public void AddVorgangHistorie(Guid vorgangGuid, VorgangHistorieDTO historyDto)
        {
            if (Login())
            {
                Post($"HistorieVorgang?vorgangGuid={vorgangGuid}", historyDto);
            }
        }
        public async Task AddVorgangHistorieAsync(Guid vorgangGuid, VorgangHistorieDTO historyDto)
        {
            await Task.Run(() => AddVorgangHistorie(vorgangGuid, historyDto));
        }

        public void AddBelegHistorie(Guid belegGuid, BelegHistorieDTO historyDto)
        {
            if (Login())
            {
                Post($"HistorieBeleg?belegGuid={belegGuid}", historyDto);
            }
        }
        public async Task AddBelegHistorieAsync(Guid belegGuid, BelegHistorieDTO historyDto)
        {
            await Task.Run(() => AddBelegHistorie(belegGuid, historyDto));
        }

        public void AddBelegPositionHistorie(Guid positionGuid, BelegPositionHistorieDTO historyDto)
        {
            if (Login())
            {
                Post($"HistorieBelegPosition?positionGuid={positionGuid}", historyDto);
            }
        }
        public async Task AddBelegPositionHistorieAsync(Guid positionGuid, BelegPositionHistorieDTO historyDto)
        {
            await Task.Run(() => AddBelegPositionHistorie(positionGuid, historyDto));
        }
    }
}
