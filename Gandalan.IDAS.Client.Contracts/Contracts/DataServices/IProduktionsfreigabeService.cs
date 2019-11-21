using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IProduktionsfreigabeService
    {
        Task<VorgangDTO> ProduktionsfreigabeAsync(ProduktionsfreigabeDTO dto);

        VorgangDTO Produktionsfreigabe(ProduktionsfreigabeDTO dto);
    }
}
