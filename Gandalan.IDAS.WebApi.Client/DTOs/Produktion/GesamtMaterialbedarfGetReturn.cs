using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class GesamtMaterialbedarfGetReturn
{
    public List<GesamtMaterialbedarfDTO> Bedarfe = [];
    public List<GesamtMaterialbedarfDTO> Fehlliste = [];
    public List<GesamtLieferzusageDTO> Ueberliste = [];
    public List<GesamtLieferzusageDTO> Zusagen = [];
}