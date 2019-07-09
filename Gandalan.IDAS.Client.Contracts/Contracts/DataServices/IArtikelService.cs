using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IArtikelService
    {
        Task<WarenGruppeDTO[]> GetAllAsync();
        Task<string> SaveAsync(KatalogArtikelDTO artikel);
        Task<KatalogArtikelDTO> LoadAsync(Guid guid);
        Task<KatalogArtikelDTO> GetArtikel(string artikelNummer);        
    }
}
