using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IUebersichtDisplay
    {
        void DisplayUebersicht();
    }

    public class UebersichtDisplayImplDefault : IUebersichtDisplay
    {
        private readonly IUserNotify _notify;

        public UebersichtDisplayImplDefault(IUserNotify notify)
        {
            _notify = notify;
        }

        public void DisplayUebersicht()
        {
            _notify.ShowMessage("Produktionsübersicht kann nicht angezeigt werden.", UserNotifyMessageType.Error);
        }
    }
}
