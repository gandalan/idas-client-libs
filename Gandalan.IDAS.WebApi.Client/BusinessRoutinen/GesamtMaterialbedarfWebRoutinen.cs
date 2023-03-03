using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.DTO.Gesamtbedarf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class GesamtMaterialbedarfWebRoutinen : WebRoutinenBase
    {
        public GesamtMaterialbedarfWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public GesamtMaterialbedarfGetReturn Get(DateTime? stichTag = null)
        {
            if (Login())
            {
                return Get<GesamtMaterialbedarfGetReturn>($"GesamtMaterialbedarf?stichTag={stichTag?.ToString("o")}");
            }

            return null;
        }

        public void Delete(Guid guid)
        {
            if (Login())
            {
                Delete($"GesamtMaterialbedarf/{guid}");
            }
        }

        public void Zusammenfassen(List<GesamtMaterialbedarfDTO> dtos, ZusammenfassungsOptionen optionen, bool stangenoptimierung)
        {
            if (Login())
            {
                Post($"GesamtMaterialbedarf/Zusammenfassen?optionen={optionen}&stangenoptimierung={stangenoptimierung}", dtos);
            }
        }

        public async Task<GesamtMaterialbedarfGetReturn> GetAsync(DateTime? stichTag = null) =>
            await Task.Run(() => Get(stichTag));
        public async Task DeleteAsync(Guid guid) => await Task.Run(() => Delete(guid));

        public async Task ZusammenfassenAsync(List<GesamtMaterialbedarfDTO> dtos, ZusammenfassungsOptionen optionen, bool stangenoptimierung) =>
            await Task.Run(() => Zusammenfassen(dtos, optionen, stangenoptimierung));

    }
}
