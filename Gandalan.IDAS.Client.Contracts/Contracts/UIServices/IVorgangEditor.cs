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

    public class VorgangEditorImplDefault : IVorgangEditor
    {
        private readonly IUserNotify _notify;

        public VorgangEditorImplDefault(IUserNotify notify)
        {
            _notify = notify;
        }

        public async Task EditVorgang(Guid VorgangGuid)
        {
            _notify.ShowMessage("Es steht kein Vorgang-Bearbeitungsmodul zur Verfügung", UserNotifyMessageType.Error);
        }

        public async Task AddVorgang()
        {
            _notify.ShowMessage("Es steht kein Vorgang-Bearbeitungsmodul zur Verfügung", UserNotifyMessageType.Error);
        }

        public async Task AddVorgang(Guid KundeGuid)
        {
            _notify.ShowMessage("Es steht kein Vorgang-Bearbeitungsmodul zur Verfügung", UserNotifyMessageType.Error);
        }
    }
}
