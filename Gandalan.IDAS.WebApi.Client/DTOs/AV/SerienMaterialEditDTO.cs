using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Data.DTOs.AV
{
    public class SerienMaterialEditDTO
    {
        public Guid SerieGuid { get; set; }

        public List<MaterialbedarfDTO> MaterialListe { get; set; } = new();
    }
}
