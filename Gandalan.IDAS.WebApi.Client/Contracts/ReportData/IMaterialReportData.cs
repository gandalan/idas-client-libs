using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.Client.Contracts.Contracts.ReportData
{
    public interface IMaterialReportData
    {
        string OrderedProperty { get; set; }
        string OrderedPropertyValue { get; set; }
        List<IMaterialReportGroupData> Data { get; set; }
        string Serienname { get; set; }
        DateTime DruckDatum { get; set; }
    }

    public class MaterialReportData : IMaterialReportData
    {
        public string OrderedProperty { get; set; }
        public string OrderedPropertyValue { get; set; }
        public List<IMaterialReportGroupData> Data { get; set; } = [];
        public string Serienname { get; set; }
        public DateTime DruckDatum { get; set; }
    }
}
