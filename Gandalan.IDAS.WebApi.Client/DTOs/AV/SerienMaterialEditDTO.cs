using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Data.DTOs.AV
{
    public class SerienMaterialEditDTO
    {
        public Guid SerieGuid { get; set; }

        public List<MaterialbedarfDTO> MaterialListe { get; set; } = new List<MaterialbedarfDTO>();
    }
}
