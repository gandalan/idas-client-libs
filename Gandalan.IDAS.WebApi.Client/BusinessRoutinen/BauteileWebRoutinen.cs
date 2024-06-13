// Gandalan GmbH & Co. KG - (c) 2017
// Middleware//Gandalan.IDAS.WebApi.Client//BauteileWebRoutinen.cs
// Created: 14.02.2017
// Edit: phil - 15.02.2017

using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class BauteileWebRoutinen : WebRoutinenBase
{
    public BauteileWebRoutinen(IWebApiConfig settings) : base(settings)
    {
            Settings.Url = Settings.Url.Replace("/api/", "/ModellDaten/");
        }

    public async Task<BauteilDTO[]> GetAllAsync()
    {
            return await GetAsync<BauteilDTO[]>("Bauteil");
        }

    public async Task SaveBauteilAsync(BauteilDTO dto)
    {
            await PutAsync("Bauteil", dto);
        }
}