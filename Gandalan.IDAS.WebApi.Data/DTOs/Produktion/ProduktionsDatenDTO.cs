using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ProduktionsDatenDTO
    {
        public Guid ProduktionsDatenGuid { get; set; }
        public List<MaterialbedarfDTO> Material { get; set; } = new List<MaterialbedarfDTO>();
        public List<EtikettDTO> Etiketten { get; set; } = new List<EtikettDTO>();
        public List<BearbeitungDTO> Bearbeitungen { get; set; } = new List<BearbeitungDTO>();
        public PositionsDatenDTO PositionsDaten { get; set; }

        public List<MaterialbedarfDTO> GetMaterialbedarf()
        {
            return Material == null ? new List<MaterialbedarfDTO>() : Material.Where(m => m.IstZuschnitt == false).ToList();
        }

        public List<MaterialbedarfDTO> GetSaegeliste()
        {
            return Material == null ? new List<MaterialbedarfDTO>() : Material.Where(m => m.IstZuschnitt == true).ToList();
        }
    }
}
