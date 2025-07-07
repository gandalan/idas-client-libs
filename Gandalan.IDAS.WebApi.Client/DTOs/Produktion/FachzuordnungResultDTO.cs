using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Produktion;

public class FachzuordnungResultDTO
{
    public List<string> ProduktfamilienOverCapacity { get; set; } = [];
    public bool OverCapacity => ProduktfamilienOverCapacity.Count > 0;
}
