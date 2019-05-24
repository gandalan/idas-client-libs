using Gandalan.Client.Common.Contracts.UIServices;
using Gandalan.Client.Common.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IVorgangDisplay
    {
        Task DisplayVorgang(Guid vorgangGuid);
    }

    public class VorgangDisplayImplDefault : IVorgangDisplay
    {
        private readonly IUserNotify _notify;

        public VorgangDisplayImplDefault(IUserNotify notify)
        {
            this._notify = notify;
        }

        public async Task DisplayVorgang(Guid vorgangGuid)
        {
            _notify.ShowMessage("Vorgänge können nicht angezeigt werden.", UserNotifyMessageType.Error);
        }
    }
}
