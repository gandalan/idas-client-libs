using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;
using System.Diagnostics;
using Gandalan.IDAS.WebApi.Client.Settings;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client
{
    public class MandantenWebRoutinen : WebRoutinenBase
    {
        public MandantenWebRoutinen(WebApiSettings settings) : base(settings)
        {            
        }

        public void MandantenAbgleichen(List<MandantDTO> list)
        {
            if (Login())
            {
                list.ForEach(m =>
                {
                    string responseStr = Put<string>("Mandanten", m);
                    Debug.WriteLine(responseStr);
                });
            }
        }

        public MandantDTO MandantenAnlegen(MandantDTO mandant)
        {
            if (Login())
            {
                return Put<MandantDTO>("Mandanten", mandant);
            }

            return null;
        }

        public List<MandantDTO> LadeMandantenMitFilter(string filter)
        {
            if (Login())
            {
                return Get<List<MandantDTO>>("Mandanten?filter=" + System.Uri.EscapeDataString(filter));
            }

            return null;
        }

        public void GetLoginByDongleNummer(string dongleNummer)
        {
            
        }


        public async Task<MandantDTO> MandantenAnlegenAsync(MandantDTO mandant)
        {
            return await Task.Run(() => MandantenAnlegen(mandant));
        }
    }
}
