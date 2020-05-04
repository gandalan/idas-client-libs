using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV
{
    public interface IIsSonderfarbArtikel
    {
        bool CheckSonderfarbe(MaterialBeschaffungsJobDTO materialBeschaffungsJobDTO);
        bool CheckSonderfarbe(MaterialbedarfDTO materialBedarfDTO);
    }
}
