using Gandalan.IDAS.WebApi.Client.DTOs.Produktion;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IProduktionsfreigabeListeService
    {
        Task<ProduktionsfreigabeItemDTO[]> GetIProduktionsfreigabeListeAsync();
    }
}
