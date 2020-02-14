using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IInfoScreenModul
    {
        string Name { get; }
        Guid ModuleGuid { get; }

        bool NeedsInit { get; set; }

        object GetControl();

        void ApplySettings(InfoScreenModulSettingsDTO settings);

        void ShowSettingsDialog(InfoScreenModulSettingsDTO settings, List<InfoScreenInitTypeDTO> availableTypes);

        IInfoScreenModul Init<T>(T inputDTO);
    }
}
