using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class KonfigSatzDTO
{
    public DateTime ChangedDate { get; set; }
    public List<KonfigSatzEintragDTO> Eintraege { get; set; } = [];
    public Guid KonfigSatzGuid { get; set; }
    public long Version { get; set; }
}