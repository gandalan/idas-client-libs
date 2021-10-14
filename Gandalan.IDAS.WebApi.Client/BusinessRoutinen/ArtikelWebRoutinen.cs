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
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ArtikelWebRoutinen : WebRoutinenBase
    {
        public ArtikelWebRoutinen(IWebApiConfig settings) : base(settings) { }

        public WarenGruppeDTO[] GetAll()
        {
            if (Login())
                return Get<WarenGruppeDTO[]>("Artikel");
            throw new ApiException("Login fehlgeschlagen");
        }
        public KatalogArtikelDTO SaveArtikel(KatalogArtikelDTO artikel)
        {
            if (Login())
                return Put<KatalogArtikelDTO>($"Artikel/{artikel.KatalogArtikelGuid}", artikel);
            throw new ApiException("Login fehlgeschlagen");
        }
        public string DeleteArtikel(KatalogArtikelDTO artikel)
        {
            if (Login())
                return Delete($"Artikel/{artikel.KatalogArtikelGuid}");
            throw new ApiException("Login fehlgeschlagen");
        }
        public async Task<WarenGruppeDTO[]> GetAllAsync() => await Task.Run(() => GetAll());
        public async Task<KatalogArtikelDTO> SaveArtikelAsync(KatalogArtikelDTO artikel) => await Task.Run(() => SaveArtikel(artikel));
    }
}