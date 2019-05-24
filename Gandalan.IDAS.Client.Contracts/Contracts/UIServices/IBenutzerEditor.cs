using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IBenutzerEditor
    {
        void EditBenutzer(Guid benutzerGuid, bool istProduzent);
        void DeleteBenutzer(Guid benutzerGuid);
        void CreateBenutzer(bool istProduzent);
    }

    public class BenutzerEditorImplDefault : IBenutzerEditor
    {
        private readonly IUserNotify _notify;

        public BenutzerEditorImplDefault(IUserNotify notify)
        {
            _notify = notify;
        }

        public void EditBenutzer(Guid benutzerGuid, bool istProduzent)
        {
            _notify.ShowMessage("Benutzer kann nicht editiert werden.", UserNotifyMessageType.Error);
        }

        public void DeleteBenutzer(Guid benutzerGuid)
        {
            _notify.ShowMessage("Benutzer kann nicht gelöscht werden.", UserNotifyMessageType.Error);
        }

        public void CreateBenutzer(bool istProduzent)
        {
            _notify.ShowMessage("Benutzer kann nicht erstellt werden.", UserNotifyMessageType.Error);
        }
    }
}
