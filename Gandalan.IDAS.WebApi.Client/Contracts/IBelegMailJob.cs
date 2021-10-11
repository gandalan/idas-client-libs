using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Jobs.Contracts
{
    public interface IBelegMailJob : IBackgroundJob<IBelegMailJobData>
    {

    }

    public interface IBelegMailJobData : IJobData
    {
        Guid BelegGuid { get; set; }
        string FileFormat { get; set; }
        byte[] Result { get; set; }
        bool SavePDF { get; set; }
        string DefaultPrinter { get; set; }
        string KundeEmail { get; set; }
    }

}
