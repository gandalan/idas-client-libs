using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO.DTOs.Reports;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ResetCacheVariantenListenWebRoutinen : WebRoutinenBase
    {
        public ResetCacheVariantenListenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public void Reset()
        {
            if (Login())
            {
                Put("ResetCacheVariantenListen", null);
            }
        }


        public async Task ResetAsync()
        {
            await Task.Run(() => Reset());
        }
    }
}
