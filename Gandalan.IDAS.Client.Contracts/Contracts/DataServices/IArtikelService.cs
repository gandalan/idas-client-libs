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
        Task<KatalogArtikelDTO[]> GetAllAsync();
        Task<WarenGruppeDTO[]> GetAllWarenGruppenAsync();
        Task<string> SaveArtikelAsync(KatalogArtikelDTO artikel);
        Task<KatalogArtikelDTO> LoadArtikelAsync(Guid guid);
        Task<KatalogArtikelDTO> LoadArtikelAsync(string artikelNummer);        
    }
}
