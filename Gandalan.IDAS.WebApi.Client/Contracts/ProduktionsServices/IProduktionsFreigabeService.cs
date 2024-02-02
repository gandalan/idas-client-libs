using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IProduktionsFreigabeService
    {
        void BelegFreigabe(BelegDTO belegDTO);
        void PositionsFreigabe(BelegPositionDTO pos);
    }
}
