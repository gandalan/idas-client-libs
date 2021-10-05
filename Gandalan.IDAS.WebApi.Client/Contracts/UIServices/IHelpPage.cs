using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices
{
    public interface IHelpPage
    {
        string Name { get; set; }
        string ContentURL { get; set; }
    }
}
