using Gandalan.Client.Common.Contracts.UIServices;
using Gandalan.Client.Common.UI;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IKundeDisplay
    {
        Task DisplayKunde(Guid kundeGuid);
    }

    public class KundeDisplayImplDefault : IKundeDisplay
    {
        private readonly IUserNotify _notify;

        public KundeDisplayImplDefault(IUserNotify notify)
        {
            this._notify = notify;
        }

        public async Task DisplayKunde(Guid kundeGuid)
        {
            _notify.ShowMessage("Kunde kann nicht angezeigt werden.", UserNotifyMessageType.Error);            
        }
    }
}
