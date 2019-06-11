using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.Client.Common.Contracts.UIServices;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IVorgangEditor
    {
        Task EditVorgang(Guid VorgangGuid);
        Task AddVorgang();
        Task AddVorgang(Guid KundeGuid);
    }
}
