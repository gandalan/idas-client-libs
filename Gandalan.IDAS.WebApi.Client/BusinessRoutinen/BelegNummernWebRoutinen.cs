using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client
{
    public class BelegNummernWebRoutinen : WebRoutinenBase
    {
        public BelegNummernWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<BelegNummerSettingDTO[]> GetBelegNummernAsync(bool currentYear = false)
            => await GetAsync<BelegNummerSettingDTO[]>($"BelegNummern?currentYear={currentYear}");

        public async Task SaveBelegNummerAsync(BelegNummerSettingDTO setting, bool currentYear = false)
            => await PutAsync($"BelegNummern?currentYear={currentYear}", setting);
    }
}
