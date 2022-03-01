using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Vorgaenge
{
    public interface ISonderwunschBerechnenService
    {
        bool RecalculateSonderwuensche(BelegPositionDTO pos);
    }
}
