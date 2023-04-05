// Gandalan GmbH & Co. KG - (c) 2019
// Middleware//Gandalan.IDAS.WebApi.Client//BelegArtWebRoutinen.cs
// Created: 13.06.2019 Konstantin Tümmler

using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BelegArtPosWebRoutinen : WebRoutinenBase
    {
        public BelegArtPosWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public VorgangDTO BelegWechsel(BelegartWechselDTO dto)
        {
            if (Login())
            {
                return Put<VorgangDTO>("BelegArtPos", dto);
            }
            return null;
        }

        public async Task<VorgangDTO> BelegWechselAsync(BelegartWechselDTO dto)
        {
            return await Task<VorgangDTO>.Run(() => { return BelegWechsel(dto); });
        }
    }
}