using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// Informativ: Artikel-Arten
    /// </summary>
    public enum KatalogArtikelArt
    {
        Ungueltig = 0,
        KatalogArtikel = 1,
        ProfilArtikel = 2,
        FertigElementArtikel = 4,
        GewebeArtikel = 8,
        DienstleistungsArtikel = 16
    }
}
