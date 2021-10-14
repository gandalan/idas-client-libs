using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface ISaldenService
    {
        Task InitializeSalden(BelegDTO beleg);
        Task RecalculateSalden(BelegDTO beleg);
        Task RemoveSaldo(BelegDTO beleg, BelegSaldoDTO saldo);
        Task AddSaldo(BelegDTO beleg, BelegSaldoDTO saldo);
        void UpdateSaldenText(BelegSaldoDTO saldo);
    }
}
