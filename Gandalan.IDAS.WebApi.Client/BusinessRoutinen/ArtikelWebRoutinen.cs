// *****************************************************************************
// Gandalan GmbH & Co. KG - (c) 2017
// *****************************************************************************
// Middleware//Gandalan.IDAS.WebApi.Client//ArtikelWebRoutinen.cs
// Created: 14.04.2016
// Edit: phil - 15.02.2017
// *****************************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ArtikelWebRoutinen : WebRoutinenBase
    {
        public ArtikelWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public WarenGruppeDTO[] GetAll()
        {
            if (Login())
            {
                return Get<WarenGruppeDTO[]>("Artikel");
            }
            return null;
        }

        public async Task<WarenGruppeDTO[]> HTTPGetAll()
        {
            if(HTTPLogin() != null)
                return await HTTPGet<WarenGruppeDTO[]>("Artikel");

            return null;
        }

        public string SaveArtikel(KatalogArtikelDTO artikel)
        {
            if (Login())
            {
                return Put<string>($"Artikel/{artikel.KatalogArtikelGuid}", artikel);
            }
            return "Not logged in";
        }

        public string DeleteArtikel(KatalogArtikelDTO artikel)
        {
            if (Login())
            {
                return Delete($"Artikel/{artikel.KatalogArtikelGuid}");
            }
            return "Not logged in";
        }


        public async Task<WarenGruppeDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task<WarenGruppeDTO[]> HTTPGetAllAsync()
        {
            return await Task.Run(() => HTTPGetAll());
        }

        public async Task<string> SaveArtikelAsync(KatalogArtikelDTO artikel)
        {
            return await Task.Run(() => SaveArtikel(artikel));
        }
    }
}