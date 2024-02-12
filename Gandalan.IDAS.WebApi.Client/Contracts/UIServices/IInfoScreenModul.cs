using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.UIServices
{
    /// <summary>
    /// Interface für die Implementierung eines eigenen InfoScreen Moduls
    /// </summary>
    public interface IInfoScreenModul
    {
        string Name { get; }

        Guid ModuleGuid { get; }

        //Legt fest ob das Modul mit Daten initialisiert werden muss, oder nicht
        bool NeedsInit { get; set; }

        //Liefert das UIElement zurück
        object GetControl();

        void ApplySettings(InfoScreenModulSettingsDTO settings);

        void ShowSettingsDialog(InfoScreenModulSettingsDTO settings, List<InfoScreenInitTypeDTO> availableTypes);

        IInfoScreenModul Init<T>(T inputDTO);
    }
}
