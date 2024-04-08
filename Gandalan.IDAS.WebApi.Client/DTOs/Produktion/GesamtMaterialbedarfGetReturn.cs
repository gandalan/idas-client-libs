using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class GesamtMaterialbedarfGetReturn
    {
        public List<GesamtMaterialbedarfDTO> Bedarfe = new();
        public List<GesamtMaterialbedarfDTO> Fehlliste = new();
        public List<GesamtLieferzusageDTO> Ueberliste = new();
        public List<GesamtLieferzusageDTO> Zusagen = new();
    }
}
