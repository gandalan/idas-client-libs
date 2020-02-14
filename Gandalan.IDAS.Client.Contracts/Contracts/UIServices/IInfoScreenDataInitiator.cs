using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gandalan.Client.Contracts.UIServices
{
    /// <summary>
    /// Interface für die Implementierung von Initiatoren für die InfoScreens. Der Initiator eines ist für die Beschaffung der Daten für den InfoScreen zuständig (z.B. nach QR Code Scan oder PCode Eingabe)
    /// </summary>
    public interface IInfoScreenDataInitiator
    {
        string Name { get; }
        List<InfoScreenInitTypeDTO> GetInitData();
        object GetInitControl();
        List<InfoScreenInitTypeDTO> GetAllowedTypes();

        Task UnLoadAsync();

        event EventHandler InitStart;

        event EventHandler InitComplete;
    }

}
