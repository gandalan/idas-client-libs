using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class KonfigSatzEintragDTO
{
    public string DatenTyp { get; set; }
    public string KonfigName { get; set; }
    public Guid KonfigSatzEintragGuid { get; set; }
    public string UnterkomponenteName { get; set; }
    public string Wert { get; set; }
    public DateTime ChangedDate { get; set; }
}