using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BriefbogenWebRoutinen : WebRoutinenBase
    {
        public BriefbogenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public byte[] BriefbogenLaden()
        {
            if (Login())
            {
                return GetData("Briefbogen");

            }
            return null;
        }


        public async Task<byte[]> BriefbogenLadenAsync()
        {
            return await Task<string>.Run(() => { return BriefbogenLaden(); });
        }
    }
}
