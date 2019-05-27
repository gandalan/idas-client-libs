using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IBenutzerDisplayListe
    {
        void DisplayBenutzerListe(Guid mandant);
    }

    public class BenutzerDisplayListeImplDefault : IBenutzerDisplayListe
    {
        private readonly IUserNotify _notify;

        public BenutzerDisplayListeImplDefault(IUserNotify notify)
        {
            _notify = notify;
        }

        public void DisplayBenutzerListe(Guid mandant)
        {
            _notify.ShowMessage("Benutzer Übersicht kann nicht angezeigt werden.", UserNotifyMessageType.Error);
        }
    }
}
