// *****************************************************************************
// Gandalan GmbH & Co. KG - (c) 2017
// *****************************************************************************
// Middleware//Gandalan.IDAS.WebApi.Client//ArtikelWebRoutinen.cs
// Created: 14.04.2016
// Edit: phil - 15.02.2017
// Edit: carsten - 23.03.2021
// *****************************************************************************

using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ArtikelWebRoutinen : WebRoutinenBase
    {
        public ArtikelWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public async Task<WarenGruppeDTO[]> GetAllAsync(DateTime? changedSince = null)
        {
            if(changedSince.HasValue && changedSince.Value > DateTime.MinValue)
                return await GetAsync<WarenGruppeDTO[]>("Artikel?changedSince=" + changedSince.Value.ToString("o"), version : "2.0");
            else
                return await GetAsync<WarenGruppeDTO[]>("Artikel", version: "2.0");
        }

        public async Task<KatalogArtikelDTO> SaveArtikelAsync(KatalogArtikelDTO artikel)
        {
            return await PutAsync<KatalogArtikelDTO>($"Artikel/{artikel.KatalogArtikelGuid}", artikel);
        }

        public async Task DeleteArtikelAsync(KatalogArtikelDTO artikel)
        {
            await DeleteAsync($"Artikel/{artikel.KatalogArtikelGuid}");
        }
    }
}
