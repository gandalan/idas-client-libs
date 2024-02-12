using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class GesamtLieferzusagenWebRoutinen : WebRoutinenBase
    {
        public GesamtLieferzusagenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<List<GesamtLieferzusageDTO>> GetAsync(DateTime? stichTag = null)
            => await GetAsync<List<GesamtLieferzusageDTO>>($"GesamtLieferzusagen?stichTag={stichTag?.ToString("o")}");

        public async Task PutAsync(GesamtLieferzusageDTO dto)
            => await PutAsync("GesamtLieferzusagen", dto);

        public async Task SerieBuchenAsync(Guid serieGuid)
            => await PostAsync($"GesamtLieferzusagen/SerieBuchen?serieGuid={serieGuid}", null);
    }
}
