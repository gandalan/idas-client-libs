using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gandalan.Client.Contracts.UIServices
{
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
