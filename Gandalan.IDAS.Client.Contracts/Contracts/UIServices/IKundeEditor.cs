using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.Client.Common.Contracts.UIServices;
using Gandalan.Client.Common.UI;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IKundeEditor
    {
        Task EditKunde(Guid kundeGuid);
    }

    public class KundeEditorImplDefault : IKundeEditor
    {
        private readonly IUserNotify _notify;

        public KundeEditorImplDefault(IUserNotify notify)
        {
            this._notify = notify;
        }

        public async Task EditKunde(Guid kundeGuid)
        {
            _notify.ShowMessage("Es steht kein Kunden-Bearbeitungsmodul zur Verfügung", UserNotifyMessageType.Error);
        }
    }
}
