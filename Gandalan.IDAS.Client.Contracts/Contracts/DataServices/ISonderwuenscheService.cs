using Gandalan.IDAS.WebApi.Data.DTOs.SonderWuensche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface ISonderWuenscheService
    {
        Task<VarianteSonderWunschDTO[]> GetAllSonderWuenscheAsync();
        Task<SonderWunschWerteListeDTO[]> GetAllSonderWuenscheWerteListenAsync();
        Task<VarianteSonderWunschDTO> GetAllSonderWuenscheFromVariante(string variantenName);
    }
}
