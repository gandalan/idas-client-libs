using Gandalan.IDAS.WebApi.DTO;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAVSerienStore
    {
        IList<SerieDTO> GetAll();
        void SaveSerie(SerieDTO serie);
        void AddElement(SerieDTO serie, BelegPositionAVDTO element);
        void RemoveElement(SerieDTO serie, BelegPositionAVDTO element);
    }
}
