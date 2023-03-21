using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;
using System.Threading.Tasks;
using System;
using Gandalan.IDAS.Client.Contracts.Contracts;

namespace Gandalan.IDAS.WebApi.Client
{
    public class MandantenAdminWebRoutinen : WebRoutinenBase
    {
        public MandantenAdminWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public List<MandantDTO> LadeMandantenMitFilter(string filter, bool onlyHaendler, bool onlyProduzenten)
        {
            if (Login())
            {
                if (!String.IsNullOrEmpty(filter))
                    filter = System.Uri.EscapeDataString(filter);
                else
                    filter = string.Empty;


                return Get<List<MandantDTO>>("MandantenAdmin?filter=" + filter + "&onlyHaendler=" + onlyHaendler + "&onlyProduzenten=" + onlyProduzenten);
            }

            return null;
        }

        public MandantDTO LadeMandant(Guid guid)
        {
            if (Login())
            {
                return Get<MandantDTO>("MandantenAdmin?guid=" + guid.ToString());
            }

            return null;
        }

        public string MandantenUmziehen(Guid mandant, Guid zielMandant)
        {
            if (Login())
            {
                return Put("MandantenAdmin", new List<Guid> { mandant, zielMandant });
            }

            return null;
        }

        public void AddAdminRechte(string email)
        {
            if (Login())
            {
                Post($"MandantenAdmin/SetAdminRechte?email={Uri.EscapeDataString(email)}", null);
            }
        }


        public async Task<List<MandantDTO>> LadeMandantenMitFilterAsync(string filter, bool onlyHaendler, bool onlyProduzenten)
        {
            return await Task.Run(() => LadeMandantenMitFilter(filter, onlyHaendler, onlyProduzenten));
        }

        public async Task<MandantDTO> LadeMandantAsync(Guid guid)
        {
            return await Task.Run(() => LadeMandant(guid));
        }
    }
}
