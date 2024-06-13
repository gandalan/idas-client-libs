using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class UIEingabeFeldInfoDTO
{
    public Guid UIEingabeFeldGuid { get; set; }
    public Guid[] VariantenGuids { get; set; }
    public string Caption { get; set; }
    public double MinWert { get; set; }
    public bool MinWertWeichPruefen { get; set; }
    public double MaxWert { get; set; }
    public bool MaxWertWeichPruefen { get; set; }
    public string HilfeText { get; set; }
    public string WarnText { get; set; }
    public string FehlerText { get; set; }
    public string VorgabeWert { get; set; }
}