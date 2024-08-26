using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices;

public interface IMaterialBestellungExport
{
    Task<bool> Export(IList<MaterialbedarfDTO> material, string extension, string path);
    Task<bool> Send(IList<MaterialbedarfDTO> material, string extension, string email);
}