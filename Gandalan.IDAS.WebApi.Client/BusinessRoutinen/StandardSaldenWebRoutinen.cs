using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.Salden;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class StandardSaldenWebRoutinen : WebRoutinenBase
    {
        public StandardSaldenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<StandardSaldoDTO[]> GetAllAsync()
            => await GetAsync<StandardSaldoDTO[]>("StandardSalden");

        public async Task SaveSaldoAsync(StandardSaldoDTO dto)
            => await PutAsync("StandardSalden/", dto);

        public async Task DeleteSaldoAsync(Guid saldoGuid)
            => await DeleteAsync("StandardSalden/" + saldoGuid);
    }
}
