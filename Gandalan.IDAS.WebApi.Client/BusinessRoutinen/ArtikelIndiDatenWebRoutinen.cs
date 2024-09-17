// *****************************************************************************
// Gandalan GmbH & Co. KG - (c) 2017
// *****************************************************************************
// Middleware//Gandalan.IDAS.WebApi.Client//ArtikelWebRoutinen.cs
// Created: 14.04.2016
// Edit: phil - 15.02.2017
// *****************************************************************************

using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class ArtikelIndiDatenWebRoutinen : WebRoutinenBase
{
    public ArtikelIndiDatenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<KatalogArtikelIndiDatenDTO[]> GetAllAsync(DateTime? changedSince = null)
    {
        if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
        {
            return await GetAsync<KatalogArtikelIndiDatenDTO[]>($"ArtikelIndiDaten?changedSince={changedSince.Value:o}");
        }
        return await GetAsync<KatalogArtikelIndiDatenDTO[]>("ArtikelIndiDaten");
    }

    public async Task SaveArtikelIndiDaten(KatalogArtikelIndiDatenDTO daten)
    {
        await PutAsync($"ArtikelIndiDaten/{daten.KatalogArtikelGuid}", daten);
    }

    public async Task DeleteArtikelIndiDaten(KatalogArtikelIndiDatenDTO daten)
    {
        await DeleteAsync($"ArtikelIndiDaten/{daten.KatalogArtikelGuid}");
    }

}
