// Gandalan GmbH & Co. KG - (c) 2017
// Middleware//Gandalan.IDAS.WebApi.Client//BauteileWebRoutinen.cs
// Created: 14.02.2017
// Edit: phil - 15.02.2017

using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class KomponentenWebRoutinen : WebRoutinenBase
{
    public KomponentenWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        Settings.Url = Settings.Url.Replace("/api/", "/ModellDaten/");
    }

    public async Task<KomponenteDTO[]> GetAllAsync()
        => await GetAsync<KomponenteDTO[]>("Komponente");

    public async Task SaveKomponenteAsync(KomponenteDTO dto)
        => await PutAsync("Komponente", dto);
}