using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Vorgaenge
{
    public interface IBelegpositionPreisService
    {
        Task<bool> RecalculatePreis(BelegPositionDTO pos);
    }
}
