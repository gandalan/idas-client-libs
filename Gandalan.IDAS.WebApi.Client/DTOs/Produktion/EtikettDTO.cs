using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class EtikettDTO
{
    public Guid EtikettGuid { get; set; }
    public string Kuerzel { get; set; }
    public string Text { get; set; }
    public Guid ZielKennzeichen { get; set; }
    public bool IstSonderEtikett { get; set; }

    // Zusatzetiketten sind manuell angelegte Etiketten, welche über die AppSpecificProperties gepflegt wurden und sich nun in den
    // AdditionalProperties befinden. Sie wurden u.A. bei den BelegPositionen verwendet.
    // Diese werden jetzt in der Etikettenliste der Produktionsdaten der AVBelegPositionen mitgeführt, haben aber nichts mit den Etiketten, welche als
    // Sonderetiketten (Etikettendruckkennzeichen 'S') markiert werden, zu tun.
    public bool IstZusatzEtikett { get; set; }

    public string Typ { get; set; } = "Produktionsetikett";
    public IList<EtikettDatenDTO> EtikettDaten { get; set; } = [];
    public bool EtikettenProfilVorbiegen { get; set; }
    public string EtikettenSonderKuerzel { get; set; }
}
