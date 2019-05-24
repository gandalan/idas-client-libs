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
    public interface IBelegPositionEditor
    {
        Task AddPosition(BelegPositionDTO position, VorgangDTO vorgang);
        Task EditPosition(BelegPositionDTO position, VorgangDTO vorgang);
        Task<IBelegPositionEditorControl> GetControl(BelegPositionDTO belegPosition, VorgangDTO vorgang);
    }

    public class BelegPositionEditorImplDefault : IBelegPositionEditor
    {
        private readonly IUserNotify _notify;

        public BelegPositionEditorImplDefault(IUserNotify notify)
        {
            this._notify = notify;
        }

        public async Task AddPosition(BelegPositionDTO belegPosition, VorgangDTO vorgang)
        {
            _notify.ShowMessage("Belegposition kann nicht erstellt werden.", UserNotifyMessageType.Error);
        }

        public async Task EditPosition(BelegPositionDTO position, VorgangDTO vorgang)
        {
            _notify.ShowMessage("Belegposition kann nicht bearbeitet werden.", UserNotifyMessageType.Error);
        }

        public Task<IBelegPositionEditorControl> GetControl(BelegPositionDTO belegPosition, VorgangDTO vorgang)
        {
            _notify.ShowMessage("Belegposition Control kann nicht angezeigt werden.", UserNotifyMessageType.Error);
            return null;
        }
    }

    public interface IBelegPositionEditorControl
    {
        IBelegPositionEditorViewModel Model { get; }
    }

    public interface IBelegPositionEditorViewModel
    {
        BelegPositionDTO Position { get; }

        // Diese Felder müssen aus dem Editor-Viewmodel mal noch raus, weil kaufmännisch... refa!
        decimal AufAbSchlag { get; set; }
        decimal Einzelpreis { get; set; }
        decimal Gesamtpreis { get; set; }
        decimal Listenpreis { get; }
        decimal Menge { get; set; }
        decimal Rabatt { get; set; }

        Task Load(BelegPositionDTO position, VorgangDTO vorgang);
        void UpdateBelegPosition();
    }

}
