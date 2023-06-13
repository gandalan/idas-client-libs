using System;

namespace Gandalan.IDAS.Jobs.Contracts
{
    public interface IBelegPrintJob : IBackgroundJob<IBelegPrintJobData>
    {

    }

    public interface IBelegPrintJobData : IJobData
    {
        Guid BelegGuid { get; set; }
        Guid VorgangGuid { get; set; }
        string FileFormat { get; set; }
        byte[] Result { get; set; }
        bool SavePDF { get; set; }
        string DefaultPrinter { get; set; }
        int Copies { get; set; }
    }

}
