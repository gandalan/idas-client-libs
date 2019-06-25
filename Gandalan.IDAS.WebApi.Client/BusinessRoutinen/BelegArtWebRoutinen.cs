// Gandalan GmbH & Co. KG - (c) 2019
// Middleware//Gandalan.IDAS.WebApi.Client//BelegArtWebRoutinen.cs
// Created: 13.06.2019 Konstantin Tümmler

using System;
using Gandalan.IDAS.WebApi.Client.Settings;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BelegArtWebRoutinen : WebRoutinenBase
    {
        public BelegArtWebRoutinen(WebApiSettings settings) : base(settings)
        {
            //Settings.Url = Settings.Url.Replace("/api/", "/BelegArt/");
        }

        public string BelegKopieren(Guid bguid, string neueBelegArt, bool saldenKopieren = false)
        {
            if (Login())
            {
                return Post($"BelegArt?bguid={bguid}&saldenKopieren={saldenKopieren}&neueBelegArt={neueBelegArt}", new {});
            }
            return null;
        }
    }
}