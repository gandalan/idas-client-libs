using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.Data.DTOs.Salden;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class StandardSaldenWebRoutinen : WebRoutinenBase
    {
        public StandardSaldenWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public StandardSaldoDTO[] GetAll()
        {
            if (Login())
            {
                return Get<StandardSaldoDTO[]>("StandardSalden");
            }
            return null;
        }

        public string SaveSaldo(StandardSaldoDTO dto)
        {
            if (Login())
            {
                return Put("StandardSalden/", dto);
            }
            return null;
        }

        public void DeleteSaldo(Guid saldoGuid)
        {
            if (Login())
            {
                Delete("StandardSalden/" + saldoGuid);
            }
        }

        public async Task<StandardSaldoDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task SaveSaldoAsync(StandardSaldoDTO dto)
        {
            await Task.Run(() => SaveSaldo(dto));
        }
        public async Task DeleteSaldoAsync(Guid saldoGuid)
        {
            await Task.Run(() => DeleteSaldo(saldoGuid));
        }
    }
}
