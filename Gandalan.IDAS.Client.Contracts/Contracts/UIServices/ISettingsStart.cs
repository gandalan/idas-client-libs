using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface ISettingsStart
    {
        Task Show();
    }


    public class ISettingsStartDefault : ISettingsStart
    {
        private readonly IUserNotify _notify;

        public ISettingsStartDefault(IUserNotify notify)
        {
            _notify = notify;
        }

        public async Task Show()
        {
            _notify.ShowMessage("Einstellungen können nicht angezeigt werden.", UserNotifyMessageType.Error);
        }
    }
}
