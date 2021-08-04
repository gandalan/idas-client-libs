using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;
using System;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AVBerechnungCloudRoutinen : WebRoutinenBase
    {
        public AVBerechnungCloudRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public BerechnungParameterDTO Process(BerechnungParameterDTO parameter)
        {
            return Post<BerechnungParameterDTO>($"ProcessIbos/Process", parameter);
        }
    }
}
