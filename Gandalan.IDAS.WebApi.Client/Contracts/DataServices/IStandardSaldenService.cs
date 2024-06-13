using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTOs.Salden;

namespace Gandalan.Client.Contracts.DataServices;

public interface IStandardSaldenService
{
    Task<StandardSaldoDTO[]> GetAllAsync();
    Task SaveAsync(StandardSaldoDTO saldo);
    Task DeleteAsync(Guid saldoGuid);
}