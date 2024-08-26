using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Nachrichten;
public class ArtikelNachrichtDTO
{
    public Guid MandantGuid { get; set; }
    public string ArtikelNummer { get; set; }
    public string VariantenName { get; set; }
    public string Nachricht { get; set; }
}
