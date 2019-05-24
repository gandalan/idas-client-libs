using Gandalan.Client.Common.Contracts.UIServices;
using Gandalan.Client.Common.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IVorgangListeDisplay
    {
        Task DisplayVorgaenge();
        Task DisplayVorgaengeByKunde(Guid kundeGuid);
    }

    public class VorgangListeDisplayImplDefault : IVorgangListeDisplay
    {
        private readonly IUserNotify _notify;

        public VorgangListeDisplayImplDefault(IUserNotify notify)
        {
            this._notify = notify;
        }

        public async Task DisplayVorgaenge()
        {
            _notify.ShowMessage("Vorgänge können nicht angezeigt werden.", UserNotifyMessageType.Error);
        }

        public async Task DisplayVorgaengeByKunde(Guid kundeGuid)
        {
            _notify.ShowMessage("Vorgänge können nicht angezeigt werden.", UserNotifyMessageType.Warning);
        }
    }
}
