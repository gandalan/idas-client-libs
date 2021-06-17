using Gandalan.IDAS.WebApi.Data.DTO;
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
        Task<BelegPositionSonderwunschWerteListeDTO[]> GetAllSonderWuenscheWerteListenAsync();
        Task<VarianteSonderWunschDTO> GetAllSonderWuenscheFromVariante(string variantenName);
        Task<BelegPositionSonderwunschDTO[]> GetEigenschaftenFromImport(string ImportName);
    }
}
