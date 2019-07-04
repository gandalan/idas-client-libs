// Gandalan GmbH & Co. KG - (c) 2019
// Middleware//Gandalan.IDAS.WebApi.Client//BelegArtWebRoutinen.cs
// Created: 13.06.2019 Konstantin Tümmler

using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BelegArtWebRoutinen : WebRoutinenBase
    {
        public BelegArtWebRoutinen(WebApiSettings settings) : base(settings)
        {
            //Settings.Url = Settings.Url.Replace("/api/", "/BelegArt/");
        }

        public VorgangDTO BelegKopieren(Guid bguid, string neueBelegArt, bool saldenKopieren = false)
        {
            if (Login())
            {
                return Post<VorgangDTO>($"BelegArt?bguid={bguid}&saldenKopieren={saldenKopieren}&neueBelegArt={neueBelegArt}", new {});
            }
            return null;
        }

        public async Task<VorgangDTO> BelegKopierenAsync(Guid bguid, string neueBelegArt, bool saldenKopieren = false)
        {
            return await Task<VorgangDTO>.Run(() => { return BelegKopieren(bguid, neueBelegArt, saldenKopieren); });
        }
    }
}