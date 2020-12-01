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
    public class ArtikelIndiDatenWebRoutinen : WebRoutinenBase
    {
        public ArtikelIndiDatenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public KatalogArtikelIndiDatenDTO[] GetAll()
        {
            if (Login())
            {
                return Get<KatalogArtikelIndiDatenDTO[]>("ArtikelIndiDaten");
            }
            return null;
        }

        public string SaveArtikelIndiDaten(KatalogArtikelIndiDatenDTO daten)
        {
            if (Login())
            {
                return Put<string>($"ArtikelIndiDaten/{daten.KatalogArtikelGuid}", daten);
            }
            return "Not logged in";
        }

        public string DeleteArtikelIndiDaten(KatalogArtikelIndiDatenDTO daten)
        {
            if (Login())
            {
                return Delete($"ArtikelIndiDaten/{daten.KatalogArtikelGuid}");
            }
            return "Not logged in";
        }

        public async Task<KatalogArtikelIndiDatenDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }
        public async Task<KatalogArtikelIndiDatenDTO[]> HTTPGetAllAsync()
        {
            if (HTTPLogin() != null)
                return await HTTPGet<KatalogArtikelIndiDatenDTO[]>("ArtikelIndiDaten");

            return null;
        }

        public async Task<string> SaveArtikelIndiDatenAsync(KatalogArtikelIndiDatenDTO daten)
        {
            return await Task.Run(() => SaveArtikelIndiDaten(daten));
        }
    }
}