using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class GesamtMaterialbedarfGetReturn
    {
        public List<GesamtMaterialbedarfDTO> Bedarfe = new List<GesamtMaterialbedarfDTO>();
        public List<GesamtMaterialbedarfDTO> Fehlliste = new List<GesamtMaterialbedarfDTO>();
        public List<GesamtLieferzusageDTO> Ueberliste = new List<GesamtLieferzusageDTO>();
        public List<GesamtLieferzusageDTO> Zusagen = new List<GesamtLieferzusageDTO>();
    }
}