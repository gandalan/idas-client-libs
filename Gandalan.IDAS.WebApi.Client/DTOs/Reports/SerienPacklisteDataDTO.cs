using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Reports;

public class SerienPacklisteDataDTO
{
    public string Titel { get; set; }
    public string Serienkennzeichen { get; set; }
    public List<SerienPacklisteGruppeDataDTO> VorgangsGruppen { get; set; } = [];
}