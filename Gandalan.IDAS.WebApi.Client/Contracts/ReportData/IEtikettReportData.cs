using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.Contracts.ReportData;

public interface IEtikettReportData
{
    Guid EtikettGuid { get; set; }
    string Kuerzel { get; set; }
    string Text { get; set; }
    Guid ZielKennzeichen { get; set; }
    bool IstSonderEtikett { get; set; }
    string Typ { get; set; }
    List<IEtikettDatenReportData> EtikettDaten { get; set; }
    bool EtikettenProfilVorbiegen { get; set; }
    string EtikettenSonderKuerzel { get; set; }
}