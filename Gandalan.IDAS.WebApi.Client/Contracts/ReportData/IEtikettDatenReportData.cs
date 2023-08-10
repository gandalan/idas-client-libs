using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.Contracts.ReportData
{
    public interface IEtikettDatenReportData
    {
        Guid EtikettDatenGuid { get; set; }
        string Position { get; set; }
        string Typ { get; set; }
        string Inhalt { get; set; }
    }
}
