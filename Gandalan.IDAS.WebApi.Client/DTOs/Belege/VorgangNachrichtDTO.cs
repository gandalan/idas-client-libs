using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class VorgangNachrichtDTO
{
    public Guid VorgangNachrichtGuid { get; set; }
    public Guid VorgangGuid { get; set; }
    public string Absender { get; set; }
    public string Empfaenger { get; set; }
    public string Betreff { get; set; }
    public string Text { get; set; }
    public virtual IList<VorgangNachrichtAnhangDTO> Anhaenge { get; set; }
    public DateTime Gesendet { get; set; }

    public VorgangNachrichtDTO()
    {
        Anhaenge = [];
    }
}