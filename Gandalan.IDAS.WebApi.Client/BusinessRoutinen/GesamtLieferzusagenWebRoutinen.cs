using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class GesamtLieferzusagenWebRoutinen : WebRoutinenBase
    {
        public GesamtLieferzusagenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public List<GesamtLieferzusageDTO> Get(DateTime? stichTag = null)
        {
            if (Login())
            {
                return Get<List<GesamtLieferzusageDTO>>($"GesamtLieferzusagen?stichTag={stichTag?.ToString("o")}");
            }

            return null;
        }

        public async Task<List<GesamtLieferzusageDTO>> GetAsync(DateTime? stichTag = null) => await Task.Run(() => Get(stichTag));

    }
}
