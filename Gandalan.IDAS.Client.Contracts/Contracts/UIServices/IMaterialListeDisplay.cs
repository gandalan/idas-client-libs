using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices
{
    public interface IMaterialListeDisplay
    {
        void Execute(BelegPositionAVDTO dto);
    }
}
