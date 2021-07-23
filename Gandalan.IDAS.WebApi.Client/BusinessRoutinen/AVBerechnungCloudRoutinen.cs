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

        public BerechnungResultDTO Process(BerechnungParameterDTO parameter)
        {
            string variante = Uri.EscapeDataString(parameter.BelegPositionAVDTO.Variante);
            return Post<BerechnungResultDTO>($"ProcessIbos/Process?varianteName={variante}", parameter);
        }
    }
}
