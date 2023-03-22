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

        public BelegNummerSettingDTO[] GetBelegNummern(bool currentYear = false)
        {
            if (Login())
            {
                return Get<BelegNummerSettingDTO[]>($"BelegNummern?currentYear={currentYear}");
            }
            return null;
        }

        public string SaveBelegNummer(BelegNummerSettingDTO setting, bool currentYear = false)
        {
            if (Login())
            {
                return Put($"BelegNummern?currentYear={currentYear}", setting);
            }
            return null;
        }


        public async Task<BelegNummerSettingDTO[]> GetBelegNummernAsync(bool currentYear = false)
        {
            return await Task.Run(() => GetBelegNummern(currentYear));
        }

        public async Task<string> SaveBelegNummerAsync(BelegNummerSettingDTO setting, bool currentYear = false)
        {
            return await Task.Run(() => SaveBelegNummer(setting, currentYear));
        }
    }
}
