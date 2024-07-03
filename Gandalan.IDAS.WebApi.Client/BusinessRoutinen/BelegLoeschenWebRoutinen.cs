// Gandalan GmbH & Co. KG - (c) 2019
// Middleware//Gandalan.IDAS.WebApi.Client//BelegArtWebRoutinen.cs
// Created: 13.06.2019 Konstantin Tümmler

using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BelegLoeschenWebRoutinen : WebRoutinenBase
{
    public BelegLoeschenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<VorgangDTO> BelegLoeschenAsync(Guid bguid)
        => await DeleteAsync<VorgangDTO>($"Vorgang/DeleteBeleg/{bguid}", null);
}