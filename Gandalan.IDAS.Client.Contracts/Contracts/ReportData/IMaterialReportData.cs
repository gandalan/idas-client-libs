using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.Client.Contracts.Contracts.ReportData
{
    public interface IMaterialReportData
    {
        string OrderedProperty { get; set; }
        string OrderedPropertyValue { get; set; }
        List<IMaterialReportDataItem> Data { get; set; }
        string Serienname { get; set; }
        DateTime DruckDatum { get; set; }
    }
}
