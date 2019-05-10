using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Jobs.Contracts
{
    public interface IBelegPrintJob : IBackgroundJob<IBelegPrintJobData>
    {

    }

    public interface IBelegPrintJobData : IJobData
    {
        Guid BelegGuid { get; set; }
        string FileFormat { get; set; }
        byte[] Result { get; set; }
    }

}
