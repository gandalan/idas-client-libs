// Gandalan GmbH & Co. KG - (c) 2019
// Middleware//Gandalan.IDAS.WebApi.Client//BelegArtWebRoutinen.cs
// Created: 13.06.2019 Konstantin Tümmler

using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BelegArtWebRoutinen : WebRoutinenBase
{
    public BelegArtWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<VorgangDTO> BelegKopierenAsync(Guid bguid, string neueBelegArt, bool saldenKopieren = false)
        => await PostAsync<VorgangDTO>($"BelegArt?bguid={bguid}&saldenKopieren={saldenKopieren}&neueBelegArt={neueBelegArt}", new { });
}