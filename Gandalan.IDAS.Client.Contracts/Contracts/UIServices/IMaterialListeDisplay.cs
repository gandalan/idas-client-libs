using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices
{
    public interface IMaterialListeDisplay
    {
        Task<bool> Execute(BelegPositionAVDTO dto);
        Task<bool> Execute(List<BelegPositionAVDTO> dto);
    }
}
