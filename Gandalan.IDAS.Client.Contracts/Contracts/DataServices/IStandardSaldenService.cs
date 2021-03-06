﻿using Gandalan.IDAS.WebApi.Data.DTOs.Salden;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IStandardSaldenService
    {
        Task<StandardSaldoDTO[]> GetAllAsync();
        Task SaveAsync(StandardSaldoDTO saldo);
        Task DeleteAsync(Guid saldoGuid);
    }
}
