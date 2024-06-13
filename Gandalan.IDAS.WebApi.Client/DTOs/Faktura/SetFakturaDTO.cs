using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Faktura;

public class SetFakturaDTO
{
    public IList<Guid> GuidList { get; set; }

    /// <summary>
    /// erlaubte Werte: Freigegeben, Abgerechnet
    /// </summary>
    public string Kennzeichen { get; set; }
}