// Gandalan GmbH & Co. KG - (c) 2019
// Middleware//Gandalan.IDAS.WebApi.Client//BelegArtWebRoutinen.cs
// Created: 13.06.2019 Konstantin Tümmler

using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class BelegLoeschenWebRoutinen : WebRoutinenBase
    {
        public BelegLoeschenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public string BelegLoeschen(Guid bguid)
        {
            if (Login())
            {
                return Delete("Vorgang/DeleteBeleg/" + bguid.ToString());
            }
            return null;
        }

        public async Task<string> BelegLoeschenAsync(Guid bguid)
        {
            if (await LoginAsync())
            {
                return await DeleteAsync("Vorgang/DeleteBeleg/" + bguid.ToString());
            }
            return null;
        }
    }
}