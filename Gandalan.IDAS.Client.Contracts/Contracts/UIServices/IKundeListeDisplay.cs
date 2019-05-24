using Gandalan.Client.Common.Contracts.UIServices;
using Gandalan.Client.Common.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IKundeListeDisplay
    {
        Task DisplayKunden();
    }

    public class KundeListeDisplayImplDefault : IKundeListeDisplay
    {
        private readonly IUserNotify _notify;

        public KundeListeDisplayImplDefault(IUserNotify notify)
        {
            this._notify = notify;
        }

        public async Task DisplayKunden()
        {
            _notify.ShowMessage("Kunden können nicht angezeigt werden.", UserNotifyMessageType.Error);
        }
    }
}
